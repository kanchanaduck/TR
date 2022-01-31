using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using api_hrgis.Data;
using api_hrgis.Models;
using api_hrgis.Repository;

namespace api_hrgis.Controllers
{
    [Authorize] // Microsoft.AspNetCore.Authorization // [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository _repository;

        public AccountController(ApplicationDbContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tb_user>>> Gettb_user()
        {
            return await _context.tb_user.ToListAsync();
        }

        // GET: api/Account/5
        [HttpGet("{username}")]
        public async Task<ActionResult<tb_user>> Gettb_user(string username)
        {
            var tb_user = await _context.tb_user.Where(x => x.username == username).FirstOrDefaultAsync();

            if (tb_user == null)
            {
                return NotFound();
            }

            return tb_user;
        }

        // PUT: api/Account/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{username}")]
        public async Task<IActionResult> Puttb_user(string username, tb_user tb_user)
        {
            if (username != tb_user.username)
            {
                return BadRequest();
            }

            _context.Entry(tb_user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_userExists(username))
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

        // DELETE: api/Account/5
        [HttpDelete("{username}")]
        public async Task<IActionResult> Deletetb_user(string username)
        {
            var tb_user = await _context.tb_user.Where(x => x.username == username).FirstOrDefaultAsync();
            if (tb_user == null)
            {
                return NotFound();
            }

            _context.tb_user.Remove(tb_user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tb_userExists(string username)
        {
            return _context.tb_user.Any(e => e.username == username);
        }

        // POST: api/Account/Registers
        [AllowAnonymous]
        [HttpPost("Registers")]
        public async Task<ActionResult<tb_user>> Registers(InputModel Input)
        {
            if (Input.password != Input.confirmpassword)
            {
                return Conflict("The password and confirmation password do not match.");
            }

            var tb_user = await _context.tb_user.Where(x => x.username == Input.username).FirstOrDefaultAsync();
            if (tb_user != null)
            {
                return Conflict();
            }

            tb_user tb = new tb_user();
            tb.username = Input.username;
            tb.email = Input.email;
            tb.emailconfirmed = true;
            var hashsalt = _repository.EncryptPassword(Input.password);
            tb.passwordhash = hashsalt.Hash;
            tb.storedsalt = hashsalt.Salt;
            tb.phonenumber = Input.phonenumber;
            tb.phonenumberconfirmed = true;

            _context.tb_user.Add(tb);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { Input });
            }
            catch (DbUpdateException)
            {
                if (tb_userExists(Input.username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
        }

    }
}

public class InputModel
{
    [Required]
    public string username { get; set; }
    [EmailAddress]
    public string email { get; set; }
    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string password { get; set; }
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    public string confirmpassword { get; set; }
    public string phonenumber { get; set; }
}