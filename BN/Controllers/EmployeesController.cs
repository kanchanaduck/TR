using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_hrgis.Data;
using api_hrgis.Models;
using System.IO;
using OfficeOpenXml;

namespace api_hrgis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tb_employee>>> GetEmployee()
        {
            return await _context.tb_employee
            // .Select(
            //     employed_status = (emp.resn_date <= DateTime.Today || emp.resn_date is not null) ? "Employed":"Resigned",
            // )
            .ToListAsync();
        }

        // GET: api/Employees/Update
        [HttpGet("Update")]
        public async Task<ActionResult<IEnumerable<tb_employee>>> UpdateFromHRMS()
        {
            return await _context.tb_employee.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tb_employee>> GetEmployees(string id)
        {
            var employees = await _context.tb_employee.FindAsync(id);

            if (employees == null)
            {
                return NotFound();
            }

            return employees;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployees(string id, tb_employee employees)
        {
            if (id != employees.emp_no)
            {
                return BadRequest();
            }

            _context.Entry(employees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(id))
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

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tb_employee>> PostEmployees(tb_employee employees)
        {
            _context.tb_employee.Add(employees);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeesExists(employees.emp_no))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployees", new { id = employees.emp_no }, employees);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployees(string id)
        {
            var employees = await _context.tb_employee.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            _context.tb_employee.Remove(employees);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeesExists(string id)
        {
            return _context.tb_employee.Any(e => e.emp_no == id);
        }
        [HttpGet("Mock")]
        public async Task<ActionResult<IEnumerable<tb_employee>>> Mock()
        {
            string filePath = Path.Combine("./wwwroot/", $"Mockdata.xlsx");

            if(System.IO.File.Exists(filePath)){
                Console.WriteLine("File exists.");
                using(var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["tb_employee"];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;
                    for (int row = 2; row <= rowCount; row++){
                        _context.Add(new tb_employee
                        {
                            old_emp_no = worksheet.Cells[row, 2].Value==null ? null:worksheet.Cells[row, 1].Value.ToString().Trim(),
                            emp_no = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            sname_eng = worksheet.Cells[row, 3].Value==null ? null:worksheet.Cells[row, 3].Value.ToString().Trim(),
                            gname_eng = worksheet.Cells[row, 4].Value==null ? null:worksheet.Cells[row, 4].Value.ToString().Trim(),
                            fname_eng = worksheet.Cells[row, 5].Value==null ? null:worksheet.Cells[row, 5].Value.ToString().Trim(),	
                            sname_tha = worksheet.Cells[row, 6].Value==null ? null:worksheet.Cells[row, 6].Value.ToString().Trim(),	
                            gname_tha = worksheet.Cells[row, 7].Value==null ? null:worksheet.Cells[row, 7].Value.ToString().Trim(),
                            fname_tha = worksheet.Cells[row, 8].Value==null ? null:worksheet.Cells[row, 8].Value.ToString().Trim(),	
                            div_cls = worksheet.Cells[row, 9].Value==null ? null:worksheet.Cells[row, 9].Value.ToString().Trim(),	
                            div_name = worksheet.Cells[row, 10].Value==null ? null:worksheet.Cells[row, 10].Value.ToString().Trim(),
                            div_abb_name = worksheet.Cells[row, 11].Value==null ? null:worksheet.Cells[row, 11].Value.ToString().Trim(),
                            dept_code = worksheet.Cells[row, 12].Value==null ? null:worksheet.Cells[row, 12].Value.ToString().Trim(),
                            dept_abb_name = worksheet.Cells[row, 13].Value==null ? null:worksheet.Cells[row, 13].Value.ToString().Trim(),
                            dept_name = worksheet.Cells[row, 14].Value==null ? null:worksheet.Cells[row, 14].Value.ToString().Trim(),
                            wc_code = worksheet.Cells[row, 15].Value==null ? null:worksheet.Cells[row, 15].Value.ToString().Trim(),
                            wc_abb_name = worksheet.Cells[row, 16].Value==null ? null:worksheet.Cells[row, 16].Value.ToString().Trim(),
                            wc_name	= worksheet.Cells[row, 17].Value==null ? null:worksheet.Cells[row, 17].Value.ToString().Trim(),
                            band = worksheet.Cells[row, 18].Value==null ? null:worksheet.Cells[row, 18].Value.ToString().Trim(),
                            posn_code = worksheet.Cells[row, 19].Value==null ? null:worksheet.Cells[row, 19].Value.ToString().Trim(),
                            posn_ename = worksheet.Cells[row, 20].Value==null ? null:worksheet.Cells[row, 20].Value.ToString().Trim(),
                            email = worksheet.Cells[row, 21].Value==null ? null:worksheet.Cells[row, 21].Value.ToString().Trim(),
                            resn_date = worksheet.Cells[row, 22].Value==null ? null:DateTime.Parse(worksheet.Cells[row, 22].Value.ToString().Trim()),
                            prob_date = worksheet.Cells[row, 23].Value==null ? null:DateTime.Parse(worksheet.Cells[row, 23].Value.ToString().Trim()),
                        });
                        await _context.SaveChangesAsync();
                    }
               }
            }
            return await _context.tb_employee
                            .ToListAsync();  
        }
    }
}
