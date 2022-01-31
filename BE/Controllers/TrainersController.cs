using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularFirst.Data;
using AngularFirst.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace AngularFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TrainersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Trainers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tr_trainer>>> Gettr_trainer()
        {
            var f = await (from trainer in _context.tr_trainer
            join data in  _context.tb_employee on trainer.emp_no equals data.emp_no into z
            from emp in z.DefaultIfEmpty()
            select new { 
                    trainer_no = trainer.trainer_no,
                    emp_no = trainer.emp_no,
                    sname_en = trainer.sname_en?? emp.sname_eng,
                    gname_en = trainer.gname_en?? emp.gname_eng,
                    fname_en = trainer.fname_en?? emp.fname_eng,
                    div_abb_name = emp.div_abb_name,
                    dept_abb_name = emp.dept_abb_name,
                    organization = trainer.organization,
                    employed_status = emp.employed_status,
                    trainer_type = trainer.trainer_type
            }).ToListAsync();

            return Ok(f);
        }

        // GET: api/Trainers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tr_trainer>> Gettr_trainer(int id)
        {
            // var tr_trainer = await _context.tr_trainer.FindAsync(id);
            var tr_trainer = await (from trainer in _context.tr_trainer
            join data in  _context.tb_employee on trainer.emp_no equals data.emp_no into z
                        from emp in z.DefaultIfEmpty()
            select new { 
                    trainer_no = trainer.trainer_no,
                    emp_no = trainer.emp_no,
                    sname_en = trainer.sname_en?? emp.sname_eng,
                    gname_en = trainer.gname_en?? emp.gname_eng,
                    fname_en = trainer.fname_en?? emp.fname_eng,
                    div_abb_name = emp.div_abb_name,
                    dept_abb_name = emp.dept_abb_name,
                    organization = trainer.organization,
                    employed_status = emp.employed_status,
                    trainer_type = trainer.trainer_type
            })
            .Where(trainer => trainer.trainer_no == id)
            .SingleOrDefaultAsync();

            if (tr_trainer == null)
            {
                return NotFound();
            }

            return Ok(tr_trainer);
        }

        // PUT: api/Trainers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttr_trainer(int id, tr_trainer tr_trainer)
        {
            if (id != tr_trainer.trainer_no)
            {
                return BadRequest();
            }

            _context.Entry(tr_trainer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!trainer_exists(id))
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

        // POST: api/Trainers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tr_trainer>> Posttr_trainer(tr_trainer tr_trainer)
        {
            if (tr_trainer.trainer_type=="External")
            {
               if(trainer_exists(tr_trainer.trainer_no))
               {
                    Console.WriteLine("Update trainer");
                    _context.Entry(tr_trainer).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return NoContent();
               }
               else
               {
                    Console.WriteLine("External trainer add");
                    _context.tr_trainer.Add(tr_trainer);
                    await _context.SaveChangesAsync(); 
                    return CreatedAtAction("Gettr_trainer", new { id = tr_trainer.trainer_no }, tr_trainer);
               }
            }
            else
            {
                if(trainer_internal_exists(tr_trainer.emp_no))
                {
                    return Conflict("Internal trainer is prevented to create duplicate or update data.");
                }
                else
                {
                    Console.WriteLine("Internal trainer add");
                    _context.tr_trainer.Add(tr_trainer);
                    await _context.SaveChangesAsync(); 
                    return CreatedAtAction("Gettr_trainer", new { id = tr_trainer.trainer_no }, tr_trainer);
                }
            }
        }

        // DELETE: api/Trainers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetr_trainer(int id)
        {
            var tr_trainer = await _context.tr_trainer.FindAsync(id);
            if (tr_trainer == null)
            {
                return NotFound();
            }

            _context.tr_trainer.Remove(tr_trainer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool trainer_exists(int id)
        {
            return _context.tr_trainer.Any(e => e.trainer_no == id);
        }
        private bool trainer_internal_exists(string emp_no)
        {
            return _context.tr_trainer.Any(e => e.emp_no == emp_no);
        }
        public bool employee_exists(string emp_no)
        {
            return _context.tb_employee.Any(e => e.emp_no == emp_no);
        }
    }
}
