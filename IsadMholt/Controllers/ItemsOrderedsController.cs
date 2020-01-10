using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IsadMholt.Models;

namespace IsadMholt.Controllers
{
    public class ItemsOrderedsController : Controller
    {
        private readonly ISAD251_MHoltContext _context;

        public ItemsOrderedsController(ISAD251_MHoltContext context)
        {
            _context = context;
        }

        // GET: ItemsOrdereds
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemsOrdered.ToListAsync());
        }

        // GET: ItemsOrdereds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemsOrdered = await _context.ItemsOrdered
                .FirstOrDefaultAsync(m => m.IdOrder == id);
            if (itemsOrdered == null)
            {
                return NotFound();
            }

            return View(itemsOrdered);
        }

        // GET: ItemsOrdereds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemsOrdereds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrder,IdItem,Quantity")] ItemsOrdered itemsOrdered)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemsOrdered);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemsOrdered);
        }

        // GET: ItemsOrdereds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemsOrdered = await _context.ItemsOrdered.FindAsync(id);
            if (itemsOrdered == null)
            {
                return NotFound();
            }
            return View(itemsOrdered);
        }

        // POST: ItemsOrdereds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrder,IdItem,Quantity")] ItemsOrdered itemsOrdered)
        {
            if (id != itemsOrdered.IdOrder)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemsOrdered);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemsOrderedExists(itemsOrdered.IdOrder))
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
            return View(itemsOrdered);
        }

        // GET: ItemsOrdereds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemsOrdered = await _context.ItemsOrdered
                .FirstOrDefaultAsync(m => m.IdOrder == id);
            if (itemsOrdered == null)
            {
                return NotFound();
            }

            return View(itemsOrdered);
        }

        // POST: ItemsOrdereds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemsOrdered = await _context.ItemsOrdered.FindAsync(id);
            _context.ItemsOrdered.Remove(itemsOrdered);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemsOrderedExists(int id)
        {
            return _context.ItemsOrdered.Any(e => e.IdOrder == id);
        }
    }
}
