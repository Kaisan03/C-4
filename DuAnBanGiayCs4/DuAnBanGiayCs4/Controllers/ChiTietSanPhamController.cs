using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using DuAnBanGiayCs4.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace DuAnBanGiayCs4.Controllers
{
    public class ChiTietSanPhamController : Controller
    {
        private readonly ILogger<ChiTietSanPhamController> _logger;
        private readonly IChiTietSanPhamServices chiTietSanPhamServices;
        ShopDbContext context;
        public ChiTietSanPhamController(ILogger<ChiTietSanPhamController> logger)
        {
            chiTietSanPhamServices = new ChiTietSanPhamServices();
            context = new ShopDbContext();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowListCtsp()
        {

            var lst= context.ChiTietSanPhams.Include("MauSac").Include("Nsx").Include("SanPham").Include("Size").Include("Anh").Include("Loai").ToList();
            return View(lst);
        }
        public IActionResult Create()
        {
            
            ViewBag.SanPham = new SelectList(context.SanPhams, "Id", "TenSp");
            ViewBag.Anh = new SelectList(context.Anhs, "Id", "TenAnh");
            ViewBag.Size = new SelectList(context.Sizes, "Id", "SoSize");
            ViewBag.MauSac = new SelectList(context.MauSacs, "Id", "TenMau");
            ViewBag.Nsx = new SelectList(context.Nsxes, "Id", "TenNsx");
            ViewBag.Loai = new SelectList(context.Loais, "Id", "TenLoai");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ChiTietSanPham a)
        {
            if (chiTietSanPhamServices.CreateChiTietSanPham(a))
            {
                return RedirectToAction("ShowListCtsp");
            }
            else
                return BadRequest();
        }
        public IActionResult Details(Guid id)
        {
            ShopDbContext shopDbContext = new ShopDbContext();
            var ctsp = shopDbContext.ChiTietSanPhams.Find(id);
            return View(ctsp);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            ChiTietSanPham ctsp = chiTietSanPhamServices.GetChiTietSanPhamById(id);
            return View(ctsp);
        }
        public IActionResult Edit(ChiTietSanPham a)
        {
            if (chiTietSanPhamServices.UpdateChiTietSanPham(a))
            {
                return RedirectToAction("ShowListCtsp");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (chiTietSanPhamServices.DeleteChiTietSanPham(id))
            {
                return RedirectToAction("ShowListCtsp");
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
