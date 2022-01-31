using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_hrgis.Data;
using api_hrgis.Models;

namespace api_hrgis.Controllers
{
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

        // GET: api/Stakeholder/ICD
        [HttpGet("{org_abb}")]
        public async Task<ActionResult<tb_organization>> Gettr_stakeholder(string org_abb)
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

        // PUT: api/Stakeholder/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttr_stakeholder(int id, tr_stakeholder tr_stakeholder)
        {
            if (id != tr_stakeholder.id)
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
                if (!tr_stakeholderExists(id))
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

        // POST: api/Stakeholder
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tr_stakeholder>> Posttr_stakeholder(tr_stakeholder[] tr_stakeholder)
        {
            _context.tr_stakeholder.Add(tr_stakeholder[0]);
            _context.tr_stakeholder.Add(tr_stakeholder[1]);
            /* _context.tr_stakeholder.Add(
                new tr_stakeholder { 
                    emp_no = tr_stakeholder.committee,
                    org_code = tr_stakeholder.org_code
                });

            _context.tr_stakeholder.Add(
                new tr_stakeholder { 
                    emp_no = tr_stakeholder.approver,
                    org_code = tr_stakeholder.org_code
                }); */
            
            await _context.SaveChangesAsync();
            return StatusCode(201);
            // return Created();

            // return CreatedAtAction("Gettr_stakeholder", new { id = tr_stakeholder.id }, tr_stakeholder);
        }

        // DELETE: api/Stakeholder/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetr_stakeholder(int id)
        {
            var tr_stakeholder = await _context.tr_stakeholder.FindAsync(id);
            if (tr_stakeholder == null)
            {
                return NotFound();
            }

            _context.tr_stakeholder.Remove(tr_stakeholder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tr_stakeholderExists(int id)
        {
            return _context.tr_stakeholder.Any(e => e.id == id);
        }
    }
}
