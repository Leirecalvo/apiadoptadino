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
    public class AdoptionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdoptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Adoptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adoption>>> GetAdoption()
        {
            return await _context.Adoption.ToListAsync();
        }

        // GET: api/Adoptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adoption>> GetAdoption(int id)
        {
            var adoption = await _context.Adoption.FindAsync(id);

            if (adoption == null)
            {
                return NotFound();
            }

            return adoption;
        }

        // PUT: api/Adoptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdoption(int id, Adoption adoption)
        {

            if (id != adoption.Id)
            {
                return BadRequest();
            }

            _context.Entry(adoption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdoptionExists(id))
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

        // POST: api/Adoptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adoption>> PostAdoption(Adoption adoption)
        {
            _context.Adoption.Add(adoption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdoption", new { id = adoption.Id }, adoption);
        }

        // DELETE: api/Adoptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdoption(int id)
        {
            var adoption = await _context.Adoption.FindAsync(id);
            if (adoption == null)
            {
                return NotFound();
            }

            _context.Adoption.Remove(adoption);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdoptionExists(int id)
        {
            return _context.Adoption.Any(e => e.Id == id);
        }
    }
}
