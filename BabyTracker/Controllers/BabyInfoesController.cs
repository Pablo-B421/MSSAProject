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
    public class BabyInfoesController : Controller
    {
        private readonly BabyTrackerContext _context;

        public BabyInfoesController(BabyTrackerContext context)
        {
            _context = context;
        }

        // GET: BabyInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.BabyInfo.ToListAsync());
        }

        // GET: BabyInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var babyInfo = await _context.BabyInfo
                .FirstOrDefaultAsync(m => m.BabyID == id);
            if (babyInfo == null)
            {
                return NotFound();
            }

            return View(babyInfo);
        }

        // GET: BabyInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BabyInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BabyID,BabyName,BabyGender,BirthDate,UserID")] BabyInfo babyInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(babyInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(babyInfo);
        }

        // GET: BabyInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var babyInfo = await _context.BabyInfo.FindAsync(id);
            if (babyInfo == null)
            {
                return NotFound();
            }
            return View(babyInfo);
        }

        // POST: BabyInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BabyID,BabyName,BabyGender,BirthDate,UserID")] BabyInfo babyInfo)
        {
            if (id != babyInfo.BabyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(babyInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BabyInfoExists(babyInfo.BabyID))
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
            return View(babyInfo);
        }

        // GET: BabyInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var babyInfo = await _context.BabyInfo
                .FirstOrDefaultAsync(m => m.BabyID == id);
            if (babyInfo == null)
            {
                return NotFound();
            }

            return View(babyInfo);
        }

        // POST: BabyInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var babyInfo = await _context.BabyInfo.FindAsync(id);
            _context.BabyInfo.Remove(babyInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BabyInfoExists(int id)
        {
            return _context.BabyInfo.Any(e => e.BabyID == id);
        }
    }
}
