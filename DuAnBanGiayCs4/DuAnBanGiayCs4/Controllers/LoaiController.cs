using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using DuAnBanGiayCs4.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DuAnBanGiayCs4.Controllers
{
    public class LoaiController : Controller
    {
        private readonly ILogger<LoaiController> _logger;
        private readonly ILoaiServices loaiService;
        public LoaiController(ILogger<LoaiController> logger)
        {
            loaiService = new LoaiServices();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowListLoai()
        {
            List<Loai> loai = loaiService.GetAllLoai();
            return View(loai);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Loai a)
        {
            if (loaiService.CreateLoai(a))
            {
                return RedirectToAction("ShowListLoai");
            }
            else
                return BadRequest();
        }
        public IActionResult Details(Guid id)
        {
            ShopDbContext shopDbContext = new ShopDbContext();
            var anh = shopDbContext.Anhs.Find(id);
            return View(anh);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Loai loai = loaiService.GetLoaiById(id);
            return View(loai);
        }
        public IActionResult Edit(Loai a)
        {
            if (loaiService.UpdateLoai(a))
            {
                return RedirectToAction("ShowListLoai");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (loaiService.DeleteLoai(id))
            {
                return RedirectToAction("ShowListLoai");
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
