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
    public class CourseMastersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseMastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CourseMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tr_course_master>>> Gettr_course_master()
        {
            return await _context.tr_course_master.ToListAsync();
        }

        // GET: api/CourseMasters/5
        [HttpGet("{course_no}")]
        public async Task<ActionResult<tr_course_master>> Gettr_course_master(string q)
        { 
            if(q==null){
                q="";
            }

            var tr_course_master = await _context.tr_course_master
                                        .Where(e=>e.course_no == q)
                                        .FirstOrDefaultAsync();

            if (tr_course_master == null)
            {
                return NotFound();
            }

            return tr_course_master;
        }

        // GET: api/CourseMasters/Search/{course_no}
        [HttpGet("Search")]
         public async Task<ActionResult<tr_course_master>> Search(string course_no)
        {
            Console.WriteLine("Search: "+course_no);
            var tr_course_master = await _context.tr_course_master
                                        .Where(
                                        e=> e.course_no == course_no
                                        ).FirstOrDefaultAsync();

            if (tr_course_master == null)
            {
                return NotFound();
            }

            return tr_course_master;
        }

        // GET: api/CourseMasters/SearchCourse/{course_no}
        [HttpPost("SearchCourse")]
         public async Task<ActionResult<tr_course_master>> SearchCourse(string course_no)
        {
            Console.WriteLine("Search: "+course_no);
            var tr_course_master = await _context.tr_course_master
                                        .Where(
                                        e=> e.course_no == course_no
                                        ).FirstOrDefaultAsync();

            if (tr_course_master == null)
            {
                return NotFound();
            }

            return tr_course_master;
        }


        // PUT: api/CourseMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttr_course_master(string id, tr_course_master tr_course_master)
        {
            if (id != tr_course_master.course_no)
            {
                return BadRequest();
            }

            _context.Entry(tr_course_master).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tr_course_masterExists(id))
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

        // POST: api/CourseMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tr_course_master>> Posttr_course_master(tr_course_master tr_course_master)
        {
            _context.tr_course_master.Add(tr_course_master);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tr_course_masterExists(tr_course_master.course_no))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Gettr_course_master", new { id = tr_course_master.course_no }, tr_course_master);
        }

        // DELETE: api/CourseMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetr_course_master(string id)
        {
            var tr_course_master = await _context.tr_course_master.FindAsync(id);
            if (tr_course_master == null)
            {
                return NotFound();
            }

            _context.tr_course_master.Remove(tr_course_master);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tr_course_masterExists(string id)
        {
            return _context.tr_course_master.Any(e => e.course_no == id);
        }
    }
}