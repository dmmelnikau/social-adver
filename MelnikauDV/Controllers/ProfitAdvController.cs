using MelnikauDV.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelnikauDV.Controllers
{
    [Authorize(Roles = "manager")]
    public class ProfitAdvController : Controller
    {
        private readonly AdvertisementContext _context;

        public ProfitAdvController(AdvertisementContext context)
        {
            _context = context;
        }

        // GET: ProfitAdv
        public async Task<IActionResult> Index()
        {
            var advertisementContext = _context.ProfitAdvs.Include(p => p.Advertisement);
            return View(await advertisementContext.ToListAsync());
        }

        // GET: ProfitAdv/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profitAdv = await _context.ProfitAdvs
                .Include(p => p.Advertisement)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profitAdv == null)
            {
                return NotFound();
            }

            return View(profitAdv);
        }

        // GET: ProfitAdv/Create
        public IActionResult Create()
        {
            ViewData["AdvertisementId"] = new SelectList(_context.Advertisements, "AdvertisementId", "Company");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Effort,PageViews,AdvertisementId")] ProfitAdv profitAdv)
        {
        
            if (ModelState.IsValid)
            {
                _context.Add(profitAdv);
                if(profitAdv.Effort>0 && profitAdv.Effort<=4000)
                {
                    profitAdv.kef = 2;
                }
               else  if (profitAdv.Effort > 4000 && profitAdv.Effort <= 10000)
                {
                    profitAdv.kef = 5;
                }
                else if (profitAdv.Effort > 10000 && profitAdv.Effort <= 50000)
                {
                    profitAdv.kef = 11;
                }
                else 
                {
                    profitAdv.kef = 18;
                }
                profitAdv.Profit = (int)(profitAdv.kef*profitAdv.PageViews/1000-profitAdv.Effort/profitAdv.kef/10);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
          

            ViewData["AdvertisementId"] = new SelectList(_context.Advertisements, "AdvertisementId", "Company", profitAdv.AdvertisementId);
            return View(profitAdv);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profitAdv = await _context.ProfitAdvs.FindAsync(id);
            if (profitAdv == null)
            {
                return NotFound();
            }
            ViewData["AdvertisementId"] = new SelectList(_context.Advertisements, "AdvertisementId", "Company", profitAdv.AdvertisementId);
            return View(profitAdv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Effort,PageViews,kef,Profit,AdvertisementId")] ProfitAdv profitAdv)
        {
            if (id != profitAdv.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profitAdv);
                    if (profitAdv.Effort > 0 && profitAdv.Effort <= 4000)
                    {
                        profitAdv.kef = 2;
                    }
                    else if (profitAdv.Effort > 4000 && profitAdv.Effort <= 10000)
                    {
                        profitAdv.kef = 5;
                    }
                    else if (profitAdv.Effort > 10000 && profitAdv.Effort <= 50000)
                    {
                        profitAdv.kef = 11;
                    }
                    else
                    {
                        profitAdv.kef = 18;
                    }
                    profitAdv.Profit = (int)(profitAdv.kef * profitAdv.PageViews / 1000 - profitAdv.Effort / profitAdv.kef / 10);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfitAdvExists(profitAdv.Id))
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
            ViewData["AdvertisementId"] = new SelectList(_context.Advertisements, "AdvertisementId", "Company", profitAdv.AdvertisementId);
            return View(profitAdv);
        }

        // GET: ProfitAdv/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profitAdv = await _context.ProfitAdvs
                .Include(p => p.Advertisement)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profitAdv == null)
            {
                return NotFound();
            }

            return View(profitAdv);
        }

        // POST: ProfitAdv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profitAdv = await _context.ProfitAdvs.FindAsync(id);
            _context.ProfitAdvs.Remove(profitAdv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfitAdvExists(int id)
        {
            return _context.ProfitAdvs.Any(e => e.Id == id);
        }
      
        public ActionResult Filter(int? company, int pr)
        {
            IQueryable<ProfitAdv> profitAdvs = _context.ProfitAdvs.Include(p => p.Advertisement);
            if (company != null && company != 0)
            {
                profitAdvs = profitAdvs.Where(p => p.AdvertisementId == company);
            }
            if (pr>0)
            {
                profitAdvs = profitAdvs.Where(p => p.Profit == pr);
            }

            List<Advertisement> companies = _context.Advertisements.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            companies.Insert(0, new Advertisement { Company = "Все", AdvertisementId = 0 });

            Filter viewModel = new Filter
            {
                Profits = profitAdvs.ToList(),
                Advertisements = new SelectList(companies, "AdvertisementId", "Company"),
                Profit = pr
            };
            return View(viewModel);
        }
    }
}
