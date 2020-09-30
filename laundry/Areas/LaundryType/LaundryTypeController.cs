using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using laundry.Data;
using laundry.Models;

namespace laundry.Areas.LaundryType
{
    [Area("LaundryType")]
    public class LaundryTypeController : Controller
    {
        private readonly LaundryContext _context;

        public LaundryTypeController(LaundryContext context)
        {
            _context = context;
        }

        // GET: LaundryType/LaundryType
        public async Task<IActionResult> Index()
        {
            return View(await _context.LaudryTypes.ToListAsync());
        }

        // GET: LaundryType/LaundryType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laudryTypeEnitites = await _context.LaudryTypes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (laudryTypeEnitites == null)
            {
                return NotFound();
            }

            return View(laudryTypeEnitites);
        }

        // GET: LaundryType/LaundryType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LaundryType/LaundryType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IdCode,LaundryName,Price,Init,Status")] LaudryTypeEnitites laudryTypeEnitites)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laudryTypeEnitites);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(laudryTypeEnitites);
        }

        // GET: LaundryType/LaundryType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laudryTypeEnitites = await _context.LaudryTypes.FindAsync(id);
            if (laudryTypeEnitites == null)
            {
                return NotFound();
            }
            return View(laudryTypeEnitites);
        }

        // POST: LaundryType/LaundryType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IdCode,LaundryName,Price,Init,Status")] LaudryTypeEnitites laudryTypeEnitites)
        {
            if (id != laudryTypeEnitites.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laudryTypeEnitites);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaudryTypeEnititesExists(laudryTypeEnitites.ID))
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
            return View(laudryTypeEnitites);
        }

        // GET: LaundryType/LaundryType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laudryTypeEnitites = await _context.LaudryTypes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (laudryTypeEnitites == null)
            {
                return NotFound();
            }

            return View(laudryTypeEnitites);
        }

        // POST: LaundryType/LaundryType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laudryTypeEnitites = await _context.LaudryTypes.FindAsync(id);
            _context.LaudryTypes.Remove(laudryTypeEnitites);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaudryTypeEnititesExists(int id)
        {
            return _context.LaudryTypes.Any(e => e.ID == id);
        }
    }
}
