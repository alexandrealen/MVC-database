using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoiabinhaRoom.Data;
using GoiabinhaRoom.Models;

namespace GoiabinhaRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIgoiabinhaController : ControllerBase
    {
        private readonly GoiabinhaRoomContext _context;

        public APIgoiabinhaController(GoiabinhaRoomContext context)
        {
            _context = context;
        }

        // GET: api/APIgoiabinha
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Goiabinha>>> GetGoiabinha()
        {
            return await _context.Goiabinha.ToListAsync();
        }

        // GET: api/APIgoiabinha/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Goiabinha>> GetGoiabinha(int id)
        {
            var goiabinha = await _context.Goiabinha.FindAsync(id);

            if (goiabinha == null)
            {
                return NotFound();
            }

            return goiabinha;
        }

        // PUT: api/APIgoiabinha/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoiabinha(int id, Goiabinha goiabinha)
        {
            if (id != goiabinha.id)
            {
                return BadRequest();
            }

            _context.Entry(goiabinha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoiabinhaExists(id))
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

        // POST: api/APIgoiabinha
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Goiabinha>> PostGoiabinha(Goiabinha goiabinha)
        {
            _context.Goiabinha.Add(goiabinha);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoiabinha", new { id = goiabinha.id }, goiabinha);
        }

        // DELETE: api/APIgoiabinha/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Goiabinha>> DeleteGoiabinha(int id)
        {
            var goiabinha = await _context.Goiabinha.FindAsync(id);
            if (goiabinha == null)
            {
                return NotFound();
            }

            _context.Goiabinha.Remove(goiabinha);
            await _context.SaveChangesAsync();

            return goiabinha;
        }

        private bool GoiabinhaExists(int id)
        {
            return _context.Goiabinha.Any(e => e.id == id);
        }
    }
}
