using MelnikauDV.Models;
using MelnikauDV.Models.Information;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MelnikauDV.Controllers
{
    [Authorize]
    public class HomeController : Controller

    {
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            Information inf = new Information();
            inf.SomeInf("Узнайте больше о рекламе");
            ViewData["Message"]=inf.InfAdv.Inf;
            if (User.Identity.IsAuthenticated)
            {
                return View(inf);
            }
            return View(inf);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
