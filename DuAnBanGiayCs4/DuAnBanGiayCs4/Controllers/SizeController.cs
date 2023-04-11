using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using DuAnBanGiayCs4.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DuAnBanGiayCs4.Controllers
{
    public class SizeController : Controller
    {
        private readonly ILogger<SizeController> _logger;
        private readonly ISizeServices sizeServices;
        public SizeController(ILogger<SizeController> logger)
        {
            sizeServices = new SizeServices();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowListSize()
        {
            List<Size> sz = sizeServices.GetAllSize();
            return View(sz);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Size a)
        {
            if (sizeServices.CreateSize(a))
            {
                return RedirectToAction("ShowListSize");
            }
            else
                return BadRequest();
        }
        public IActionResult Details(Guid id)
        {
            ShopDbContext shopDbContext = new ShopDbContext();
            var sz = shopDbContext.Sizes.Find(id);
            return View(sz);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Size sz = sizeServices.GetSizeById(id);
            return View(sz);
        }
        public IActionResult Edit(Size a)
        {
            if (sizeServices.UpdateSize(a))
            {
                return RedirectToAction("ShowListSize");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (sizeServices.DeleteSize(id))
            {
                return RedirectToAction("ShowListSize");
            }
            else return BadRequest();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
