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

namespace api_hrgis.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StakeholderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StakeholderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Stakeholder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tb_organization>>> Gettr_stakeholder()
        {
            // return await _context.tr_stakeholder.ToListAsync();
            return await _context.tb_organization
                            .Include(e => e.parent_org)
                            .Include(e => e.stakeholders)
                            .ThenInclude(p => p.employee)
                            .Where(e => e.level_name=="department" || e.level_name=="division")
                            .ToListAsync();
        }

        // GET: api/Stakeholder/55
        // GET: api/Stakeholder/5510
        [HttpGet("{org_code}")]
        public async Task<ActionResult<tb_organization>> get_stakeholder_by_org_code(string org_code)
        {
            var tr_stakeholder = await _context.tb_organization
                                    .Include(e => e.stakeholders)
                                    .ThenInclude(p => p.employee)
                                    .Where(e => e.org_code==org_code)
                                    .FirstOrDefaultAsync();

            if (tr_stakeholder == null)
            {
                return NotFound();
            }

            return tr_stakeholder;
        }

        // GET: api/Stakeholder/Org/CPD
        // GET: api/Stakeholder/Org/ICD
        [HttpGet("Org/{org_abb}")]
        public async Task<ActionResult<tb_organization>> get_stakeholder_by_organization(string org_abb)
        {
            var tr_stakeholder = await _context.tb_organization
                                    .Include(e => e.stakeholders)
                                    .ThenInclude(p => p.employee)
                                    .Where(e => e.org_abb==org_abb)
                                    .FirstOrDefaultAsync();

            if (tr_stakeholder == null)
            {
                return NotFound();
            }

            return tr_stakeholder;
        }

        // GET: api/Stakeholder/Employee/000001
        [HttpGet("Employee/{emp_no}")]
        public async Task<ActionResult<tr_stakeholder>> get_stakeholder_by_emp_no(string emp_no)
        {
            var tr_stakeholder = await _context.tr_stakeholder
                                    .Include(e => e.organization)
                                    .ThenInclude(p => p.parent_org)
                                    .ThenInclude(p => p.children_org)
                                    .Where(e => e.emp_no == emp_no) 
                                    .FirstOrDefaultAsync();

            if (tr_stakeholder == null)
            {
                return NotFound();
            }

            return tr_stakeholder;
        }

        // PUT: api/Stakeholder/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{emp_no}")]
        public async Task<IActionResult> Puttr_stakeholder(string emp_no, string org_code, string role, tr_stakeholder tr_stakeholder)
        {
            if (emp_no != tr_stakeholder.emp_no)
            {
                return BadRequest();
            }

            _context.Entry(tr_stakeholder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!stakeholder_exists(emp_no, org_code, role))
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

        // POST: api/Stakeholder/Reset/55
        // POST: api/Stakeholder/Reset/5510
        [HttpPost("Reset/{org_code}")]
        public async Task<ActionResult<tr_stakeholder>> reset_stakeholder(String org_code)
        {
            var stakeholder = await _context.tr_stakeholder
                            .Where(e => e.org_code==org_code)
                            .ToListAsync();

            if (stakeholder == null)
            {
                return NotFound();
            }

            _context.tr_stakeholder.RemoveRange(stakeholder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Stakeholder
        [HttpPost]
        public async Task<ActionResult<tr_stakeholder>> Posttr_stakeholder(List<tr_stakeholder> tr_stakeholder)
        {
            String error_text = "";

            if(tr_stakeholder.Count()>0){

                var stakeholder = await _context.tr_stakeholder
                            .Where(e => e.org_code==tr_stakeholder[0].org_code)
                            .ToListAsync();
                _context.tr_stakeholder.RemoveRange(stakeholder);
                await _context.SaveChangesAsync();

                foreach(var a in tr_stakeholder){
                    if (stakeholder_exists(a.emp_no, a.org_code, a.role)){
                        error_text = error_text+$"{ErrorStakeholder(a.emp_no, a.org_code, a.role)}\n";
                    }
                    else{
                        Console.WriteLine("Not exists");
                        _context.tr_stakeholder.Add(a);
                    }
                }                
                await _context.SaveChangesAsync();
            }

            if (error_text!=""){
                return Conflict(error_text);
            }

            return CreatedAtAction("Gettr_stakeholder", new { e = tr_stakeholder }, tr_stakeholder);
        }

        // DELETE: api/Stakeholder/014496
       /*  [HttpDelete("{emp_no}")]
        public async Task<IActionResult> Deletetr_stakeholder(string emp_no)
        {
            var tr_stakeholder = await _context.tr_stakeholder.FindAsync(emp_no);
            if (tr_stakeholder == null)
            {
                return NotFound();
            }

            _context.tr_stakeholder.Remove(tr_stakeholder);
            await _context.SaveChangesAsync();

            return NoContent();
        } */

        private bool stakeholder_exists(string emp_no, string org_code, string role)
        {
            return _context.tr_stakeholder.Any(e => e.emp_no == emp_no 
                        && e.org_code==org_code
                        && e.role==role);
        }
        private string ErrorStakeholder(string emp_no, string org_code, string role)
        {
            return $"Employee no. {emp_no} in Organization {org_code} and role {role} is already exists";
        }
    }
}
