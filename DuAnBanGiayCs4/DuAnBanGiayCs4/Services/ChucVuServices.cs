using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.Services
{
    public class ChucVuServices : IChucVuServices
    {
        ShopDbContext context;
        public ChucVuServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateChucVu(ChucVu cv)
        {
            try
            {
                context.ChucVus.Add(cv);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteChucVu(Guid id)
        {
            try
            {
                var chucVu = context.ChucVus.Find(id);
                context.ChucVus.Remove(chucVu);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<ChucVu> GetAllChucVu()
        {
            return context.ChucVus.ToList();
        }

        public ChucVu GetChucVuById(Guid id)
        {
            return context.ChucVus.FirstOrDefault(x => x.Id == id);
        }

        public List<ChucVu> GetChucVuByName(string name)
        {
            return context.ChucVus.Where(x=>x.TenCv==name).ToList();
        }

        public bool UpdateChucVu(ChucVu cv)
        {
            try
            {
                var chucVu = context.ChucVus.Find(cv.Id);
                chucVu.TenCv = cv.TenCv;
                chucVu.TrangThai = cv.TrangThai;
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
