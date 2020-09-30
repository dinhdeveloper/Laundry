using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using laundry.Data;
using laundry.Models;

namespace laundry.Areas.Order
{
    [Area("Order")]
    public class OrderController : Controller
    {
        private readonly LaundryContext _context;

        public OrderController(LaundryContext context)
        {
            _context = context;
        }

        // GET: Order/Order
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Order/Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderEntities = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderEntities == null)
            {
                return NotFound();
            }

            return View(orderEntities);
        }

        // GET: Order/Order/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order/Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCode,CustomerId,LaundryTypeId,AmountUnit,OrderType,Description,TotalPayment,Status")] OrderEntities orderEntities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderEntities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderEntities);
        }

        // GET: Order/Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderEntities = await _context.Orders.FindAsync(id);
            if (orderEntities == null)
            {
                return NotFound();
            }
            return View(orderEntities);
        }

        // POST: Order/Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCode,CustomerId,LaundryTypeId,AmountUnit,OrderType,Description,TotalPayment,Status")] OrderEntities orderEntities)
        {
            if (id != orderEntities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderEntities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderEntitiesExists(orderEntities.Id))
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
            return View(orderEntities);
        }

        // GET: Order/Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderEntities = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderEntities == null)
            {
                return NotFound();
            }

            return View(orderEntities);
        }

        // POST: Order/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderEntities = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orderEntities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderEntitiesExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
