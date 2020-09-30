using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using laundry.Data;
using laundry.Models;

namespace laundry.Areas.Delivery
{
    [Area("Delivery")]
    public class DeliveryController : Controller
    {
        private readonly LaundryContext _context;

        public DeliveryController(LaundryContext context)
        {
            _context = context;
        }

        // GET: Delivery/Delivery
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deliveries.ToListAsync());
        }

        // GET: Delivery/Delivery/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryEntities = await _context.Deliveries
                .FirstOrDefaultAsync(m => m.ID == id);
            if (deliveryEntities == null)
            {
                return NotFound();
            }

            return View(deliveryEntities);
        }

        // GET: Delivery/Delivery/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Delivery/Delivery/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] DeliveryEntities deliveryEntities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryEntities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryEntities);
        }

        // GET: Delivery/Delivery/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryEntities = await _context.Deliveries.FindAsync(id);
            if (deliveryEntities == null)
            {
                return NotFound();
            }
            return View(deliveryEntities);
        }

        // POST: Delivery/Delivery/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] DeliveryEntities deliveryEntities)
        {
            if (id != deliveryEntities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryEntities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryEntitiesExists(deliveryEntities.ID))
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
            return View(deliveryEntities);
        }

        // GET: Delivery/Delivery/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryEntities = await _context.Deliveries
                .FirstOrDefaultAsync(m => m.ID == id);
            if (deliveryEntities == null)
            {
                return NotFound();
            }

            return View(deliveryEntities);
        }

        // POST: Delivery/Delivery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryEntities = await _context.Deliveries.FindAsync(id);
            _context.Deliveries.Remove(deliveryEntities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryEntitiesExists(int id)
        {
            return _context.Deliveries.Any(e => e.ID == id);
        }
    }
}
