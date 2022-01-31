using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularFirst.Data;
using AngularFirst.Models;
using Microsoft.AspNetCore.Cors;

namespace AngularFirst.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrganizationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Organization
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tb_organization>>> Gettb_organization()
        {
            return await _context.tb_organization
                            .Include(e => e.children_org)
                            .Include(e => e.parent_org)
                            .ToListAsync();
        }

        // GET: api/Organization/Level/Division
        // GET: api/Organization/Level/Department
        [HttpGet("Level/{level}")]
        public async Task<ActionResult<IEnumerable<tb_organization>>> GetFromLevel(string level)
        {
            return await _context.tb_organization
                            .Include(e => e.children_org)
                            .Include(e => e.parent_org)
                            .Where(c => c.level_name.ToUpper().Contains(level.ToUpper()))
                            .ToListAsync();
        }

        // GET: api/Organization/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tb_organization>> Gettb_organization(string id)
        {
            var tb_organization = await _context.tb_organization.FindAsync(id);

            if (tb_organization == null)
            {
                return NotFound();
            }

            return tb_organization;
        }

        // PUT: api/Organization/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttb_organization(string id, tb_organization tb_organization)
        {
            if (id != tb_organization.org_code)
            {
                return BadRequest();
            }

            _context.Entry(tb_organization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_organizationExists(id))
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

        // POST: api/Organization
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tb_organization>> Posttb_organization(tb_organization tb_organization)
        {
            _context.tb_organization.Add(tb_organization);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tb_organizationExists(tb_organization.org_code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Gettb_organization", new { id = tb_organization.org_code }, tb_organization);
        }

        // DELETE: api/Organization/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetb_organization(string id)
        {
            var tb_organization = await _context.tb_organization.FindAsync(id);
            if (tb_organization == null)
            {
                return NotFound();
            }

            _context.tb_organization.Remove(tb_organization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tb_organizationExists(string id)
        {
            return _context.tb_organization.Any(e => e.org_code == id);
        }
    }
}
