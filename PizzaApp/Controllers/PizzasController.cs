using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Data;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    public class PizzasController : Controller
    {
        private readonly AppDbContext _context;

        public PizzasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pizzas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Pizzas.Include(p => p.Category);
            return View(await appDbContext.ToListAsync());
        }
        

        public async Task<IActionResult> AllPizzas(string searchText = "")
        {
            var pizza = from m in _context.Pizzas
                        select m;
            if (searchText != "" && searchText != null)
            {
                pizza = pizza.Where(p => p.Name.Contains(searchText));
            }
            return View(await pizza.ToListAsync());
        }
        
        // GET: Pizzas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pizzas == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizzas
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        // GET: Pizzas/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Pizzas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,ImageUrl,CategoryId")] Pizza pizza)
        {
            
                _context.Add(pizza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", pizza.CategoryId);
            return View(pizza);
        }

        // GET: Pizzas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pizzas == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", pizza.CategoryId);
            return View(pizza);
        }

        // POST: Pizzas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,ImageUrl,CategoryId")] Pizza pizza)
        {
            if (id != pizza.Id)
            {
                return NotFound();
            }

        
                try
                {
                    _context.Update(pizza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaExists(pizza.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", pizza.CategoryId);
            return View(pizza);
        }

        // GET: Pizzas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pizzas == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizzas
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        // POST: Pizzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pizzas == null)
            {
                return Problem("Entity set 'AppDbContext.Pizzas'  is null.");
            }
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza != null)
            {
                _context.Pizzas.Remove(pizza);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaExists(int id)
        {
          return (_context.Pizzas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
