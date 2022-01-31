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
    public class BandsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Bands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tb_band>>> Gettb_band()
        {
            return await _context.tb_band.ToListAsync();
        }

        // GET: api/Bands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tb_band>> Gettb_band(string id)
        {
            var tb_band = await _context.tb_band.FindAsync(id);

            if (tb_band == null)
            {
                return NotFound();
            }

            return tb_band;
        }

        // PUT: api/Bands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttb_band(string id, tb_band tb_band)
        {
            if (id != tb_band.band)
            {
                return BadRequest();
            }

            _context.Entry(tb_band).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_bandExists(id))
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

        // POST: api/Bands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tb_band>> Posttb_band(tb_band tb_band)
        {
            _context.tb_band.Add(tb_band);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tb_bandExists(tb_band.band))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Gettb_band", new { id = tb_band.band }, tb_band);
        }

        // DELETE: api/Bands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetb_band(string id)
        {
            var tb_band = await _context.tb_band.FindAsync(id);
            if (tb_band == null)
            {
                return NotFound();
            }

            _context.tb_band.Remove(tb_band);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tb_bandExists(string id)
        {
            return _context.tb_band.Any(e => e.band == id);
        }
        [HttpGet("Mock")]
        public async Task<IActionResult> Mock()
        {
            _context.tb_band.Add(new tb_band { band = "E" });
            _context.tb_band.Add(new tb_band { band = "J1" });
            _context.tb_band.Add(new tb_band { band = "J2" });
            _context.tb_band.Add(new tb_band { band = "J3" });
            _context.tb_band.Add(new tb_band { band = "J4" });
            _context.tb_band.Add(new tb_band { band = "M1" });
            _context.tb_band.Add(new tb_band { band = "M2" });
            _context.tb_band.Add(new tb_band { band = "JP" });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
