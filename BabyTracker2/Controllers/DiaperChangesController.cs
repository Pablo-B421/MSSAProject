using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BabyTracker2.Data;
using BabyTracker2.Models;

namespace BabyTracker2.Controllers
{
    public class DiaperChangesController : Controller
    {
        private readonly BabyTracker2Context _context;

        public DiaperChangesController(BabyTracker2Context context)
        {
            _context = context;
        }

        // GET: DiaperChanges
        public async Task<IActionResult> Index()
        {
            var babyTracker2Context = _context.DiaperChange.Include(d => d.BabyInfo);
            return View(await babyTracker2Context.ToListAsync());
        }

        // GET: DiaperChanges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaperChange = await _context.DiaperChange
                .Include(d => d.BabyInfo)
                .FirstOrDefaultAsync(m => m.NumberofDiaperChanges == id);
            if (diaperChange == null)
            {
                return NotFound();
            }

            return View(diaperChange);
        }

        // GET: DiaperChanges/Create
        public IActionResult Create()
        {
            ViewData["BabyID"] = new SelectList(_context.BabyInfo, "BabyID", "BabyID");
            return View();
        }

        // POST: DiaperChanges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumberofDiaperChanges,BabyID")] DiaperChange diaperChange)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diaperChange);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BabyID"] = new SelectList(_context.BabyInfo, "BabyID", "BabyID", diaperChange.BabyID);
            return View(diaperChange);
        }

        // GET: DiaperChanges/Edit/5
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
            ViewData["BabyID"] = new SelectList(_context.BabyInfo, "BabyID", "BabyID", diaperChange.BabyID);
            return View(diaperChange);
        }

        // POST: DiaperChanges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumberofDiaperChanges,BabyID")] DiaperChange diaperChange)
        {
            if (id != diaperChange.NumberofDiaperChanges)
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
                    if (!DiaperChangeExists(diaperChange.NumberofDiaperChanges))
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
            ViewData["BabyID"] = new SelectList(_context.BabyInfo, "BabyID", "BabyID", diaperChange.BabyID);
            return View(diaperChange);
        }

        // GET: DiaperChanges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaperChange = await _context.DiaperChange
                .Include(d => d.BabyInfo)
                .FirstOrDefaultAsync(m => m.NumberofDiaperChanges == id);
            if (diaperChange == null)
            {
                return NotFound();
            }

            return View(diaperChange);
        }

        // POST: DiaperChanges/Delete/5
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
            return _context.DiaperChange.Any(e => e.NumberofDiaperChanges == id);
        }
    }
}
