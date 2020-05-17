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
            var babyTrackerContext = _context.BabyInfo.Include(b => b.Users);
            return View(await babyTrackerContext.ToListAsync());
        }

        // GET: BabyInfoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var babyInfo = await _context.BabyInfo
                .Include(b => b.Users)
                .FirstOrDefaultAsync(m => m.BabyName == id);
            if (babyInfo == null)
            {
                return NotFound();
            }

            return View(babyInfo);
        }

        // GET: BabyInfoes/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID");
            return View();
        }

        // POST: BabyInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BabyName,BabyGender,BirthDate,UserID")] BabyInfo babyInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(babyInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", babyInfo.UserID);
            return View(babyInfo);
        }

        // GET: BabyInfoes/Edit/5
        public async Task<IActionResult> Edit(string id)
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
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", babyInfo.UserID);
            return View(babyInfo);
        }

        // POST: BabyInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BabyName,BabyGender,BirthDate,UserID")] BabyInfo babyInfo)
        {
            if (id != babyInfo.BabyName)
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
                    if (!BabyInfoExists(babyInfo.BabyName))
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
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", babyInfo.UserID);
            return View(babyInfo);
        }

        // GET: BabyInfoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var babyInfo = await _context.BabyInfo
                .Include(b => b.Users)
                .FirstOrDefaultAsync(m => m.BabyName == id);
            if (babyInfo == null)
            {
                return NotFound();
            }

            return View(babyInfo);
        }

        // POST: BabyInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var babyInfo = await _context.BabyInfo.FindAsync(id);
            _context.BabyInfo.Remove(babyInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BabyInfoExists(string id)
        {
            return _context.BabyInfo.Any(e => e.BabyName == id);
        }
    }
}
