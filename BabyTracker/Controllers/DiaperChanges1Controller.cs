using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BabyTracker.Data;
using BabyTracker.Models;

namespace BabyTracker.Controllers
{
    public class DiaperChanges1Controller : Controller
    {
        private readonly BabyTrackerContext _context;

        public DiaperChanges1Controller(BabyTrackerContext context)
        {
            _context = context;
        }

        // GET: DiaperChanges1
        public async Task<IActionResult> Index()
        {
            var babyTrackerContext = _context.DiaperChange.Include(d => d.BabyInfo);
            return View(await babyTrackerContext.ToListAsync());
        }

        // GET: DiaperChanges1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaperChange = await _context.DiaperChange
                .Include(d => d.BabyInfo)
                .FirstOrDefaultAsync(m => m.DiaperChangeID == id);
            if (diaperChange == null)
            {
                return NotFound();
            }

            return View(diaperChange);
        }

        // GET: DiaperChanges1/Create
        public IActionResult Create()
        {
            ViewData["BabyName"] = new SelectList(_context.BabyInfo, "BabyName", "BabyName");
            return View();
        }

        // POST: DiaperChanges1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiaperChangeID,NumberofDiaperChanges,Date,BabyName")] DiaperChange diaperChange)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diaperChange);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BabyName"] = new SelectList(_context.BabyInfo, "BabyName", "BabyName", diaperChange.BabyName);
            return View(diaperChange);
        }

        // GET: DiaperChanges1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaperChange = await _context.DiaperChange.FindAsync(id);
            if (diaperChange == null)
            {
                return NotFound();
            }
            ViewData["BabyName"] = new SelectList(_context.BabyInfo, "BabyName", "BabyName", diaperChange.BabyName);
            return View(diaperChange);
        }

        // POST: DiaperChanges1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiaperChangeID,NumberofDiaperChanges,Date,BabyName")] DiaperChange diaperChange)
        {
            if (id != diaperChange.DiaperChangeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diaperChange);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiaperChangeExists(diaperChange.DiaperChangeID))
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
            ViewData["BabyName"] = new SelectList(_context.BabyInfo, "BabyName", "BabyName", diaperChange.BabyName);
            return View(diaperChange);
        }

        // GET: DiaperChanges1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaperChange = await _context.DiaperChange
                .Include(d => d.BabyInfo)
                .FirstOrDefaultAsync(m => m.DiaperChangeID == id);
            if (diaperChange == null)
            {
                return NotFound();
            }

            return View(diaperChange);
        }

        // POST: DiaperChanges1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diaperChange = await _context.DiaperChange.FindAsync(id);
            _context.DiaperChange.Remove(diaperChange);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiaperChangeExists(int id)
        {
            return _context.DiaperChange.Any(e => e.DiaperChangeID == id);
        }
    }
}
