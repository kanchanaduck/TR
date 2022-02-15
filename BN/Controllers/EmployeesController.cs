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
using Microsoft.AspNetCore.Authorization;

namespace api_hrgis.Controllers
{
    [Authorize]
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
            return await _context.tb_employee.ToListAsync();
        }

        // GET: api/Employees/Course
        [HttpGet("Course/{org_code}/{employed_status}")]
        public async Task<ActionResult<IEnumerable<tb_employee>>> course_map(string org_code, string employed_status)
        {
            // return await _context.tb_employee.ToListAsync();
            if(employed_status == "employed"){
                return await _context.tb_employee
                            .Include(e => e.courses_registrations)
                            .Where(e => (e.div_cls==org_code || e.dept_code.Contains(org_code)) && (e.resn_date==null ||e.resn_date < DateTime.Today))
                            .ToListAsync();
            }
            else{
                return await _context.tb_employee
                            .Include(e => e.courses_registrations)
                            .Where(e => (e.div_cls==org_code || e.dept_code.Contains(org_code)) && (e.resn_date > DateTime.Today))
                            .ToListAsync();
            }
        }

        // GET: api/Employees/Organization/55
        // GET: api/Employees/Organization/5510
        [HttpGet("Organization/{org_code}")]
        public async Task<ActionResult<IEnumerable<tb_employee>>> GetEmployeeDivision(string org_code)
        {
            var employees =  await _context.tb_employee
                             .Where(e => e.div_abb_name==org_code ||
                             e.dept_code==org_code).ToListAsync();

            if (employees == null)
            {
                return NotFound("Data not found");
            }

            return employees;
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
                return NotFound("Data not found");
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
                return NotFound("Data not found");
            }

            _context.tb_employee.Remove(employees);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeesExists(string id)
        {
            return _context.tb_employee.Any(e => e.emp_no == id);
        }
        [AllowAnonymous]
        [HttpGet("Mock")]
        public async Task<ActionResult<IEnumerable<tb_employee>>> Mock()
        {
            var itemsToDelete = _context.Set<tb_employee>();
            _context.tb_employee.RemoveRange(itemsToDelete);
            _context.SaveChanges();

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
