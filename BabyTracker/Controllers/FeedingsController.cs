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
    public class FeedingsController : Controller
    {
        private readonly BabyTrackerContext _context;

        public FeedingsController(BabyTrackerContext context)
        {
            _context = context;
        }

        // GET: Feedings
        public async Task<IActionResult> Index()
        {
            var babyTrackerContext = _context.Feeding.Include(f => f.BabyInfo);
            return View(await babyTrackerContext.ToListAsync());
        }

        // GET: Feedings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeding = await _context.Feeding
                .Include(f => f.BabyInfo)
                .FirstOrDefaultAsync(m => m.FeedingID == id);
            if (feeding == null)
            {
                return NotFound();
            }

            return View(feeding);
        }

        // GET: Feedings/Create
        public IActionResult Create()
        {
            ViewData["BabyName"] = new SelectList(_context.BabyInfo, "BabyName", "BabyName");
            return View();
        }

        // POST: Feedings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedingID,NumberOfFeedings,FeedingTime,BabyName")] Feeding feeding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feeding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BabyName"] = new SelectList(_context.BabyInfo, "BabyName", "BabyName", feeding.BabyName);
            return View(feeding);
        }

        // GET: Feedings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeding = await _context.Feeding.FindAsync(id);
            if (feeding == null)
            {
                return NotFound();
            }
            ViewData["BabyName"] = new SelectList(_context.BabyInfo, "BabyName", "BabyName", feeding.BabyName);
            return View(feeding);
        }

        // POST: Feedings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedingID,NumberOfFeedings,FeedingTime,BabyName")] Feeding feeding)
        {
            if (id != feeding.FeedingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feeding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedingExists(feeding.FeedingID))
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
            ViewData["BabyName"] = new SelectList(_context.BabyInfo, "BabyName", "BabyName", feeding.BabyName);
            return View(feeding);
        }

        // GET: Feedings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeding = await _context.Feeding
                .Include(f => f.BabyInfo)
                .FirstOrDefaultAsync(m => m.FeedingID == id);
            if (feeding == null)
            {
                return NotFound();
            }

            return View(feeding);
        }

        // POST: Feedings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feeding = await _context.Feeding.FindAsync(id);
            _context.Feeding.Remove(feeding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedingExists(int id)
        {
            return _context.Feeding.Any(e => e.FeedingID == id);
        }
    }
}
