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
using Microsoft.AspNetCore.Authorization;

namespace api_hrgis.Controllers
{
    [Authorize]
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
                    title_name_en = trainer.title_name_en?? emp.title_name_en,
                    firstname_en = trainer.firstname_en?? emp.firstname_en,
                    lastname_en = trainer.lastname_en?? emp.lastname_en,
                    div_abb = emp.div_abb,
                    dept_abb = emp.dept_abb,
                    organization = trainer.organization,
                    employed_status = emp.employed_status,
                    trainer_type = trainer.trainer_type
            }).ToListAsync();

            return Ok(f);
        }

        // GET: api/Trainers/5
        [HttpGet("{trainer_no}")]
        public async Task<ActionResult<tr_trainer>> Gettr_trainer(int trainer_no)
        {
            // var tr_trainer = await _context.tr_trainer.FindAsync(id);
            var tr_trainer = await (from trainer in _context.tr_trainer
                            join data in  _context.tb_employee on trainer.emp_no equals data.emp_no into z
                            from emp in z.DefaultIfEmpty()
                            select new { 
                                    trainer_no = trainer.trainer_no,
                                    emp_no = trainer.emp_no,
                                    title_name_en = trainer.title_name_en?? emp.title_name_en,
                                    firstname_en = trainer.firstname_en?? emp.firstname_en,
                                    lastname_en = trainer.lastname_en?? emp.lastname_en,
                                    div_abb = emp.div_abb,
                                    dept_abb = emp.dept_abb,
                                    organization = trainer.organization,
                                    employed_status = emp.employed_status,
                                    trainer_type = trainer.trainer_type,
                            })
                            .Where(trainer=>trainer.trainer_no==trainer_no)
                            .FirstOrDefaultAsync();

            /* var tr_trainer = await _context.tr_trainer
                    .Include(t => t.courses_trainers)
                    .Where(t => t.trainer_no==trainer_no)
                    .FirstOrDefaultAsync(); */

            if (tr_trainer == null)
            {
                return NotFound();
            }

            return Ok(tr_trainer);
        }

        // GET: api/Trainers/History
        [AllowAnonymous]
        [HttpGet("HistoryExcel")]
        public async Task<ActionResult<IEnumerable<tr_trainer>>> trainers_history_excel()
        {
            var tr_trainer = await (from trainer in _context.tr_trainer
            join data in  _context.tb_employee on trainer.emp_no equals data.emp_no into z
            from emp in z.DefaultIfEmpty()
            select new { 
                    trainer_no = trainer.trainer_no,
                    emp_no = trainer.emp_no,
                    title_name_en = trainer.title_name_en?? emp.title_name_en,
                    firstname_en = trainer.firstname_en?? emp.firstname_en,
                    lastname_en = trainer.lastname_en?? emp.lastname_en,
                    div_abb = emp.div_abb,
                    dept_abb = emp.dept_abb,
                    organization = trainer.organization,
                    employed_status = emp.employed_status,
                    trainer_type = trainer.trainer_type,
                    courses_trainers = trainer.courses_trainers
            })
            .ToListAsync();

            var time = DateTime.Now.ToString("yyyyMMddHHmmss");
            var fileName = $"Trainer_History_{time}.xlsx";
            var filepath = $"wwwroot/excel/Trainer_History/{fileName}";
            var originalFileName = $"Trainer_History.xlsx";
            var originalFilePath = $"wwwroot/excel/Trainer_History/{originalFileName}";

            using(var package = new ExcelPackage(new FileInfo(originalFilePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["trainer_history"];
        
                worksheet.Cells[1, 1].Value = "Trainer History"; 

                worksheet.Cells[2, 1].Value = "TRAINER NO"; 
                worksheet.Cells[2, 2].Value = "TITLE NAME"; 
                worksheet.Cells[2, 3].Value = "FIRSTNAME"; 
                worksheet.Cells[2, 4].Value = "LASTNAME"; 
                worksheet.Cells[2, 5].Value = "ORGANIZATION"; 
                worksheet.Cells[2, 6].Value = "DIVISION"; 
                worksheet.Cells[2, 7].Value = "DEPARTMENT"; 
                worksheet.Cells[2, 8].Value = "TRAINER TYPE"; 
                worksheet.Cells[2, 9].Value = "COURSE NO"; 
                worksheet.Cells[2, 10].Value = "THAI COURSE NAME"; 
                worksheet.Cells[2, 11].Value = "ENGLISH COURSE NAME"; 
                worksheet.Cells[2, 12].Value = "DATE START"; 
                worksheet.Cells[2, 13].Value = "DATE END"; 
                worksheet.Cells[2, 14].Value = "PLACE"; 
                
                int recordIndex = 3; 
                foreach (var i in tr_trainer) 
                { 
                    worksheet.Cells[recordIndex, 1].Value = i.trainer_no; 
                    worksheet.Cells[recordIndex, 2].Value = i.title_name_en;
                    worksheet.Cells[recordIndex, 3].Value = i.firstname_en;
                    worksheet.Cells[recordIndex, 4].Value = i.lastname_en; 
                    worksheet.Cells[recordIndex, 5].Value = i.organization; 
                    worksheet.Cells[recordIndex, 6].Value = i.div_abb; 
                    worksheet.Cells[recordIndex, 7].Value = i.dept_abb; 
                    worksheet.Cells[recordIndex, 8].Value = i.trainer_type;
                    if(i.courses_trainers.Count()>0){
                        var trainer_courses = await _context.tr_trainer
                                .Include(t => t.courses_trainers)
                                .ThenInclude(e => e.courses)
                                .AsNoTracking()
                                .Where(t => t.trainer_no==i.trainer_no)
                                .FirstOrDefaultAsync();
                        foreach (var j in trainer_courses.courses_trainers) {
                            worksheet.Cells[recordIndex, 9].Value = j.courses.course_no;
                            worksheet.Cells[recordIndex, 10].Value = j.courses.course_name_th;
                            worksheet.Cells[recordIndex, 11].Value = j.courses.course_name_en;
                            worksheet.Cells[recordIndex, 12].Value = j.courses.date_start;
                            worksheet.Cells[recordIndex, 12].Style.Numberformat.Format = "yyyy-mm-dd";
                            worksheet.Cells[recordIndex, 13].Value = j.courses.date_end;
                            worksheet.Cells[recordIndex, 13].Style.Numberformat.Format = "yyyy-mm-dd";
                            worksheet.Cells[recordIndex, 14].Value = j.courses.place;
                            recordIndex++; 
                        }
                    }
                    else{
                        recordIndex++; 
                    }
                } 
                package.SaveAs(new FileInfo(filepath));
                package.Dispose();
            }  

            byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
            return File(fileBytes, "application/x-msdownload", fileName); 
        }
        
        // GET: api/Trainers/History/5
        [HttpGet("History/{trainer_no}")]
        public async Task<ActionResult<tr_trainer>> trainer_history(int trainer_no)
        {
            var tr_trainer = await _context.tr_trainer
                                .Include(t => t.courses_trainers)
                                .ThenInclude(e => e.courses)
                                .AsNoTracking()
                                .Where(t => t.trainer_no==trainer_no)
                                .FirstOrDefaultAsync();

            if (tr_trainer == null)
            {
                return NotFound();
            }

            return tr_trainer;
        }

        // GET: api/Trainers/HistoryExcel/1
        [AllowAnonymous]
        [HttpGet("HistoryExcel/{trainer_no}")]
        public async Task<ActionResult<IEnumerable<tr_trainer>>> trainer_history_excel(int trainer_no)
        {
            var trainer_courses = await _context.tr_trainer
                                .Include(t => t.courses_trainers)
                                .ThenInclude(e => e.courses)
                                .AsNoTracking()
                                .Where(t => t.trainer_no==trainer_no)
                                .FirstOrDefaultAsync();

            var trainer_info = await (from trainer in _context.tr_trainer
                            join data in  _context.tb_employee on trainer.emp_no equals data.emp_no into z
                            from emp in z.DefaultIfEmpty()
                            select new { 
                                    trainer_no = trainer.trainer_no,
                                    emp_no = trainer.emp_no,
                                    title_name_en = trainer.title_name_en?? emp.title_name_en,
                                    firstname_en = trainer.firstname_en?? emp.firstname_en,
                                    lastname_en = trainer.lastname_en?? emp.lastname_en,
                                    div_abb = emp.div_abb,
                                    dept_abb = emp.dept_abb,
                                    organization = trainer.organization,
                                    employed_status = emp.employed_status,
                                    trainer_type = trainer.trainer_type,
                            })
                            .Where(trainer=>trainer.trainer_no==trainer_no)
                            .FirstOrDefaultAsync();

            // return Ok(trainer_courses);

            var time = DateTime.Now.ToString("yyyyMMddHHmmss");
            var fileName = $"Trainer_History_{time}_{trainer_no}.xlsx";
            var filepath = $"wwwroot/excel/Trainer_History/{fileName}";
            var originalFileName = $"Trainer_History.xlsx";
            var originalFilePath = $"wwwroot/excel/Trainer_History/{originalFileName}";

            Console.WriteLine(originalFilePath);
            Console.WriteLine(filepath);

            using(var package = new ExcelPackage(new FileInfo(originalFilePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["trainer_history"];
        
                worksheet.Cells[1, 1].Value = $"Trainer History {trainer_info.firstname_en} {trainer_info.lastname_en}"; 

                worksheet.Cells[2, 1].Value = "TRAINER NO"; 
                worksheet.Cells[2, 2].Value = "TITLE NAME"; 
                worksheet.Cells[2, 3].Value = "FIRSTNAME"; 
                worksheet.Cells[2, 4].Value = "LASTNAME"; 
                worksheet.Cells[2, 5].Value = "ORGANIZATION"; 
                worksheet.Cells[2, 6].Value = "DIVISION"; 
                worksheet.Cells[2, 7].Value = "DEPARTMENT"; 
                worksheet.Cells[2, 8].Value = "TRAINER TYPE"; 
                worksheet.Cells[2, 9].Value = "COURSE NO"; 
                worksheet.Cells[2, 10].Value = "THAI COURSE NAME"; 
                worksheet.Cells[2, 11].Value = "ENGLISH COURSE NAME"; 
                worksheet.Cells[2, 12].Value = "DATE START"; 
                worksheet.Cells[2, 13].Value = "DATE END"; 
                worksheet.Cells[2, 14].Value = "PLACE"; 
                
                int recordIndex = 3; 
                if(trainer_courses.courses_trainers.Count()>0){
                    foreach (var i in trainer_courses.courses_trainers) {
                        worksheet.Cells[recordIndex, 1].Value = trainer_info.trainer_no; 
                        worksheet.Cells[recordIndex, 2].Value = trainer_info.title_name_en;
                        worksheet.Cells[recordIndex, 3].Value = trainer_info.firstname_en;
                        worksheet.Cells[recordIndex, 4].Value = trainer_info.lastname_en; 
                        worksheet.Cells[recordIndex, 5].Value = trainer_info.organization; 
                        worksheet.Cells[recordIndex, 6].Value = trainer_info.div_abb; 
                        worksheet.Cells[recordIndex, 7].Value = trainer_info.dept_abb; 
                        worksheet.Cells[recordIndex, 8].Value = trainer_info.trainer_type;
                        worksheet.Cells[recordIndex, 9].Value = i.course_no;
                        worksheet.Cells[recordIndex, 10].Value = i.courses.course_name_en;
                        worksheet.Cells[recordIndex, 11].Value = i.courses.course_name_th;
                        worksheet.Cells[recordIndex, 12].Value = i.courses.date_start;
                        worksheet.Cells[recordIndex, 12].Style.Numberformat.Format = "yyyy-mm-dd";
                        worksheet.Cells[recordIndex, 13].Value = i.courses.date_end;
                        worksheet.Cells[recordIndex, 13].Style.Numberformat.Format = "yyyy-mm-dd";
                        worksheet.Cells[recordIndex, 14].Value = i.courses.place;
                        recordIndex++;                     
                    }                    
                }


                package.SaveAs(new FileInfo(filepath));
                package.Dispose();
            }  

            byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
            return File(fileBytes, "application/x-msdownload", fileName); 
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
                if (!trainer_exists(id))
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
            else if (tr_trainer.trainer_type=="External" && trainer_exists(tr_trainer.trainer_no)) 
            {
                _context.Entry(tr_trainer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                _context.tr_trainer.Add(tr_trainer);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Gettr_trainer", new { id = tr_trainer.trainer_no }, tr_trainer);                
            }
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

        private bool trainer_exists(int id)
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
            var query = await (
                from tb1 in _context.tr_trainer
                join tb2 in _context.tb_employee on tb1.emp_no equals tb2.emp_no into tb
                from table in tb.DefaultIfEmpty()
                where tb1.status_active == true
                select new { 
                    tb1.trainer_no, 
                    tb1.emp_no,
                    organization = ( tb1.organization != null ? tb1.organization : table.dept_abb),
                    lastname_en = ( tb1.lastname_en != null ? tb1.lastname_en : table.lastname_en),
                    firstname_en = ( tb1.firstname_en != null ? tb1.firstname_en : table.firstname_en),
                    title_name_en = ( tb1.title_name_en != null ? tb1.title_name_en : table.title_name_en),
                    tb1.trainer_type,
                    fulls = (
                        tb1.trainer_type == "Internal" ? 
                        table.title_name_en == null ? "" :
                        table.title_name_en== "MS." ? table.title_name_en + "." + table.firstname_en + " " + table.lastname_en.Substring(0,1) + ". (" + table.dept_abb + ")" 
                        : table.title_name_en + table.firstname_en + " " + table.lastname_en.Substring(0,1) + ". (" + table.dept_abb + ")" 
                        : tb1.title_name_en + tb1.firstname_en + " " + tb1.lastname_en.Substring(0,1) + "."
                    )
                }).OrderBy(x => x.firstname_en).ToListAsync();
                
            return Ok(query);
        }
        [AllowAnonymous]
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
                            title_name_en = worksheet.Cells[row, 3].Value==null ? null:worksheet.Cells[row, 3].Value.ToString().Trim(),
                            firstname_en = worksheet.Cells[row, 4].Value==null ? null:worksheet.Cells[row, 4].Value.ToString().Trim(),
                            lastname_en = worksheet.Cells[row, 5].Value==null ? null:worksheet.Cells[row, 5].Value.ToString().Trim(),
                            title_name_th = worksheet.Cells[row, 6].Value==null ? null:worksheet.Cells[row, 6].Value.ToString().Trim(),
                            firstname_th = worksheet.Cells[row, 7].Value==null ? null:worksheet.Cells[row, 7].Value.ToString().Trim(),
                            lastname_th = worksheet.Cells[row, 8].Value==null ? null:worksheet.Cells[row, 8].Value.ToString().Trim(),
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
