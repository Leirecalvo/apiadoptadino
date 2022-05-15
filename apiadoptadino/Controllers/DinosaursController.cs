using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiadoptadino.Data;
using apiadoptadino.Models;

namespace apiadoptadino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DinosaursController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DinosaursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Dinosaurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dinosaur>>> GetDinosaur()
        {
            return await _context.Dinosaur.ToListAsync();
        }

        // GET: api/Dinosaurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dinosaur>> GetDinosaur(string id)
        {
            var dinosaur = await _context.Dinosaur.FindAsync(id);

            if (dinosaur == null)
            {
                return NotFound();
            }

            return dinosaur;
        }

        // PUT: api/Dinosaurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDinosaur(string id, Dinosaur dinosaur)
        {
            if (id != dinosaur.Name)
            {
                return BadRequest();
            }

            _context.Entry(dinosaur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DinosaurExists(id))
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

        // POST: api/Dinosaurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dinosaur>> PostDinosaur(Dinosaur dinosaur)
        {
            _context.Dinosaur.Add(dinosaur);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DinosaurExists(dinosaur.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDinosaur", new { id = dinosaur.Name }, dinosaur);
        }

        // DELETE: api/Dinosaurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDinosaur(string id)
        {
            var dinosaur = await _context.Dinosaur.FindAsync(id);
            if (dinosaur == null)
            {
                return NotFound();
            }

            _context.Dinosaur.Remove(dinosaur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DinosaurExists(string id)
        {
            return _context.Dinosaur.Any(e => e.Name == id);
        }
    }
}
