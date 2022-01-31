using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_hrgis.Data;
using api_hrgis.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System.IO;
using OfficeOpenXml;

namespace api_hrgis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TrainersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Trainers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tr_trainer>>> Gettr_trainer()
        {
            var f = await (from trainer in _context.tr_trainer
            join data in  _context.tb_employee on trainer.emp_no equals data.emp_no into z
            from emp in z.DefaultIfEmpty()
            select new { 
                    trainer_no = trainer.trainer_no,
                    emp_no = trainer.emp_no,
                    sname_en = trainer.sname_en?? emp.sname_eng,
                    gname_en = trainer.gname_en?? emp.gname_eng,
                    fname_en = trainer.fname_en?? emp.fname_eng,
                    div_abb_name = emp.div_abb_name,
                    dept_abb_name = emp.dept_abb_name,
                    organization = trainer.organization,
                    employed_status = emp.employed_status,
                    trainer_type = trainer.trainer_type
            }).ToListAsync();

            return Ok(f);
        }

        // GET: api/Trainers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tr_trainer>> Gettr_trainer(int id)
        {
            var tr_trainer = await _context.tr_trainer.FindAsync(id);

            if (tr_trainer == null)
            {
                return NotFound();
            }

            return tr_trainer;
        }

        // PUT: api/Trainers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttr_trainer(int id, tr_trainer tr_trainer)
        {
            if (id != tr_trainer.trainer_no)
            {
                return BadRequest();
            }

            _context.Entry(tr_trainer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tr_trainerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Trainers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tr_trainer>> Posttr_trainer(tr_trainer tr_trainer)
        {
            if (tr_trainer.trainer_type=="Internal" && trainer_internal_exists(tr_trainer.emp_no))
            {
                return Conflict("Data is alredy exists");
            }

            _context.tr_trainer.Add(tr_trainer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettr_trainer", new { id = tr_trainer.trainer_no }, tr_trainer);
        }

        // DELETE: api/Trainers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetr_trainer(int id)
        {
            var tr_trainer = await _context.tr_trainer.FindAsync(id);
            if (tr_trainer == null)
            {
                return NotFound();
            }

            _context.tr_trainer.Remove(tr_trainer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tr_trainerExists(int id)
        {
            return _context.tr_trainer.Any(e => e.trainer_no == id);
        }
        private bool trainer_internal_exists(string emp_no)
        {
            return _context.tr_trainer.Any(e => e.emp_no == emp_no);
        }

        // GET: api/Trainers/FullTrainers
        [HttpGet("FullTrainers")]
        public async Task<ActionResult> FullTrainers()
        {
            // SELECT tb1.trainer_no, tb1.emp_no
            // , CASE WHEN tb1.organization IS NOT NULL THEN tb1.organization ELSE tb2.dept_abb_name END AS organization
            // , CASE WHEN tb1.fname_en IS NOT NULL THEN tb1.fname_en ELSE tb2.fname_eng END AS fname_en
            // , CASE WHEN tb1.gname_en IS NOT NULL THEN tb1.gname_en ELSE tb2.gname_eng END AS gname_en
            // , CASE WHEN tb1.sname_en IS NOT NULL THEN tb1.sname_en ELSE tb2.sname_eng END AS sname_en
            // , tb1.trainer_type
            // , CASE WHEN tb1.trainer_type = 'Internal' 
            //     THEN CASE WHEN tb2.sname_eng = 'MISS' THEN tb2.sname_eng + '.' ELSE tb2.sname_eng END + tb2.gname_eng + ' ' + LEFT(tb2.fname_eng,1) + ' ('+ tb2.dept_abb_name +')' 
            //     ELSE tb1.sname_en + tb1.gname_en + ' ' + LEFT(tb1.fname_en,1) + '.' END AS fulls
            // FROM [HRGIS].[dbo].[tr_trainer] tb1 
            // LEFT JOIN tb_employee tb2 ON tb1.emp_no = tb2.emp_no
            // WHERE status_active = 1
            var query = await (
                from tb1 in _context.tr_trainer
                join tb2 in _context.tb_employee on tb1.emp_no equals tb2.emp_no into tb
                from table in tb.DefaultIfEmpty()
                where tb1.status_active == true
                select new { 
                    tb1.trainer_no, 
                    tb1.emp_no,
                    organization = ( tb1.organization != null ? tb1.organization : table.dept_abb_name),
                    fname_en = ( tb1.fname_en != null ? tb1.fname_en : table.fname_eng),
                    gname_en = ( tb1.gname_en != null ? tb1.gname_en : table.gname_eng),
                    sname_en = ( tb1.sname_en != null ? tb1.sname_en : table.sname_eng),
                    tb1.trainer_type,
                    fulls = (
                        tb1.trainer_type == "Internal" ? 
                        table.sname_eng == null ? "" :
                        table.sname_eng == "MISS" ? table.sname_eng + "." + table.gname_eng + " " + table.fname_eng.Substring(0,1) + ". (" + table.dept_abb_name + ")" 
                        : table.sname_eng + table.gname_eng + " " + table.fname_eng.Substring(0,1) + ". (" + table.dept_abb_name + ")" 
                        : tb1.sname_en + tb1.gname_en + " " + tb1.fname_en.Substring(0,1) + "."
                    )
                }).OrderBy(x => x.gname_en).ToListAsync();
                
            return Ok(query);
        }
        [HttpGet("Mock")]
        public async Task<ActionResult<IEnumerable<tr_trainer>>> Trainer()
        {
            string filePath = Path.Combine("./wwwroot/", $"Mockdata.xlsx");

            if(System.IO.File.Exists(filePath)){
                Console.WriteLine("File exists.");
                using(var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["tr_trainer"];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;
                    for (int row = 2; row <= rowCount; row++){
                        _context.Add(new tr_trainer
                        {
                            emp_no = worksheet.Cells[row, 2].Value==null ? null:worksheet.Cells[row, 2].Value.ToString().Trim(),
                            sname_en = worksheet.Cells[row, 3].Value==null ? null:worksheet.Cells[row, 3].Value.ToString().Trim(),
                            gname_en = worksheet.Cells[row, 4].Value==null ? null:worksheet.Cells[row, 4].Value.ToString().Trim(),
                            fname_en = worksheet.Cells[row, 5].Value==null ? null:worksheet.Cells[row, 5].Value.ToString().Trim(),
                            sname_th = worksheet.Cells[row, 6].Value==null ? null:worksheet.Cells[row, 6].Value.ToString().Trim(),
                            gname_th = worksheet.Cells[row, 7].Value==null ? null:worksheet.Cells[row, 7].Value.ToString().Trim(),
                            fname_th = worksheet.Cells[row, 8].Value==null ? null:worksheet.Cells[row, 8].Value.ToString().Trim(),
                            trainer_type = worksheet.Cells[row, 9].Value.ToString().Trim(),
                            organization = worksheet.Cells[row, 10].Value==null ? null:worksheet.Cells[row, 10].Value.ToString().Trim(),
                            created_at = DateTime.Now,
                            created_by = "014496",
                            status_active = true
                        });
                        await _context.SaveChangesAsync();
                    }
               }
            }
            return Ok("success");
        }
    }
}
