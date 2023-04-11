using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;

namespace DuAnBanGiayCs4.Services
{
    public class GioHangServices : IGioHangServices
    {
        ShopDbContext context;
        public GioHangServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateGioHang(GioHang gh)
        {
            try
            {
                context.GioHangs.Add(gh);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteGioHang(Guid id)
        {
            try
            {
                var gh = context.GioHangs.FirstOrDefault(h => h.Id == id);
                context.GioHangs.Remove(gh);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<GioHang> GetAllGioHang()
        {
            return context.GioHangs
                .Join(context.Users,p=>p.IdNguoiDung,i=>i.Id,(p,i)=> new {GioHang=p, User=i})
                .Select(g => new GioHang
                {
                    Id=g.GioHang.Id,
                    IdNguoiDung=g.GioHang.IdNguoiDung,
                    TrangThai =g.GioHang.TrangThai
                    
                }).ToList();
        }

        public GioHang GetGioHangById(Guid id)
        {
            return context.GioHangs.FirstOrDefault(x=>x.Id==id);
        }

        public List<GioHang> GetGioHangByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGioHang(GioHang gh)
        {
            try
            {
                var _gh = context.GioHangs.Find(gh.Id);
                _gh.TrangThai = gh.TrangThai;
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
