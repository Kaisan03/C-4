using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.Services
{
    public class AnhServices : IAnhServices
    {
        ShopDbContext context;
        public AnhServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateAnh(Anh anh)
        {
            try
            {
                context.Anhs.Add(anh);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteAnh(Guid id)
        {
            try
            {
                var anh = context.Anhs.Find(id);
                context.Anhs.Remove(anh);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Anh> GetAllAnh()
        {
            return context.Anhs.ToList();
        }

        public Anh GetAnhById(Guid id)
        {
            return context.Anhs.FirstOrDefault(x => x.Id == id);
        }

        public List<Anh> GetAnhByName(string name)
        {
            return context.Anhs.Where(x=>x.TenAnh==name).ToList();
        }

        public bool UpdateAnh(Anh anh)
        {
            try
            {
                var anh1 = context.Anhs.Find(anh.Id);
                anh1.TenAnh = anh.TenAnh;
                anh1.TrangThai = anh.TrangThai;
                anh1.Url = anh.Url;
                anh1.Url1 = anh.Url1;
                anh1.Url2 = anh.Url2;
                anh1.Url3 = anh.Url3;
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
