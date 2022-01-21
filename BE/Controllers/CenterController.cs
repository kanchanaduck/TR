using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularFirst.Data;
using AngularFirst.Models;

namespace AngularFirst.Controllers
{
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
            // return await _context.tr_center.ToListAsync();
            var f = await (from center in _context.tr_center
            join data in  _context.tb_employee on center.emp_no equals data.emp_no into z
            from emp in z.DefaultIfEmpty()
            select new { 
                    center_no = center.center_no,
                    emp_no = center.emp_no,
                    sname_en = emp.sname_eng,
                    gname_en = emp.gname_eng,
                    fname_en = emp.fname_eng,
                    div_abb_name = emp.div_abb_name,
                    dept_abb_name = emp.dept_abb_name,
                    employed_status = emp.employed_status,
                    postion_ename = emp.posn_ename
            }).ToListAsync();

            return Ok(f);
        }

        // GET: api/Center/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tr_center>> Gettr_center(int id)
        {
            var tr_center = await _context.tr_center.FindAsync(id);

            if (tr_center == null)
            {
                return NotFound();
            }

            return tr_center;
        }

        // PUT: api/Center/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttr_center(int id, tr_center tr_center)
        {
            if (id != tr_center.center_no)
            {
                return BadRequest();
            }

            _context.Entry(tr_center).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tr_centerExists(id))
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

        // POST: api/Center
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tr_center>> Posttr_center(tr_center tr_center)
        {
            _context.tr_center.Add(tr_center);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettr_center", new { id = tr_center.center_no }, tr_center);
        }

        // DELETE: api/Center/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetr_center(int id)
        {
            var tr_center = await _context.tr_center.FindAsync(id);
            if (tr_center == null)
            {
                return NotFound();
            }

            _context.tr_center.Remove(tr_center);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tr_centerExists(int id)
        {
            return _context.tr_center.Any(e => e.center_no == id);
        }
    }
}
