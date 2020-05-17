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
    public class BabyMileStonesController : Controller
    {
        private readonly BabyTrackerContext _context;

        public BabyMileStonesController(BabyTrackerContext context)
        {
            _context = context;
        }

        // GET: BabyMileStones
        public async Task<IActionResult> Index()
        {
            var babyTrackerContext = _context.BabyMileStone.Include(b => b.BabyInfo);
            return View(await babyTrackerContext.ToListAsync());
        }

        // GET: BabyMileStones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var babyMileStone = await _context.BabyMileStone
                .Include(b => b.BabyInfo)
                .FirstOrDefaultAsync(m => m.MileStoneID == id);
            if (babyMileStone == null)
            {
                return NotFound();
            }

            return View(babyMileStone);
        }

        // GET: BabyMileStones/Create
        public IActionResult Create()
        {
            ViewData["BabyName"] = new SelectList(_context.BabyInfo, "BabyName", "BabyName");
            return View();
        }

        // POST: BabyMileStones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MileStoneID,EventDate,Details,BabyName")] BabyMileStone babyMileStone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(babyMileStone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BabyName"] = new SelectList(_context.BabyInfo, "BabyName", "BabyName", babyMileStone.BabyName);
            return View(babyMileStone);
        }

        // GET: BabyMileStones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var babyMileStone = await _context.BabyMileStone.FindAsync(id);
            if (babyMileStone == null)
            {
                return NotFound();
            }
            ViewData["BabyName"] = new SelectList(_context.BabyInfo, "BabyName", "BabyName", babyMileStone.BabyName);
            return View(babyMileStone);
        }

        // POST: BabyMileStones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MileStoneID,EventDate,Details,BabyName")] BabyMileStone babyMileStone)
        {
            if (id != babyMileStone.MileStoneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(babyMileStone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BabyMileStoneExists(babyMileStone.MileStoneID))
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
            ViewData["BabyName"] = new SelectList(_context.BabyInfo, "BabyName", "BabyName", babyMileStone.BabyName);
            return View(babyMileStone);
        }

        // GET: BabyMileStones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var babyMileStone = await _context.BabyMileStone
                .Include(b => b.BabyInfo)
                .FirstOrDefaultAsync(m => m.MileStoneID == id);
            if (babyMileStone == null)
            {
                return NotFound();
            }

            return View(babyMileStone);
        }

        // POST: BabyMileStones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var babyMileStone = await _context.BabyMileStone.FindAsync(id);
            _context.BabyMileStone.Remove(babyMileStone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BabyMileStoneExists(int id)
        {
            return _context.BabyMileStone.Any(e => e.MileStoneID == id);
        }
    }
}
