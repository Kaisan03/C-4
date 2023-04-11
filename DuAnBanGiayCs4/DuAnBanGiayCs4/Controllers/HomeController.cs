using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using DuAnBanGiayCs4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace DuAnBanGiayCs4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChiTietSanPhamServices chiTietSanPhamServices;
        private readonly IGioHangChiTietServices gioHangChiTietServices;
        private readonly IMauSacServices mauSacServices;
        private readonly ISizeServices sizeServices;
        private readonly IUserServices userServices;
        private readonly IGioHangServices gioHangServices;
        private readonly IHoaDonChiTietServices hoaDonChiTietServices;
        private readonly IHoaDonServices hoaDonServices;
        ShopDbContext context;

        public HomeController(ILogger<HomeController> logger)
        {
            chiTietSanPhamServices = new ChiTietSanPhamServices();
            gioHangChiTietServices = new GioHangChiTietServices();
            mauSacServices = new MauSacServices();
            sizeServices = new SizeServices();
            userServices = new UserServices();
            hoaDonChiTietServices=new HoaDonChiTietServices();
            hoaDonServices = new HoaDonServices();
            gioHangServices = new GioHangServices();
            context = new ShopDbContext();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult TrangChu()
        {
            return View();
        }

        public IActionResult SanPham()
        {
            var lst = context.ChiTietSanPhams.Include("MauSac").Include("Nsx").Include("SanPham").Include("Size").Include("Anh").Include("Loai").ToList();
            return View(lst);
        }


        public IActionResult Details(Guid id)
        {
            ShopDbContext shopDbContext = new ShopDbContext();
            var ctsp = shopDbContext.ChiTietSanPhams.Find(id);
            var anh = shopDbContext.Anhs.FirstOrDefault(x => x.Id == ctsp.IdAnh);
            var sp = shopDbContext.SanPhams.FirstOrDefault(x => x.Id == ctsp.IdSp);
            var size = shopDbContext.Sizes.FirstOrDefault(x => x.Id == ctsp.IdSize);
            var Nsx = shopDbContext.Nsxes.FirstOrDefault(x => x.Id == ctsp.IdNsx);
            var mau = shopDbContext.MauSacs.FirstOrDefault(x => x.Id == ctsp.IdColor);
            var loai = shopDbContext.Loais.FirstOrDefault(x => x.Id == ctsp.IdLoai);
            var viewDetails = new ChiTietSanPham()
            {
                Id = ctsp.Id,
                Anh = anh,
                SanPham = sp,
                Nsx= Nsx,
                MauSac = mau,
                Loai=loai,
                Size = size,
                GiaBan = ctsp.GiaBan,
                GiaNhap = ctsp.GiaNhap,
                MoTa= ctsp.MoTa,
                SoLuongTon = ctsp.SoLuongTon,
                TrangThai = ctsp.TrangThai
            };
            var sanPham = chiTietSanPhamServices.GetAllChiTietSanPham().Where(x => x.SanPham.TenSp == ctsp.SanPham.TenSp && x.Nsx.TenNsx == ctsp.Nsx.TenNsx && x.Loai.TenLoai == ctsp.Loai.TenLoai);
            var listSize = new SelectList(sizeServices.GetAllSize().Where(x=>sanPham.Any(y=>y.IdSize==x.Id)).ToList(), "Id", "SoSize");
            ViewBag.Size = listSize;
            var listColor = new SelectList(mauSacServices.GetAllMauSac().Where(x => sanPham.Any(y=>y.IdColor==x.Id)).ToList(), "Id","TenMau");
            ViewBag.Color = listColor;
            return View(viewDetails);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            ChiTietSanPham ctsp = chiTietSanPhamServices.GetChiTietSanPhamById(id);
            return View(ctsp);
        }
        public IActionResult Edit(ChiTietSanPham a)
        {
            TempData["UpdateSuccess"] = "Thêm thành công";
            var ctsp =context.ChiTietSanPhams.Find(a.Id);
            if (a.GiaBan<= ctsp.GiaBan)
            {
                ViewBag.UpdateSuccess = TempData["UpdateSuccess"];
                chiTietSanPhamServices.UpdateChiTietSanPham(a);
                return RedirectToAction("SanPham");
            }
            else return RedirectToAction("SanPham"); 
        }
        [HttpPost]
        public IActionResult AddToCart(Guid id,int n)
        {
            var userLogin = userServices.GetUserByName(HttpContext.Session.GetString("UserName"));
            var gioHang = gioHangServices.GetAllGioHang().FirstOrDefault(x => x.IdNguoiDung == userLogin.Id);
            HashSet<GioHangChiTiet> setProductInCart = new HashSet<GioHangChiTiet>();
            setProductInCart = new HashSet<GioHangChiTiet>(gioHangChiTietServices.GetGioHangChiTietByName(userLogin.Id));
            bool CheckExit = setProductInCart.Any(x => x.IdCtsp == id);
            if (CheckExit)
            {
                var cartDetail = setProductInCart.FirstOrDefault(x => x.IdCtsp == id);
                cartDetail.SoLuong += n;
                gioHangChiTietServices.UpdateGioHangChiTiet(cartDetail);
            }
            else
            {
                var newCartDetail = new GioHangChiTiet();
                newCartDetail.IdCtsp = id;
                newCartDetail.SoLuong = n;
                newCartDetail.Gia = chiTietSanPhamServices.GetChiTietSanPhamById(id).GiaBan;
                newCartDetail.IdGioHang = gioHang.Id;
                newCartDetail.TrangThai = 1;
                gioHangChiTietServices.CreateGioHangChiTiet(newCartDetail);
            }
            return Ok();
        }
        public IActionResult ShowCart()
        {

            var userCart = userServices.GetUserByName(HttpContext.Session.GetString("UserName"));
            var cartDetails= gioHangChiTietServices.GetGioHangChiTietByName(userCart.Id);
            var lst = context.GioHangChiTiets.Include(g=>g.GioHang).Include(c=>c.ChiTietSanPham).ThenInclude(d=>d.Anh).ToList();
            return View(cartDetails);
        }
        public IActionResult ThanhToan()
        {
            var idUser = userServices.GetUserByName(HttpContext.Session.GetString("UserName")).Id;
            var listCartDetail = gioHangChiTietServices.GetGioHangChiTietByName(idUser);
            var Chuoi = "";
            var outOfStockProducts = listCartDetail
                             .Where(item => item.SoLuong > chiTietSanPhamServices.GetChiTietSanPhamById(item.IdCtsp).SoLuongTon)
                             .Select(item => '"' + chiTietSanPhamServices.GetChiTietSanPhamById(item.IdCtsp).SanPham.TenSp + '"');
            Chuoi = string.Join(" ", outOfStockProducts);

            if (listCartDetail.Any())
            {
                if (Chuoi == "")
                {
                    var newBill = new HoaDon()
                    {
                        Id = Guid.NewGuid(),
                        IdNguoiDung = idUser,
                        NgayTao = DateTime.Now,
                        TongTien = listCartDetail.Sum(x => x.Gia * x.SoLuong)

                    };
                    hoaDonServices.CreateHoaDon(newBill);
                    foreach (var item in listCartDetail)
                    {
                        hoaDonChiTietServices.CreateHoaDonChiTiet(new HoaDonChiTiet
                        {
                            Id = Guid.NewGuid(),
                            IdHD = newBill.Id,
                            IdCtsp = item.IdCtsp,
                            SoLuong = item.SoLuong,
                            Gia = item.Gia
                        });
                        gioHangChiTietServices.DeleteGioHangChiTiet(item.Id);
                        var product = chiTietSanPhamServices.GetChiTietSanPhamById(item.IdCtsp);
                        product.SoLuongTon -= item.SoLuong;
                        chiTietSanPhamServices.UpdateChiTietSanPham(product);
                    }
                    ViewBag.Message = "Thông báo thành công!";
                    TempData["Message"] = "Thanh toán thành công";
                    TempData["MessageType"] = "success";
                }
                else
                {
                    TempData["Message"] = "Xin lỗi! Sản phẩm: " + Chuoi + " hiện tại số lượng tồn không đủ! Vui lòng chọn lại số lượng.";
                    TempData["MessageType"] = "success";
                }
                return RedirectToAction("SanPham");
            }
            else return View("SanPham");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}