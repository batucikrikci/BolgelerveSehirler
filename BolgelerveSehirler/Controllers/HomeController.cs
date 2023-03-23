using BolgelerveSehirler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BolgelerveSehirler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<SelectListItem> bolgeler = Db.Bolgeler().Select(x => new SelectListItem() { Text = x.BolgeAd, Value = x.Id.ToString() }).ToList();

            return View(bolgeler);
        }

        public IActionResult SehirleriGetir(int bolgeId)
        {
            var sehirler = Db.Sehirler().Where(x => x.BolgeId == bolgeId);
            return Json(sehirler);
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