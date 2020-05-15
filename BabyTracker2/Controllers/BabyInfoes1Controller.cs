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
    public class BabyInfoes1Controller : Controller
    {
        private readonly BabyTracker2Context _context;

        public BabyInfoes1Controller(BabyTracker2Context context)
        {
            _context = context;
        }

        // GET: BabyInfoes1
        public async Task<IActionResult> Index()
        {
            var babyTracker2Context = _context.BabyInfo.Include(b => b.Users);
            return View(await babyTracker2Context.ToListAsync());
        }

        // GET: BabyInfoes1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var babyInfo = await _context.BabyInfo
                .Include(b => b.Users)
                .FirstOrDefaultAsync(m => m.BabyID == id);
            if (babyInfo == null)
            {
                return NotFound();
            }

            return View(babyInfo);
        }

        // GET: BabyInfoes1/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID");
            return View();
        }

        // POST: BabyInfoes1/Create
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
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", babyInfo.UserID);
            return View(babyInfo);
        }

        // GET: BabyInfoes1/Edit/5
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
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", babyInfo.UserID);
            return View(babyInfo);
        }

        // POST: BabyInfoes1/Edit/5
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
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", babyInfo.UserID);
            return View(babyInfo);
        }

        // GET: BabyInfoes1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var babyInfo = await _context.BabyInfo
                .Include(b => b.Users)
                .FirstOrDefaultAsync(m => m.BabyID == id);
            if (babyInfo == null)
            {
                return NotFound();
            }

            return View(babyInfo);
        }

        // POST: BabyInfoes1/Delete/5
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
