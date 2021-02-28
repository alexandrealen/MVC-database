using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoiabinhaRoom.Data;
using GoiabinhaRoom.Models;

namespace GoiabinhaRoom.Controllers
{
    public class GoiabinhasController : Controller
    {
        private readonly GoiabinhaRoomContext _context;

        public GoiabinhasController(GoiabinhaRoomContext context)
        {
            _context = context;
        }

        // GET: Goiabinhas
        public async Task<IActionResult> Index(string nome, string techLeader)
        {
            var nomes = from m in _context.Goiabinha
                         select m;
            var tech = from n in _context.Goiabinha
                        select n;

            if (!String.IsNullOrEmpty(nome))
            {
                nomes = nomes.Where(s => s.nome.Contains(nome));
                return View(await nomes.ToListAsync());
            }

            if (!String.IsNullOrEmpty(techLeader))
            {
                tech = tech.Where(s => s.techLeader.Contains(techLeader));
                return View(await tech.ToListAsync());
            }

            return View(await nomes.ToListAsync());
        }

        // GET: Goiabinhas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goiabinha = await _context.Goiabinha
                .FirstOrDefaultAsync(m => m.id == id);
            if (goiabinha == null)
            {
                return NotFound();
            }

            return View(goiabinha);
        }

        // GET: Goiabinhas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Goiabinhas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,techLeader,horas,tickets")] Goiabinha goiabinha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goiabinha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goiabinha);
        }

        // GET: Goiabinhas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goiabinha = await _context.Goiabinha.FindAsync(id);
            if (goiabinha == null)
            {
                return NotFound();
            }
            return View(goiabinha);
        }

        // POST: Goiabinhas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,techLeader,horas,tickets")] Goiabinha goiabinha)
        {
            if (id != goiabinha.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goiabinha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoiabinhaExists(goiabinha.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(goiabinha);
        }

        // GET: Goiabinhas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goiabinha = await _context.Goiabinha
                .FirstOrDefaultAsync(m => m.id == id);
            if (goiabinha == null)
            {
                return NotFound();
            }

            return View(goiabinha);
        }

        // POST: Goiabinhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goiabinha = await _context.Goiabinha.FindAsync(id);
            _context.Goiabinha.Remove(goiabinha);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoiabinhaExists(int id)
        {
            return _context.Goiabinha.Any(e => e.id == id);
        }
    }
}
