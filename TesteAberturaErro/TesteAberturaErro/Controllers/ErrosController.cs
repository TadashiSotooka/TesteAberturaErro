using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteAberturaErro.Models;
using TesteAberturaErro.ViewModels;

namespace TesteAberturaErro.Controllers
{
    public class ErrosController : Controller
    {
        private readonly TesteAberturaErroContext context;
        private readonly IHostingEnvironment hostingEnvironment;

        public ErrosController(TesteAberturaErroContext context, IHostingEnvironment environment)
        {
            this.hostingEnvironment = environment;
            this.context = context;
        }

        // GET: Erros
        public async Task<IActionResult> Index()
        {
            return View(await context.Erros.ToListAsync());
        }

        // GET: Erros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erros = await context.Erros
                .SingleOrDefaultAsync(m => m.IdErro == id);
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
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdErro,Titulo,Severidade,Descricao,Produto,DataHora,Email,Imagem")] Erros erros)
        {
            if (ModelState.IsValid)
            {

                _context.Add(erros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(erros);
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ErrosView model, Erros erros)
        {

            if (model.Img != null)
            {
                var fileName = GetUniqueName(model.Img.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, fileName);
                model.Img.CopyTo(new FileStream(filePath, FileMode.Create));
                model.Erros.Imagem = fileName; // Set the file name
            }

            if (ModelState.IsValid)
            {

                context.Erros.Add(model.Erros);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(erros);

        }

        //Metodo para acresentar caracters noo nome da imagem
        private string GetUniqueName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_" + Guid.NewGuid().ToString().Substring(0, 8)
                   + Path.GetExtension(fileName);
        }

        // GET: Erros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erros = await context.Erros.SingleOrDefaultAsync(m => m.IdErro == id);
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
        public async Task<IActionResult> Edit(int id, [Bind("IdErro,Titulo,Severidade,Descricao,Produto,DataHora,Email,Imagem")] Erros erros)
        {
            if (id != erros.IdErro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(erros);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ErrosExists(erros.IdErro))
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

            var erros = await context.Erros
                .SingleOrDefaultAsync(m => m.IdErro == id);
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
            var erros = await context.Erros.SingleOrDefaultAsync(m => m.IdErro == id);
            context.Erros.Remove(erros);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ErrosExists(int id)
        {
            return context.Erros.Any(e => e.IdErro == id);
        }
    }
}
