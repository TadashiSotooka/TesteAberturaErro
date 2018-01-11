using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteAberturaErro.Models;

namespace TesteAberturaErro.Controllers
{
    public class ErrosController : Controller
    {
        private readonly TesteAberturaErroContext _context;

        public ErrosController(TesteAberturaErroContext context)
        {
            _context = context;
        }

        // GET: Erros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Erros.ToListAsync());
        }

        // GET: Erros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erros = await _context.Erros
                .SingleOrDefaultAsync(m => m.ID == id);
            if (erros == null)
            {
                return NotFound();
            }

            return View(erros);
        }

        // GET: Erros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Erros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titulo,Severidade,Descricao,Produto,DataHora,Email")] Erros erros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(erros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(erros);
        }

        // GET: Erros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erros = await _context.Erros.SingleOrDefaultAsync(m => m.ID == id);
            if (erros == null)
            {
                return NotFound();
            }
            return View(erros);
        }

        // POST: Erros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titulo,Severidade,Descricao,Produto,DataHora,Email")] Erros erros)
        {
            if (id != erros.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(erros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ErrosExists(erros.ID))
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
            return View(erros);
        }

        // GET: Erros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erros = await _context.Erros
                .SingleOrDefaultAsync(m => m.ID == id);
            if (erros == null)
            {
                return NotFound();
            }

            return View(erros);
        }

        // POST: Erros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var erros = await _context.Erros.SingleOrDefaultAsync(m => m.ID == id);
            _context.Erros.Remove(erros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ErrosExists(int id)
        {
            return _context.Erros.Any(e => e.ID == id);
        }
    }
}
