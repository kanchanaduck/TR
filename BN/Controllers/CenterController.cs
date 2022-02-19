using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_hrgis.Data;
using api_hrgis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
namespace api_hrgis.Controllers
{
    [Authorize]
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class CenterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CenterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Center
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tr_center>>> Gettr_center()
        {
            var f = await (from center in _context.tr_center
            join data in  _context.tb_employee on center.emp_no equals data.emp_no into z
            from emp in z.DefaultIfEmpty()
            select new { 
                    emp_no = center.emp_no,
                    title_name_en = emp.title_name_en,
                    firstname_en = emp.firstname_en,
                    lastname_en = emp.lastname_en,
                    position_name_en = emp.position_name_en,
                    div_abb = emp.div_abb,
                    dept_abb = emp.dept_abb,
                    employed_status = emp.employed_status,
            }).ToListAsync();

            return Ok(f);
        }

        // GET: api/Center/014496
        [HttpGet("{emp_no}")]
        public async Task<ActionResult<tr_center>> Gettr_center(string emp_no)
        {
            var tr_center = await _context.tr_center.FindAsync(emp_no);

            // var tr_center = await _context.tr_center.Where(e => e.emp_no == emp_no).FirstOrDefaultAsync();

            if (tr_center == null)
            {
                return NotFound();
            }

            return tr_center;
        }

        // POST: api/Center
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkemp_no=2123754
        [HttpPost]
        public async Task<ActionResult<tr_center>> Posttr_center(tr_center tr_center)
        {
            if (center_exists(tr_center.emp_no))
            {
                return Conflict("Data is alredy exists");
            }

            if(!center_is_in_employees(tr_center.emp_no))
            {
                return NotFound("Not found this employee");
            }

            _context.tr_center.Add(tr_center);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettr_center", new { emp_no = tr_center.emp_no }, tr_center);
        }

        // DELETE: api/Center/5
        [HttpDelete("{emp_no}")]
        public async Task<IActionResult> Deletetr_center(string emp_no)
        {
            var tr_center = await _context.tr_center.FindAsync(emp_no);
            if (tr_center == null)
            {
                return NotFound();
            }

            _context.tr_center.Remove(tr_center);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool center_exists(string emp_no)
        {
            return _context.tr_center.Any(e => e.emp_no == emp_no);
        }
        private bool center_is_in_employees(string emp_no)
        {
            return _context.tb_employee.Any(e => e.emp_no == emp_no);
        }
        private bool user_is_center(string emp_no)
        {
            return _context.tr_center.Any(e => e.emp_no == emp_no);
        }

    }
}