using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using DuAnBanGiayCs4.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Cors.Infrastructure;
using DuAnBanGiayCs4.ViewModel;

namespace DuAnBanGiayCs4.Controllers
{
    public class UserController : Controller
    {

        // GET: UserController
        private readonly ILogger<UserController> _logger;
        private readonly IUserServices userServices;
        private readonly IGioHangServices gioHangServices;
        ShopDbContext context;
        public UserController(ILogger<UserController> logger)
        {
            context = new ShopDbContext();
            userServices = new UserServices();
            gioHangServices = new GioHangServices();
            _logger = logger;
        }
        public IActionResult IndexLogin()
        {
            return View();
        }
        public IActionResult Login(LoginViewModel Model)
        {
            if (ModelState.IsValid)
            {
                if (userServices.GetOneUser(Model.UserName, Model.PassWord) != null)
                {
                    TempData["DangNhap"] = "Đăng nhập thành công";
                    Guid idCartLogin = userServices.GetUserByName(Model.UserName).Id;
                    if (gioHangServices.GetAllGioHang().Find(x => x.Id == idCartLogin) == null)
                    {
                        var myCart = new GioHang();
                        myCart.IdNguoiDung = idCartLogin;
                        myCart.TrangThai = 1;
                        gioHangServices.CreateGioHang(myCart);
                    }
                    HttpContext.Session.SetString("Role", userServices.GetOneUser(Model.UserName, Model.PassWord).ChucVu.TenCv);
                    HttpContext.Session.SetString("UserName", Model.UserName);
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin tài khoản mật khẩu không chính xác!");
                }
            }
            return View("IndexLogin");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("UserName");
            HttpContext.Session.Remove("Role");
            return RedirectToAction("IndexLogin");
        }
        public IActionResult Create()
        {
            ViewBag.ChucVu = new SelectList(context.ChucVus, "Id", "TenCv");
            return View();
        }
        [HttpPost]
        public IActionResult Create(User a)
        {
            if (userServices.CreateUser(a))
            {
                return RedirectToAction("Login");
            }
            else
                return BadRequest();

        }

        // POST: UserController/Create


        // GET: UserController/Edit/5
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
