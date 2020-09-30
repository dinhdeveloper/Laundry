using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using laundry.Data;
using laundry.Models;

namespace laundry.Areas.Customer
{
    [Area("Customer")]
    public class CustommerController : Controller
    {
        private readonly LaundryContext _context;

        public CustommerController(LaundryContext context)
        {
            _context = context;
        }

        // GET: Customer/Custommer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        // GET: Customer/Custommer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerEntities = await _context.Customer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerEntities == null)
            {
                return NotFound();
            }

            return View(customerEntities);
        }

        // GET: Customer/Custommer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Custommer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCode,FullName,PhoneNumber,Address,Gender,Status")] CustomerEntities customerEntities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerEntities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerEntities);
        }

        // GET: Customer/Custommer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerEntities = await _context.Customer.FindAsync(id);
            if (customerEntities == null)
            {
                return NotFound();
            }
            return View(customerEntities);
        }

        // POST: Customer/Custommer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCode,FullName,PhoneNumber,Address,Gender,Status")] CustomerEntities customerEntities)
        {
            if (id != customerEntities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerEntities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerEntitiesExists(customerEntities.Id))
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
            return View(customerEntities);
        }

        // GET: Customer/Custommer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerEntities = await _context.Customer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerEntities == null)
            {
                return NotFound();
            }

            return View(customerEntities);
        }

        // POST: Customer/Custommer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerEntities = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customerEntities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerEntitiesExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
