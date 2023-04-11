using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using DuAnBanGiayCs4.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DuAnBanGiayCs4.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ILogger<SanPhamController> _logger;
        private readonly ISanPhamServices sanPhamServices;
        public SanPhamController(ILogger<SanPhamController> logger)
        {
            sanPhamServices = new SanPhamServices();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowListSp()
        {
            List<SanPham> sp = sanPhamServices.GetAllSanPham();
            return View(sp);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SanPham a)
        {
            if (sanPhamServices.CreateSanPham(a))
            {
                return RedirectToAction("ShowListSp");
            }
            else
                return BadRequest();
        }
        public IActionResult Details(Guid id)
        {
            ShopDbContext shopDbContext = new ShopDbContext();
            var sp = shopDbContext.SanPhams.Find(id);
            return View(sp);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            SanPham sp = sanPhamServices.GetSanPhamById(id);
            return View(sp);
        }
        public IActionResult Edit(SanPham a)
        {
            if (sanPhamServices.UpdateSanPham(a))
            {
                return RedirectToAction("ShowListSp");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (sanPhamServices.DeleteSanPham(id))
            {
                return RedirectToAction("ShowListSp");
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
