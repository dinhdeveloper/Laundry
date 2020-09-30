using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using laundry.Data;
using laundry.Models;

namespace laundry.Areas.Bill
{
    [Area("Bill")]
    public class BillController : Controller
    {
        private readonly LaundryContext _context;

        public BillController(LaundryContext context)
        {
            _context = context;
        }

        // GET: Bill/Bill
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bills.ToListAsync());
        }

        // GET: Bill/Bill/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billEntities = await _context.Bills
                .FirstOrDefaultAsync(m => m.ID == id);
            if (billEntities == null)
            {
                return NotFound();
            }

            return View(billEntities);
        }

        // GET: Bill/Bill/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bill/Bill/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IdCode,DateCreate,TotalExpenses,Status")] BillEntities billEntities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billEntities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(billEntities);
        }

        // GET: Bill/Bill/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billEntities = await _context.Bills.FindAsync(id);
            if (billEntities == null)
            {
                return NotFound();
            }
            return View(billEntities);
        }

        // POST: Bill/Bill/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IdCode,DateCreate,TotalExpenses,Status")] BillEntities billEntities)
        {
            if (id != billEntities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billEntities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillEntitiesExists(billEntities.ID))
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
            return View(billEntities);
        }

        // GET: Bill/Bill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billEntities = await _context.Bills
                .FirstOrDefaultAsync(m => m.ID == id);
            if (billEntities == null)
            {
                return NotFound();
            }

            return View(billEntities);
        }

        // POST: Bill/Bill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var billEntities = await _context.Bills.FindAsync(id);
            _context.Bills.Remove(billEntities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillEntitiesExists(int id)
        {
            return _context.Bills.Any(e => e.ID == id);
        }
    }
}
