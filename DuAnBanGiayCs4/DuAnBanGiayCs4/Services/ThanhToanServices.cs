using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace DuAnBanGiayCs4.Services
{
    public class ThanhToanServices : IThanhToanServices
    {
        ShopDbContext context;
        public ThanhToanServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateThanhToan(ThanhToan th)
        {
            try
            {
                context.ThanhToans.Add(th);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteThanhToan(Guid id)
        {
            try
            {
                var thanhToan = context.ThanhToans.Find(id);
                context.Remove(thanhToan);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<ThanhToan> GetAllSize()
        {
            return context.ThanhToans
                 .Join(context.HoaDons,p=>p.IdHD,i=>i.Id,(p,i)=> new { ThanhToan=p,HoaDon=i})
                 .Select(pc=> new ThanhToan {
                      NgayThanhToan = pc.ThanhToan.NgayThanhToan,
                      PhuongThucThanhToan = pc.ThanhToan.PhuongThucThanhToan,
                      SoTienDaThanhToan = pc.ThanhToan.SoTienDaThanhToan
                 }).ToList();
        }

        public ThanhToan GetThanhToanById(Guid id)
        {
            return context.ThanhToans.FirstOrDefault(x=>x.Id==id);
        }

        public List<ThanhToan> GetThanhToanByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateThanhToan(ThanhToan th)
        {
            try
            {
                var thanhToan = context.ThanhToans.Find(th.Id);
                thanhToan.NgayThanhToan = th.NgayThanhToan;
                thanhToan.SoTienDaThanhToan = th.SoTienDaThanhToan;
                thanhToan.PhuongThucThanhToan = th.PhuongThucThanhToan;
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
