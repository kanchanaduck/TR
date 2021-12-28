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
    public class MenusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Menus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menus>>> GetMenu()
        {
            // return await _context.Menu.ToListAsync();
            var menu = await _context.Menu
                            .Include(e => e.children)
                              .ThenInclude(c => c.children)
                              .Where(e => e.parent_menu_code == null)
                            .ToListAsync();      

            if (menu.Count <= 0)
            {
                return NotFound();
            }

            return menu;
        }

        // GET: api/Menus/children/<parent_menu_code>
        [HttpGet("children/{id}")]
        public async Task<ActionResult<IEnumerable<Menus>>> GetMenuChildren(string id)
        {
            var menu = await _context.Menu
                                .Include(e => e.children)
                                // .Where(x => !x.ParentId.HasValue)
                                    .Where(e => e.parent_menu_code == id )
                                .ToListAsync();
           
            if (menu.Count <= 0)
            {
                return NotFound();
            }

            return menu;
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menus>> GetMenus(string id)
        {
            var menus = await _context.Menu.FindAsync(id);

            if (menus == null)
            {
                return NotFound();
            }

            return menus;
        }

        // PUT: api/Menus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenus(string id, Menus menus)
        {
            if (id != menus.menu_code)
            {
                return BadRequest();
            }

            _context.Entry(menus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenusExists(id))
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

        // POST: api/Menus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Menus>> PostMenus(Menus menus)
        {
            _context.Menu.Add(menus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MenusExists(menus.menu_code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMenus", new { id = menus.menu_code }, menus);
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenus(string id)
        {
            var menus = await _context.Menu.FindAsync(id);
            if (menus == null)
            {
                return NotFound();
            }

            _context.Menu.Remove(menus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenusExists(string id)
        {
            return _context.Menu.Any(e => e.menu_code == id);
        }
    }
}
