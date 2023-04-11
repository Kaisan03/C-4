using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;

namespace DuAnBanGiayCs4.Services
{
    public class HoaDonChiTietServices : IHoaDonChiTietServices
    {
        ShopDbContext context;
        public HoaDonChiTietServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateHoaDonChiTiet(HoaDonChiTiet hdct)
        {
            try
            {
                context.HoaDonChiTiets.Add(hdct);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteHoaDonChiTiet(Guid id)
        {
            try
            {
                var hdct = context.HoaDonChiTiets.FirstOrDefault(x => x.Id == id);
                context.Remove(hdct);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<HoaDonChiTiet> GetAllHoaDonChiTiet()
        {
            var _lstHdct = context.HoaDonChiTiets
                .Join(context.ChiTietSanPhams,p=>p.IdCtsp,i=>i.Id,(p,i)=> new { HoaDonChiTiet=p,ChiTietSanPham=i })
                .Join(context.HoaDons, pi => pi.HoaDonChiTiet.IdHD, m => m.Id, (pi, m) => new { pi.HoaDonChiTiet,pi.ChiTietSanPham, HoaDon=m})
                .Select(pc=>new HoaDonChiTiet 
                {
                    Id = pc.HoaDonChiTiet.Id,
                    IdCtsp = pc.ChiTietSanPham.Id,
                    IdHD = pc.HoaDon.Id,
                    Gia = pc.HoaDonChiTiet.Gia,
                    SoLuong = pc.HoaDonChiTiet.SoLuong
                }).ToList();
            return _lstHdct;
        }

        public HoaDonChiTiet GetHoaDonChiTietById(Guid id)
        {
            return context.HoaDonChiTiets.FirstOrDefault(x => x.Id == id);
        }

        public List<HoaDonChiTiet> GetHoaDonChiTietByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateHoaDonChiTiet(HoaDonChiTiet hdct)
        {
            try
            {
                var _hdct = context.HoaDonChiTiets.Find(hdct.Id);
                _hdct.Gia = hdct.Gia;
                _hdct.SoLuong = hdct.SoLuong;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
