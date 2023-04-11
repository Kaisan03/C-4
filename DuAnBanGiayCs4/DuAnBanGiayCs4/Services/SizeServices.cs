using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.Services
{
    public class SizeServices : ISizeServices
    {
        ShopDbContext context;
        public SizeServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateSize(Size sz)
        {
            try
            {
                context.Sizes.Add(sz);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteSize(Guid id)
        {
            try
            {
                var size = context.Sizes.Find(id);
                context.Remove(size);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Size> GetAllSize()
        {
            return context.Sizes.ToList();
        }

        public Size GetSizeById(Guid id)
        {
            return context.Sizes.FirstOrDefault(x => x.Id == id);
        }

        public List<Size> GetSizeByName(int name)
        {
            return context.Sizes.Where(x => x.SoSize == name).ToList();
        }

        public bool UpdateSize(Size sz)
        {
            try
            {
                var size = context.Sizes.Find(sz.Id);
                size.SoSize = sz.SoSize;
                size.TrangThai = sz.TrangThai;
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
