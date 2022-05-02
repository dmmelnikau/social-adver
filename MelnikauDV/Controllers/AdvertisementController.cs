using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MelnikauDV.Models;
using Microsoft.AspNetCore.Authorization;
using PusherServer;
namespace MelnikauDV.Controllers
{
   
    public class AdvertisementController : Controller
    {
        private readonly AdvertisementContext _context;

        public AdvertisementController(AdvertisementContext context)
        {
            _context = context;
        }

        // GET: Advertisement
        [Authorize(Roles = "admin,user,manager")]
        public async Task<IActionResult> Index(int page=1)
        {
            int pageSize = 3;   // количество элементов на странице

            IQueryable<Advertisement> source = _context.Advertisements;
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Advertisements = items
            };
            return View(viewModel);
           
        }
        [Authorize(Roles = "admin,user,manager")]
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }
        [Authorize(Roles = "admin,user,manager")]
        public async Task<IActionResult> ShowSearchResult(String SearchPhrase)
        {
            return View(await _context.Advertisements.Where( j=>j.Company.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Advertisement/Details/5
        [Authorize(Roles = "admin,user,manager")]
        public async Task<IActionResult> Details(int? id, int page=1)
        {
            int pageSize = 1;   // количество элементов на странице

            IQueryable<Advertisement> source = _context.Advertisements;
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Advertisements = items
            };
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Advertisements
                .FirstOrDefaultAsync(m => m.AdvertisementId == id);
            if (advertisement == null)
            {
                return NotFound();
            }
            var visitors = 0;

            if (System.IO.File.Exists("visitors.txt"))
            {
                string noOfVisitors = System.IO.File.ReadAllText("visitors.txt");
                visitors = Int32.Parse(noOfVisitors);
            }

            ++visitors;
            var visit_text = (visitors == 1) ? " просмотр" : " просмотров";

            System.IO.File.WriteAllText("visitors.txt", visitors.ToString());

            var options = new PusherOptions();
            options.Cluster = "PUSHER_APP_CLUSTER";

            var pusher = new Pusher(
            "PUSHER_APP_ID",
            "PUSHER_APP_KEY",
            "PUSHER_APP_SECRET", options);

            pusher.TriggerAsync(
            "general",
            "newVisit",
            new { visits = visitors.ToString(), message = visit_text });

            ViewData["visitors"] = visitors;
            ViewData["visitors_txt"] = visit_text;


            return View(viewModel);
        }

        // GET: Advertisement/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create(int id=0)
        {
            return View(new Advertisement());
        }

        // POST: Advertisement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("AdvertisementId,Company,Text")] Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advertisement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(advertisement);
        }

        // GET: Advertisement/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id, bool like)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Advertisements.FindAsync(id);
            if (like)
            {
                advertisement.NumberOfLikes++;
            }
            else
            {
                advertisement.NumberOfDislikes++;
            }
            _context.Update(advertisement);
            await _context.SaveChangesAsync();
            return View( await _context.Advertisements.ToListAsync());
        }

        // POST: Advertisement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("AdvertisementId,Company,Text")] Advertisement advertisement)
        {
            if (id != advertisement.AdvertisementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advertisement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertisementExists(advertisement.AdvertisementId))
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
            return View(advertisement);
        }
        [Authorize(Roles = "admin")]
        // GET: Advertisement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Advertisements
                .FirstOrDefaultAsync(m => m.AdvertisementId == id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // POST: Advertisement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advertisement = await _context.Advertisements.FindAsync(id);
            _context.Advertisements.Remove(advertisement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "admin")]
        private bool AdvertisementExists(int id)
        {
            return _context.Advertisements.Any(e => e.AdvertisementId == id);
        }
    }
}
