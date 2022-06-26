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
    public class PizzaIngredientsController : Controller
    {
        private readonly AppDbContext _context;

        public PizzaIngredientsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PizzaIngredients
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PizzaIngredients.Include(p => p.Ingredient).Include(p => p.Pizza);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PizzaIngredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PizzaIngredients == null)
            {
                return NotFound();
            }

            var pizzaIngredients = await _context.PizzaIngredients
                .Include(p => p.Ingredient)
                .Include(p => p.Pizza)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pizzaIngredients == null)
            {
                return NotFound();
            }

            return View(pizzaIngredients);
        }

        // GET: PizzaIngredients/Create
        public IActionResult Create()
        {
            ViewData["IngredientId"] = new SelectList(_context.Set<Ingredient>(), "Id", "Name");
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "Id", "Name");
            return View();
        }

        // POST: PizzaIngredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PizzaId,IngredientId")] PizzaIngredients pizzaIngredients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pizzaIngredients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngredientId"] = new SelectList(_context.Set<Ingredient>(), "Id", "Name", pizzaIngredients.IngredientId);
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "Id", "Name", pizzaIngredients.PizzaId);
            return View(pizzaIngredients);
        }

        // GET: PizzaIngredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PizzaIngredients == null)
            {
                return NotFound();
            }

            var pizzaIngredients = await _context.PizzaIngredients.FindAsync(id);
            if (pizzaIngredients == null)
            {
                return NotFound();
            }
            ViewData["IngredientId"] = new SelectList(_context.Set<Ingredient>(), "Id", "Name", pizzaIngredients.IngredientId);
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "Id", "Name", pizzaIngredients.PizzaId);
            return View(pizzaIngredients);
        }

        // POST: PizzaIngredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PizzaId,IngredientId")] PizzaIngredients pizzaIngredients)
        {
            if (id != pizzaIngredients.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pizzaIngredients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaIngredientsExists(pizzaIngredients.Id))
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
            ViewData["IngredientId"] = new SelectList(_context.Set<Ingredient>(), "Id", "Name", pizzaIngredients.IngredientId);
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "Id", "Name", pizzaIngredients.PizzaId);
            return View(pizzaIngredients);
        }

        // GET: PizzaIngredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PizzaIngredients == null)
            {
                return NotFound();
            }

            var pizzaIngredients = await _context.PizzaIngredients
                .Include(p => p.Ingredient)
                .Include(p => p.Pizza)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pizzaIngredients == null)
            {
                return NotFound();
            }

            return View(pizzaIngredients);
        }

        // POST: PizzaIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PizzaIngredients == null)
            {
                return Problem("Entity set 'AppDbContext.PizzaIngredients'  is null.");
            }
            var pizzaIngredients = await _context.PizzaIngredients.FindAsync(id);
            if (pizzaIngredients != null)
            {
                _context.PizzaIngredients.Remove(pizzaIngredients);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaIngredientsExists(int id)
        {
          return (_context.PizzaIngredients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
