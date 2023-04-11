using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using System.Runtime.Intrinsics.X86;

namespace DuAnBanGiayCs4.Services
{
    public class MauSacServices : IMauSacServices
    {
        ShopDbContext context;
        public MauSacServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateMauSac(MauSac ms)
        {
            try
            {
                context.MauSacs.Add(ms);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteMauSac(Guid id)
        {
            try
            {
                var mauSac = context.MauSacs.Find(id);
                context.Remove(mauSac);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<MauSac> GetAllMauSac()
        {
            return context.MauSacs.ToList();
        }

        public MauSac GetMauSacById(Guid id)
        {
            return context.MauSacs.FirstOrDefault(x => x.Id == id);
        }

        public List<MauSac> GetMauSacByName(string name)
        {
            return context.MauSacs.Where(x => x.TenMau == name).ToList();
        }

        public bool UpdateMauSac(MauSac ms)
        {
            try
            {
                var mauSac = context.MauSacs.Find(ms.Id);
                mauSac.TenMau = ms.TenMau;
                mauSac.TrangThai = ms.TrangThai;
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
