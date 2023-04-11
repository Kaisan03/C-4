using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;

namespace DuAnBanGiayCs4.Services
{
    public class LoaiServices : ILoaiServices
    {
        ShopDbContext context;
        public LoaiServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateLoai(Loai loai)
        {
            try
            {
                context.Loais.Add(loai);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteLoai(Guid id)
        {
            try
            {
                var loai = context.Loais.Find(id);
                context.Loais.Remove(loai);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Loai> GetAllLoai()
        {
            return context.Loais.ToList();
        }

        public Loai GetLoaiById(Guid id)
        {
            return context.Loais.FirstOrDefault(x => x.Id == id);
        }

        public List<Loai> GetLoaiByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLoai(Loai loai)
        {
            try
            {
                var _loai = context.Loais.Find(loai);
                _loai.TenLoai = loai.TenLoai;
                _loai.TrangThai = loai.TrangThai;
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
