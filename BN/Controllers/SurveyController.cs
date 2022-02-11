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
    public class SurveyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SurveyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Survey
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tr_survey_setting>>> Gettr_survey_setting()
        {
            return await _context.tr_survey_setting.ToListAsync();
        }

        // GET: api/Survey/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tr_survey_setting>> Gettr_survey_setting(string id)
        {
            var tr_survey_setting = await _context.tr_survey_setting.FindAsync(id);

            if (tr_survey_setting == null)
            {
                return NotFound();
            }

            return tr_survey_setting;
        }

        // PUT: api/Survey/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttr_survey_setting(string id, tr_survey_setting tr_survey_setting)
        {
            if (id != tr_survey_setting.year)
            {
                return BadRequest();
            }

            _context.Entry(tr_survey_setting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tr_survey_settingExists(id))
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

        // POST: api/Survey
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tr_survey_setting>> Posttr_survey_setting(tr_survey_setting tr_survey_setting)
        {
            _context.tr_survey_setting.Add(tr_survey_setting);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tr_survey_settingExists(tr_survey_setting.year))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Gettr_survey_setting", new { id = tr_survey_setting.year }, tr_survey_setting);
        }

        // DELETE: api/Survey/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetr_survey_setting(string id)
        {
            var tr_survey_setting = await _context.tr_survey_setting.FindAsync(id);
            if (tr_survey_setting == null)
            {
                return NotFound();
            }

            _context.tr_survey_setting.Remove(tr_survey_setting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tr_survey_settingExists(string id)
        {
            return _context.tr_survey_setting.Any(e => e.year == id);
        }
    }
}
