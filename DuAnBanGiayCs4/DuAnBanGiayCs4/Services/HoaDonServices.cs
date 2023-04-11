using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace DuAnBanGiayCs4.Services
{
    public class HoaDonServices : IHoaDonServices
    {
        ShopDbContext context;
        public HoaDonServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateHoaDon(HoaDon hd)
        {
            try
            {
                context.HoaDons.Add(hd);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteHoaDon(Guid id)
        {
            var hd = context.HoaDons.FirstOrDefault(hd => hd.Id == id);
            context.HoaDons.Remove(hd);
            return true;
        }

        public List<HoaDon> GetAllHoaDon()
        {
            var _lstHd = context.HoaDons
                .Join(context.Users, p => p.IdNguoiDung, i => i.Id, (p, i) => new { HoaDon =p, User=i})
                .Select(pc=>new HoaDon 
                {
                    NgayTao = pc.HoaDon.NgayTao,
                    TongTien = pc.HoaDon.TongTien,
                    
                }).ToList();
            return _lstHd;
        }

        public HoaDon GetHoaDonById(Guid id)
        {
            return context.HoaDons.FirstOrDefault(h => h.Id == id);
        }

        public List<HoaDon> GetHoaDonByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateHoaDon(HoaDon hd)
        {
            try
            {
                var _hd = context.HoaDons.Find(hd.Id);
                _hd.NgayTao = hd.NgayTao;
                _hd.TongTien = hd.TongTien;
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
