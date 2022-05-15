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
    public class TypeDinosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TypeDinosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TypeDinos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeDino>>> GetTypeDino()
        {
            return await _context.TypeDino.ToListAsync();
        }

        // GET: api/TypeDinos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeDino>> GetTypeDino(int id)
        {
            var typeDino = await _context.TypeDino.FindAsync(id);

            if (typeDino == null)
            {
                return NotFound();
            }

            return typeDino;
        }

        // PUT: api/TypeDinos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeDino(int id, TypeDino typeDino)
        {
            if (id != typeDino.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeDino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeDinoExists(id))
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

        // POST: api/TypeDinos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeDino>> PostTypeDino(TypeDino typeDino)
        {
            _context.TypeDino.Add(typeDino);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeDino", new { id = typeDino.Id }, typeDino);
        }

        // DELETE: api/TypeDinos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeDino(int id)
        {
            var typeDino = await _context.TypeDino.FindAsync(id);
            if (typeDino == null)
            {
                return NotFound();
            }

            _context.TypeDino.Remove(typeDino);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeDinoExists(int id)
        {
            return _context.TypeDino.Any(e => e.Id == id);
        }
    }
}
