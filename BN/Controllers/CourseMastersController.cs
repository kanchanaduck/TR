using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using api_hrgis.Data;
using api_hrgis.Models;
using System.IO;
using OfficeOpenXml;

namespace api_hrgis.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseMastersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseMastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CourseMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tr_course_master>>> Gettr_course_master()
        {
            return await _context.tr_course_master
                        .Include(e => e.course_masters_bands)
                        .Include(e => e.prev_course)
                        .Include(e => e.next_course)
                        .ToListAsync();
        }

        // GET: api/CourseMasters/{course_no}
        [HttpGet("{course_no}")]
        public async Task<ActionResult<tr_course_master>> Search(string course_no)
        {
            var tr_course_master = await _context.tr_course_master
                                        .Include(e => e.course_masters_bands)
                                        .Include(e => e.prev_course)
                                        .Where(e => e.course_no == course_no)
                                        .FirstOrDefaultAsync();

            if (tr_course_master == null)
            {
                return NotFound();
            }

            return tr_course_master;
        }

        // GET: api/CourseMasters/SearchCourse/{course_no}/{org_abb}
        [HttpGet("SearchCourse/{course_no}/{org_abb}")]
        public async Task<ActionResult<tr_course_master>> SearchCourse(string course_no, string org_abb)
        {

            /* var tr_course_master = await _context.tr_course_master
                                    .Include(e => e.course_masters_bands)
                                    .Where(e => e.course_no == course_no &&
                                    e.dept_abb_name == org_abb_name)
                                    .FirstOrDefaultAsync(); */
            
            /* var tr_course_master = await _context.tr_course_master
                                    // .Include(e => e.course_masters_bands)
                                    .Include(
                                        e => e.organization
                                        .Where(o => o.org_abb_name == org_abb_name)
                                        .Take(1))
                                    .Where(e => e.course_no == course_no)
                                    .ToListAsync(); */

            var tr_course_master = await _context.tr_course_master
         .Include(e => e.course_masters_bands)
         .Include(e => e.organization)
          .Where(e => e.course_no == course_no)
         .FirstOrDefaultAsync();

            if (tr_course_master == null)
            {
                return NotFound();
            }

            return tr_course_master;
        } 

        // PUT: api/CourseMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttr_course_master(string id, tr_course_master tr_course_master)
        {
            if (id != tr_course_master.course_no)
            {
                return BadRequest();
            }

            _context.Entry(tr_course_master).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!course_master_exists(id))
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

        // POST: api/CourseMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tr_course_master>> Posttr_course_master(tr_course_master tr_course_master)
        {
            if (course_master_exists(tr_course_master.course_no)){
                Console.WriteLine("COURSE EXIST");

                var course = await _context.tr_course_master
                                .Include(b => b.course_masters_bands)
                                .Where(b => b.course_no==tr_course_master.course_no)
                                .FirstOrDefaultAsync();

                var courses_bands = course.course_masters_bands.ToList();

                // foreach(var i in courses_bands){
                //     Console.WriteLine(i.band);
                // }

                // await course.course_masters_bands.Remove(courses_bands);
                // await _context.SaveChangesAsync();

                /* if(tr_course_master.course_masters_bands.Count() > 0) {                 
                    foreach(var i in tr_course_master.course_masters_bands){
                        course.course_masters_bands = new tr_course_masters_bands{  
                            course_no = tr_course_master.course_no,
                            band = i.band
                        };
                    }
                }  */  

                // _context.Entry(course).State = EntityState.Modified;
                // await _context.SaveChangesAsync();
                // return NoContent();
                            
                
                return Ok(courses_bands);
                // course.course_masters_bands.Remove(bands);
                // _context.SaveChanges();

                // _context.Entry(tr_course_master).State = EntityState.Modified;
                // return NoContent();
            }
            else{
                Console.WriteLine("ADD NEW COURSE");
                //Recheck ด้วยนะ
                _context.tr_course_master.Add(tr_course_master);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Gettr_course_master", new { id = tr_course_master.course_no }, tr_course_master);
            }
            // var cm = new tr_course_master
            // {
            //     course_no= "ICD-001",
            //     course_name_th= "ทดสอบครั้งแรก",
            //     dept_abb_name= "ICD",
            //     days= 2,
            //     course_masters_bands = new List<tr_course_master_band>
            //     {
            //         new tr_course_master_band { band = "E" },
            //         new tr_course_master_band { band = "J1" },
            //         new tr_course_master_band { band = "J2" },
            //     }
            // };

            // _context.tr_course_master.Add(cm);
            // _context.SaveChanges();
        }
        // DELETE: api/CourseMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetr_course_master(string id)
        {
            var tr_course_master = await _context.tr_course_master.FindAsync(id);
            if (tr_course_master == null)
            {
                return NotFound();
            }

            _context.tr_course_master.Remove(tr_course_master);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool course_master_exists(string course_no)
        {
            return _context.tr_course_master.Any(e => e.course_no == course_no);
        }
        [AllowAnonymous]
        [HttpGet("Mock")]
        public async Task<ActionResult<IEnumerable<tr_course_master>>> CourseMaster()
        {
            string filePath = Path.Combine("./wwwroot/", $"Mockdata.xlsx");

            if(System.IO.File.Exists(filePath)){
                Console.WriteLine("File exists.");
                using(var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["tr_course_master"];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;
                    for (int row = 2; row <= rowCount; row++){
                        Console.WriteLine("กาญจนา"+worksheet.Cells[row, 6].Value);
                        Console.WriteLine(worksheet.Cells[row, 6].Value==null? "Y":"N");
                        _context.Add(new tr_course_master
                        {
                            course_no = worksheet.Cells[row, 1].Value==null ? null:worksheet.Cells[row, 1].Value.ToString().Trim(),
                            course_name_th = worksheet.Cells[row, 2].Value==null ? null:worksheet.Cells[row, 2].Value.ToString().Trim(),
                            course_name_en = worksheet.Cells[row, 3].Value==null ? null:worksheet.Cells[row, 3].Value.ToString().Trim(),
                            org_code = worksheet.Cells[row, 4].Value==null ? null:worksheet.Cells[row, 4].Value.ToString().Trim(),
                            capacity = int.Parse(worksheet.Cells[row, 5].Value.ToString().Trim()),
                            prev_course_no = worksheet.Cells[row, 6].Value==null ? null:worksheet.Cells[row, 6].Value.ToString().Trim(),
                            days = int.Parse(worksheet.Cells[row, 7].Value.ToString().Trim()),
                            category = worksheet.Cells[row, 8].Value==null ? null:worksheet.Cells[row, 8].Value.ToString().Trim(),
                            level = worksheet.Cells[row, 9].Value==null ? null:worksheet.Cells[row, 9].Value.ToString().Trim(),
                            created_at = DateTime.Now,
                            created_by = "014496",
                            updated_at = DateTime.Now,
                            updated_by = "014496",
                            // status_active=true,
                        });
                        await _context.SaveChangesAsync();
                    }
               }
            }

            if(System.IO.File.Exists(filePath)){
                Console.WriteLine("File exists.");
                using(var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["tr_course_master_band"];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;
                    for (int row = 2; row <= rowCount; row++){
                        _context.Add(new tr_course_master_band
                        {
                            course_no = worksheet.Cells[row, 1].Value.ToString().Trim()==null ? null:worksheet.Cells[row, 1].Value.ToString().Trim(),
                            band = worksheet.Cells[row, 2].Value.ToString().Trim()==null ? null:worksheet.Cells[row, 2].Value.ToString().Trim(),
                        });
                        await _context.SaveChangesAsync();
                    }
               }
            }

            return await _context.tr_course_master
                .Include(e=> e.course_masters_bands).ToListAsync();
        } 
    }
}
