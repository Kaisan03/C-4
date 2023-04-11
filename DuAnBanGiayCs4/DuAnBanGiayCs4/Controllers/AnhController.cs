using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using DuAnBanGiayCs4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DuAnBanGiayCs4.Controllers
{
    public class AnhController : Controller
    {
        private readonly ILogger<AnhController> _logger;
        private readonly IAnhServices anhServices;
        public AnhController(ILogger<AnhController> logger)
        {
            anhServices = new AnhServices();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowListAnh()
        {
            List<Anh> anh = anhServices.GetAllAnh();
            return View(anh);
        }
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Anh a, [Bind] IFormFile imageFile, [Bind] IFormFile imageFile1, [Bind] IFormFile imageFile2, [Bind] IFormFile imageFile3)
        {
            var x = imageFile.FileName;
            if (imageFile != null && imageFile.Length > 0)//Không null và trống
            {
                //trỏ tới thư mục wwwroot để lát nữa thực hiện copy sang
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Anh", imageFile.FileName);
                var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Anh", imageFile1.FileName);
                var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Anh", imageFile2.FileName);
                var path3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Anh", imageFile3.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    //Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile.CopyTo(stream);
                    
                }
                using (var stream = new FileStream(path1, FileMode.Create))
                {
                    //Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile1.CopyTo(stream);

                }
                using (var stream = new FileStream(path2, FileMode.Create))
                {
                    //Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile2.CopyTo(stream);

                }
                using (var stream = new FileStream(path3, FileMode.Create))
                {
                    //Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile3.CopyTo(stream);

                }

                // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                a.Url = imageFile.FileName;
                a.Url1= imageFile1.FileName;
                a.Url2= imageFile2.FileName;
                a.Url3 = imageFile3.FileName;
            }
            if (anhServices.CreateAnh(a))
            {
                return RedirectToAction("ShowListAnh");
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
            Anh anh = anhServices.GetAnhById(id);
            return View(anh);
        }
        public IActionResult Edit(Anh a)
        {
            if(anhServices.UpdateAnh(a))
            {
                return RedirectToAction("ShowListAnh");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (anhServices.DeleteAnh(id))
            {
                return RedirectToAction("ShowListAnh");
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
