using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using DuAnBanGiayCs4.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DuAnBanGiayCs4.Controllers
{
    public class ChucVuController : Controller
    {
        private readonly ILogger<ChucVuController> _logger;
        private readonly IChucVuServices chucVuServices;
        public ChucVuController(ILogger<ChucVuController> logger)
        {
            chucVuServices = new ChucVuServices();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowListCv()
        {
            List<ChucVu> cv = chucVuServices.GetAllChucVu();
            return View(cv);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ChucVu a)
        {
            if (chucVuServices.CreateChucVu(a))
            {
                return RedirectToAction("ShowListCv");
            }
            else
                return BadRequest();
        }
        public IActionResult Details(Guid id)
        {
            ShopDbContext shopDbContext = new ShopDbContext();
            var cv = shopDbContext.ChucVus.Find(id);
            return View(cv);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            ChucVu cv = chucVuServices.GetChucVuById(id);
            return View(cv);
        }
        public IActionResult Edit(ChucVu a)
        {
            if (chucVuServices.UpdateChucVu(a))
            {
                return RedirectToAction("ShowListCv");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (chucVuServices.DeleteChucVu(id))
            {
                return RedirectToAction("ShowListCv");
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
