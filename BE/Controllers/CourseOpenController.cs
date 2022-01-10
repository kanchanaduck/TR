using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularFirst.Data;
using AngularFirst.Models;
// using AngularFirst.request;

namespace AngularFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseOpenController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseOpenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CourseOpen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tr_course>>> Gettr_course()
        {
            return await _context.tr_course.ToListAsync();
        }

        // GET: api/CourseOpen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tr_course>> Gettr_course(string id)
        {
            var tr_course = await _context.tr_course.FindAsync(id);

            if (tr_course == null)
            {
                return NotFound();
            }

            return tr_course;
        }

        // PUT: api/CourseOpen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttr_course(string id, tr_course tr_course)
        {
            if (id != tr_course.course_no)
            {
                return BadRequest();
            }

            _context.Entry(tr_course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tr_courseExists(id))
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

        // POST: api/CourseOpen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tr_course>> Posttr_course(tr_course tr_course)
        {
            _context.tr_course.Add(tr_course);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tr_courseExists(tr_course.course_no))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Gettr_course", new { id = tr_course.course_no }, tr_course);
        }

        // DELETE: api/CourseOpen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetr_course(string id)
        {
            var tr_course = await _context.tr_course.FindAsync(id);
            if (tr_course == null)
            {
                return NotFound();
            }

            _context.tr_course.Remove(tr_course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tr_courseExists(string id)
        {
            return _context.tr_course.Any(e => e.course_no == id);
        }

        // // POST: api/CourseOpen/Search
        // [HttpPost("Search")]
        // public async Task<ActionResult<tr_course_master>> Search(request_keyword model)
        // {
        //     string kw = model.keyword;
        //     var result = await _context.tr_course_master.Where(x => x.course_no == kw).FirstOrDefaultAsync();
        //     //var result = await _context.tr_course_master.ToListAsync();
        //     if (result == null)
        //     {
        //         return NotFound();
        //     }

        //     return result;
        // }

        // GET: api/CourseOpen/Search
        [HttpGet("Search")]
        public async Task<ActionResult<tr_course_master>> Search(string course_no)
        {
            Console.WriteLine("Search: " + course_no);
            var tr_course_master = await _context.tr_course_master
                                        .Where(
                                        e => e.course_no == course_no
                                        ).FirstOrDefaultAsync();

            if (tr_course_master == null)
            {
                return NotFound();
            }

            return tr_course_master;
        }

        /* public async Task<ActionResult<IEnumerable<tr_course>>> Gettr_course()
        {
            return await _context.tr_course.ToListAsync();
        }
 */
    }
}

// .ToListAsync()
// .FirstOrDefaultAsync()