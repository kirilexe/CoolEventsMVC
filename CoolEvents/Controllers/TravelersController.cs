﻿using CoolEvents.Data;
using CoolEvents.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolEvents.Controllers
{
    public class TravelersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TravelersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Travelers
        public async Task<IActionResult> Index(string searchString)
        {
            var travelers = from t in _context.Traveler select t;
            if (!string.IsNullOrEmpty(searchString))
            {
                travelers = travelers.Where(t => t.FirstName.Contains(searchString) || t.LastName.Contains(searchString) || t.Email.Contains(searchString));
            }
            return View(await travelers.ToListAsync());
        }

        // GET: Travelers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traveler = await _context.Traveler
                .FirstOrDefaultAsync(m => m.TravelerId == id);
            if (traveler == null)
            {
                return NotFound();
            }

            return View(traveler);
        }

        // GET: Travelers/Create
        [Authorize(Roles = "Admin, TravelAgent")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Travelers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, TravelAgent")]
        public async Task<IActionResult> Create([Bind("TravelerId,FirstName,LastName,Email")] Traveler traveler)
        {
            ModelState.Remove("Bookings");
            if (ModelState.IsValid)
            {
                _context.Add(traveler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(traveler);
        }

        // GET: Travelers/Edit/5
        [Authorize(Roles = "Admin, TravelAgent")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traveler = await _context.Traveler.FindAsync(id);
            if (traveler == null)
            {
                return NotFound();
            }
            return View(traveler);
        }

        // POST: Travelers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, TravelAgent")]
        public async Task<IActionResult> Edit(int id, [Bind("TravelerId,FirstName,LastName,Email")] Traveler traveler)
        {
            if (id != traveler.TravelerId)
            {
                return NotFound();
            }
            ModelState.Remove("Bookings");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(traveler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelerExists(traveler.TravelerId))
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
            return View(traveler);
        }

        // GET: Travelers/Delete/5
        [Authorize(Roles = "Admin, TravelAgent")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traveler = await _context.Traveler
                .FirstOrDefaultAsync(m => m.TravelerId == id);
            if (traveler == null)
            {
                return NotFound();
            }

            return View(traveler);
        }

        // POST: Travelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, TravelAgent")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var traveler = await _context.Traveler.FindAsync(id);
            if (traveler != null)
            {
                _context.Traveler.Remove(traveler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelerExists(int id)
        {
            return _context.Traveler.Any(e => e.TravelerId == id);
        }
    }
}
