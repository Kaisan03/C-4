using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using DuAnBanGiayCs4.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

namespace DuAnBanGiayCs4.Controllers
{
    public class MauSacController : Controller
    {
        private readonly ILogger<MauSacController> _logger;
        private readonly IMauSacServices mauSacServices;
        public MauSacController(ILogger<MauSacController> logger)
        {
            mauSacServices = new MauSacServices();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowListMau()
        {
            List<MauSac> mauSacs = mauSacServices.GetAllMauSac();
            return View(mauSacs);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MauSac a)
        {
            if (mauSacServices.CreateMauSac(a))
            {
                return RedirectToAction("ShowListMau");
            }
            else
                return BadRequest();
        }
        public IActionResult Details(Guid id)
        {
            ShopDbContext shopDbContext = new ShopDbContext();
            var mauSac = shopDbContext.MauSacs.Find(id);
            return View(mauSac);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            MauSac mau = mauSacServices.GetMauSacById(id);
            return View(mau);
        }
        public IActionResult Edit(MauSac a)
        {
            if (mauSacServices.UpdateMauSac(a))
            {
                return RedirectToAction("ShowListMau");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (mauSacServices.DeleteMauSac(id))
            {
                return RedirectToAction("ShowListMau");
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
