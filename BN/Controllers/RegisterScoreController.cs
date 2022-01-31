using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using api_hrgis.Data;
using api_hrgis.Models;

namespace api_hrgis.Controllers
{
    [Authorize] // Microsoft.AspNetCore.Authorization; // [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterScoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegisterScoreController(ApplicationDbContext context)
        {
            _context = context;
        }

     /*     // GET: api/RegisterScore
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tr_course_score>>> Gettr_course_score()
        {
            // return await _context.tr_course_score.ToListAsync();
            return await _context.tr_course_score
                       .Include(e => e.courses)
                       .Include(e => e.employees)
                       .OrderBy(x => x.course_no).ThenBy(x => x.emp_no).ToListAsync();
        }

        // GET: api/RegisterScore/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tr_course_score>> Gettr_course_score(string id)
        {
            var tr_course_score = await _context.tr_course_score
                        .Include(e => e.courses)
                        .Include(e => e.employees)
                        .Where(e => e.course_no == id && e.created_by == User.FindFirst("emp_no").Value)
                        .OrderBy(x => x.emp_no).ToListAsync();

            if (tr_course_score.Count() < 0)
            {
                return NotFound();
            }

            return Ok(tr_course_score);
        }

        // POST: api/RegisterScore
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tr_course_score>> Posttr_course_score(req_tr_course_score model)
        {
            try
            {
                List<tr_course_score> list = new List<tr_course_score>();
                for (int i = 0; i < model.array.Count(); i++)
                {
                    var item = model.array[i];
                    tr_course_score tb = new tr_course_score();
                    tb.course_no = model.course_no;
                    tb.emp_no = item.emp_no;
                    tb.pre_test_score = item.pre_test_score;
                    tb.pre_test_grade = item.pre_test_grade;
                    tb.post_test_score = item.post_test_score;
                    tb.post_test_grade = item.post_test_grade;
                    tb.created_at = DateTime.Now;
                    tb.created_by = User.FindFirst("emp_no").Value;
                    list.Add(tb);
                }
                await _context.tr_course_score.AddRangeAsync(list);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tr_course_scoreExists(model.course_no))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Gettr_course_score", new { id = model.course_no }, model);
        }

        // DELETE: api/RegisterScore/5
        [HttpDelete("{course_no}/{emp_no}")]
        public async Task<IActionResult> Deletetr_course_score(string course_no, string emp_no)
        {
            var tr_course_score = await _context.tr_course_score.Where(x => x.course_no == course_no && x.emp_no == emp_no).FirstOrDefaultAsync();
            if (tr_course_score == null)
            {
                return NotFound();
            }

            _context.tr_course_score.Remove(tr_course_score);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tr_course_scoreExists(string id)
        {
            return _context.tr_course_score.Any(e => e.course_no == id);
        }*/
    }
} 

/* public class req_tr_course_score
{
    public string course_no { get; set; }
    public List<array_tr_course_score> array { get; set; }
}

public class array_tr_course_score
{
    public string emp_no { get; set; }
    public int pre_test_score { get; set; }
    public char pre_test_grade { get; set; }
    public int post_test_score { get; set; }
    public char post_test_grade { get; set; }
} */