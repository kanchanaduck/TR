using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style; 
using OfficeOpenXml.Table;
using AngularFirst.Data;
using AngularFirst.Models;
using Microsoft.AspNetCore.Http;

namespace AngularFirst.Controllers
{
    public class MockController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MockController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<tb_menus>>> Menu()
        {
            string filePath = Path.Combine("./wwwroot/", $"Mockdata.xlsx");

            if(System.IO.File.Exists(filePath)){
                Console.WriteLine("File exists.");
                using(var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["tb_menus"];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;
                    for (int row = 2; row <= rowCount; row++){
                        _context.Add(new tb_menus
                        {
                            menu_name = worksheet.Cells[row, 2].Value.ToString().Trim()==null ? null:worksheet.Cells[row, 2].Value.ToString().Trim(),
                            parent_menu_code = worksheet.Cells[row, 3].Value==null?null:int.Parse(worksheet.Cells[row, 3].Value.ToString().Trim()),
                            description = worksheet.Cells[row, 4].Value==null?null:worksheet.Cells[row, 4].Value.ToString().Trim(),
                            url = worksheet.Cells[row, 5].Value==null?null:worksheet.Cells[row, 5].Value.ToString().Trim(),
                            updated_at = DateTime.Now,
                            updated_by= "014496",
                        });
                        await _context.SaveChangesAsync();
                    }
               }
            }
            return await _context.tb_menus
                            .Include(e => e.children)
                            .ToListAsync();  
        }
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
                        _context.Add(new tr_course_master
                        {
                            course_no = worksheet.Cells[row, 1].Value.ToString().Trim()==null ? null:worksheet.Cells[row, 2].Value.ToString().Trim(),
                            course_name_th = worksheet.Cells[row, 2].Value.ToString().Trim()==null ? null:worksheet.Cells[row, 2].Value.ToString().Trim(),
                            course_name_en = worksheet.Cells[row, 3].Value.ToString().Trim()==null ? null:worksheet.Cells[row, 3].Value.ToString().Trim(),
                            dept_abb_name = worksheet.Cells[row, 4].Value.ToString().Trim()==null ? null:worksheet.Cells[row, 4].Value.ToString().Trim(),
                            capacity = int.Parse(worksheet.Cells[row, 5].Value.ToString().Trim()),
                            prev_course_no = worksheet.Cells[row, 6].Value.ToString().Trim()==null ? null:worksheet.Cells[row, 6].Value.ToString().Trim(),
                            days = int.Parse(worksheet.Cells[row, 7].Value.ToString().Trim()),
                            category = worksheet.Cells[row, 8].Value.ToString().Trim()==null ? null:worksheet.Cells[row, 8].Value.ToString().Trim(),
                            level = worksheet.Cells[row, 9].Value.ToString().Trim()==null ? null:worksheet.Cells[row, 9].Value.ToString().Trim(),
                            created_at = DateTime.Now,
                            created_by = "014496",
                            updated_at = DateTime.Now,
                            updated_by = "014496",
                        });
                        await _context.SaveChangesAsync();
                    }
               }
            }
            return await _context.tr_course_master
                .Include(e=> e.course_masters_bands).ToListAsync();
        }    
        public async Task<ActionResult<IEnumerable<tr_course_master_band>>> CourseMasterBand()
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
                        _context.Add(new tr_course_master_band
                        {
                            course_no = worksheet.Cells[row, 1].Value.ToString().Trim()==null ? null:worksheet.Cells[row, 2].Value.ToString().Trim(),
                            band = worksheet.Cells[row, 2].Value.ToString().Trim()==null ? null:worksheet.Cells[row, 2].Value.ToString().Trim(),
                        });
                        await _context.SaveChangesAsync();
                    }
               }
            }
            return Ok("success");
        } 
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
                        // Console.WriteLine("1234 "+worksheet.Cells[row, 3].Value);
                        // Console.WriteLine("12345 "+worksheet.Cells[row, 3].Value.ToString().Trim()==null);
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