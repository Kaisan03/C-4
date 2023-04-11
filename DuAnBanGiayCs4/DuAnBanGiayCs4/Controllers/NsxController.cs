using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using DuAnBanGiayCs4.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace DuAnBanGiayCs4.Controllers
{
    public class NsxController : Controller
    {
        private readonly ILogger<NsxController> _logger;
        private readonly INsxServices nsxServices;
        public NsxController(ILogger<NsxController> logger)
        {
            nsxServices = new NsxServices();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowListNsx()
        {
            List<Nsx> nsx = nsxServices.GetAllNsx();
            return View(nsx);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Nsx a)
        {
            if (nsxServices.CreateNsx(a))
            {
                return RedirectToAction("ShowListNsx");
            }
            else
                return BadRequest();
        }
        public IActionResult Details(Guid id)
        {
            ShopDbContext shopDbContext = new ShopDbContext();
            var nsx = shopDbContext.Nsxes.Find(id);
            return View(nsx);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Nsx nsx = nsxServices.GetNsxById(id);
            return View(nsx);
        }
        public IActionResult Edit(Nsx a)
        {
            if (nsxServices.UpdateNsx(a))
            {
                return RedirectToAction("ShowListNsx");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (nsxServices.DeleteNsx(id))
            {
                return RedirectToAction("ShowListNsx");
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
