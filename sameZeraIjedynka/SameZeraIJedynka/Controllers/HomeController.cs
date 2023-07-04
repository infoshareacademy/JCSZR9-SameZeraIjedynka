using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SameZeraIjedynka.Database.Context;
using SameZeraIJedynka.BusinnessLogic.Models;
using System.Diagnostics;

namespace SameZeraIJedynka.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DatabaseContext mvcDbContext;

        public HomeController(DatabaseContext mvcDbContext, ILogger<HomeController> logger)  //constructor //in bracket injected service. Pres dot+CTRL to create an asign field
        {
            this.mvcDbContext = mvcDbContext;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var events = await mvcDbContext.Events.Take(3).ToListAsync();
            return View(events);
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