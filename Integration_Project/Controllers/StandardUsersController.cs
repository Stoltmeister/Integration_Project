using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Integration_Project.Data;
using Integration_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;

namespace Integration_Project.Controllers
{
    public class StandardUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StandardUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StandardUsers
        public async Task<IActionResult> Index()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var standardUser = await _context.StandardUsers.Where(u => u.ApplicationUserId == currentUser.Identity.GetUserId()).SingleAsync();
            return View(standardUser);
        }

        // GET: StandardUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standardUser = await _context.StandardUsers
                .Include(s => s.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (standardUser == null)
            {
                return NotFound();
            }

            return View(standardUser);
        }

        // GET: StandardUsers/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            return View();
        }

        // POST: StandardUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationUserId,Bio,FirstName,LastName,Email,City,State,ZipCode")] StandardUser standardUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(standardUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", standardUser.ApplicationUserId);
            return View(standardUser);
        }

        // GET: StandardUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standardUser = await _context.StandardUsers.FindAsync(id);
            if (standardUser == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", standardUser.ApplicationUserId);
            return View(standardUser);
        }

        // POST: StandardUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,ApplicationUserId,Bio,FirstName,LastName,Email,City,State,ZipCode")] StandardUser standardUser)
        {
            if (id != standardUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(standardUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StandardUserExists(standardUser.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", standardUser.ApplicationUserId);
            return View(standardUser);
        }

        // GET: StandardUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standardUser = await _context.StandardUsers
                .Include(s => s.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (standardUser == null)
            {
                return NotFound();
            }

            return View(standardUser);
        }

        // POST: StandardUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var standardUser = await _context.StandardUsers.FindAsync(id);
            _context.StandardUsers.Remove(standardUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StandardUserExists(string id)
        {
            return _context.StandardUsers.Any(e => e.Id == id);
        }
    }
}
