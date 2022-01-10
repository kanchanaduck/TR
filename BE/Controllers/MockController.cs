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
        public async Task<IActionResult> Excel()
        {
            string filePath = Path.Combine("./wwwroot/", $"Mockdata.xlsx");

            if(System.IO.File.Exists(filePath)){
                Console.WriteLine("File exists.");
                using(var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    await _context.SaveChangesAsync();
                    /* ExcelWorksheet worksheet = package.Workbook.Worksheets["tr_course_master"];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;
                    for (int row = 2; row <= rowCount; row++){
                        _context.Add(new tr_course_master
                        {
                            prd_code = worksheet.Cells[row, 4].Value.ToString().Trim(),
                            prd_inqty = int.Parse(worksheet.Cells[row, 10].Value.ToString().Trim()),
                            in_datetime = DateTime.Now,
                            in_name = HttpContext.Session.GetString("_Name"),
                        });
                        await _context.SaveChangesAsync();
                    }

                    ExcelWorksheet worksheet = package.Workbook.Worksheets["tr_course_master_band"];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;
                    for (int row = 2; row <= rowCount; row++){
                        _context.Add(new tr_course_master_band
                        {
                            prd_code = worksheet.Cells[row, 4].Value.ToString().Trim(),
                            prd_inqty = int.Parse(worksheet.Cells[row, 10].Value.ToString().Trim()),
                            in_datetime = DateTime.Now,
                            in_name = HttpContext.Session.GetString("_Name"),
                        });
                        await _context.SaveChangesAsync();
                    }

                    ExcelWorksheet worksheet = package.Workbook.Worksheets["tr_trainer"];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;
                    for (int row = 2; row <= rowCount; row++){
                        _context.Add(new tr_course_master
                        {
                            prd_code = worksheet.Cells[row, 4].Value.ToString().Trim(),
                            prd_inqty = int.Parse(worksheet.Cells[row, 10].Value.ToString().Trim()),
                            in_datetime = DateTime.Now,
                            in_name = HttpContext.Session.GetString("_Name"),
                        });
                        await _context.SaveChangesAsync();
                    } */

                }
            }


            return Ok();
        }
    }
}