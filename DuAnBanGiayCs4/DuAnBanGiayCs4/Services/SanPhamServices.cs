using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.Services
{
    public class SanPhamServices : ISanPhamServices
    {
        ShopDbContext context;
        public SanPhamServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateSanPham(SanPham sp)
        {
            try
            {
                context.SanPhams.Add(sp);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteSanPham(Guid id)
        {
            try
            {
                var sanPham = context.SanPhams.Find(id);
                context.Remove(sanPham);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<SanPham> GetAllSanPham()
        {
            return context.SanPhams.ToList();

        }

        public SanPham GetSanPhamById(Guid id)
        {
            return context.SanPhams.FirstOrDefault(x => x.Id == id);
        }

        public List<SanPham> GetSanPhamByName(string name)
        {
           return context.SanPhams.Where(x=>x.TenSp==name).ToList();
        }

        public bool UpdateSanPham(SanPham sp)
        {
            try
            {
                var sanPham = context.SanPhams.Find(sp.Id);
                sanPham.TenSp = sp.TenSp;
                sanPham.TrangThai = sp.TrangThai;
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
