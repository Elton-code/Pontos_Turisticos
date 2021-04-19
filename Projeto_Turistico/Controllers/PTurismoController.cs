using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Turistico.Models;

namespace Projeto_Turistico.Controllers
{
    public class PTurismoController : Controller
    {
        private readonly Contexto _context;

        public PTurismoController(Contexto context)
        {
            _context = context;
        }

        // GET: Pontos_Turisticos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pontos_Turisticos.ToListAsync());
        }

        // GET: Pontos_Turisticoss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Pontos_Turisticos = await _context.Pontos_Turisticos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Pontos_Turisticos == null)
            {
                return NotFound();
            }

            return View(Pontos_Turisticos);
        }

        // GET: Pontos_Turisticos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pontos_Turisticos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Referencia,Cidade")] Pontos_Turisticos Pontos_Turisticos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Pontos_Turisticos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Pontos_Turisticos);
        }

        // GET: Pontos_Turisticos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Pontos_Turisticos = await _context.Pontos_Turisticos.FindAsync(id);
            if (Pontos_Turisticos == null)
            {
                return NotFound();
            }
            return View(Pontos_Turisticos);
        }

        // POST: Pontos_Turisticos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Referencia,Cidade")] Pontos_Turisticos Pontos_Turisticos)
        {
            if (id != Pontos_Turisticos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Pontos_Turisticos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Pontos_TuristicosExists(Pontos_Turisticos.Id))
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
            return View(Pontos_Turisticos);
        }

        // GET: Pontos_Turisticos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Pontos_Turisticos = await _context.Pontos_Turisticos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Pontos_Turisticos == null)
            {
                return NotFound();
            }

            return View(Pontos_Turisticos);
        }

        // POST: Pontos_Turisticoss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Pontos_Turisticos = await _context.Pontos_Turisticos.FindAsync(id);
            _context.Pontos_Turisticos.Remove(Pontos_Turisticos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Pontos_TuristicosExists(int id)
        {
            return _context.Pontos_Turisticos.Any(e => e.Id == id);
        }
    }
}
