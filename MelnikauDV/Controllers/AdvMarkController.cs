using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MelnikauDV.Models;
using Microsoft.AspNetCore.Authorization;

namespace MelnikauDV.Controllers
{
    /*[Authorize(Roles = "admin,user,manager")]
    public class AdvMarkController : Controller
    {
        private readonly AdvertisementContext _context;

        public AdvMarkController(AdvertisementContext context)
        {
            _context = context;
        }

        // GET: AdvMark
 
public async Task<IActionResult> Index(string sortOrder)
        {
            var advertisementContext = _context.AdvMark.Include(a => a.Advertisement).Include(a => a.User).AsQueryable();
            ViewData["MarkSortParm"] = String.IsNullOrEmpty(sortOrder) ? "mark_desc" : "";
            //  var students = from s in _context.AdvMark
            //            select s;
            switch (sortOrder)
            {
                case "mark_desc":
                    advertisementContext = advertisementContext.OrderByDescending(s => s.Mark);
                    break;

                default:
                    advertisementContext = advertisementContext.OrderBy(s => s.Mark);
                    break;
            }
            return View(await advertisementContext.ToListAsync());


        }


        // GET: AdvMark/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advMark = await _context.AdvMark
                .Include(a => a.Advertisement)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AdvertisementId == id);
            if (advMark == null)
            {
                return NotFound();
            }

            return View(advMark);
        }

        // GET: AdvMark/Create
        public IActionResult Create()
        {
            ViewData["AdvertisementId"] = new SelectList(_context.Advertisements, "AdvertisementId", "Company");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: AdvMark/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mark,AdvertisementId,UserId")] AdvMark advMark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advMark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdvertisementId"] = new SelectList(_context.Advertisements, "AdvertisementId", "Company", advMark.AdvertisementId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", advMark.UserId);
            return View(advMark);
        }

        // GET: AdvMark/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advMark = await _context.AdvMark.FindAsync(id);
            if (advMark == null)
            {
                return NotFound();
            }
            ViewData["AdvertisementId"] = new SelectList(_context.Advertisements, "AdvertisementId", "Company", advMark.AdvertisementId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", advMark.UserId);
            return View(advMark);
        }

        // POST: AdvMark/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Mark,AdvertisementId,UserId")] AdvMark advMark)
        {
            if (id != advMark.AdvertisementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advMark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvMarkExists(advMark.AdvertisementId))
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
            ViewData["AdvertisementId"] = new SelectList(_context.Advertisements, "AdvertisementId", "Company", advMark.AdvertisementId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", advMark.UserId);
            return View(advMark);
        }

        // GET: AdvMark/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advMark = await _context.AdvMark
                .Include(a => a.Advertisement)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AdvertisementId == id);
            if (advMark == null)
            {
                return NotFound();
            }

            return View(advMark);
        }

        // POST: AdvMark/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var advMark = await _context.AdvMark.FindAsync(id);
            _context.AdvMark.Remove(advMark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvMarkExists(int? id)
        {
            return _context.AdvMark.Any(e => e.AdvertisementId == id);
        }
    }*/
}
