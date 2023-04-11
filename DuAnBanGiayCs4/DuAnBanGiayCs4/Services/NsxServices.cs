using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using System.Diagnostics.Metrics;

namespace DuAnBanGiayCs4.Services
{
    public class NsxServices : INsxServices
    {
        ShopDbContext context;
        public NsxServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateNsx(Nsx nsx)
        {
            try
            {
                context.Nsxes.Add(nsx);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteNsx(Guid id)
        {
            try
            {
                var nsx = context.Nsxes.Find(id);
                context.Nsxes.Remove(nsx);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Nsx> GetAllNsx()
        {
            return context.Nsxes.ToList();
        }

        public Nsx GetNsxById(Guid id)
        {
            return context.Nsxes.FirstOrDefault(x => x.Id == id);
        }

        public List<Nsx> GetNsxByName(string name)
        {
            return context.Nsxes.Where(x => x.TenNsx == name).ToList();
        }

        public bool UpdateNsx(Nsx nsx)
        {
            try
            {
                var nsx1 = context.Nsxes.Find(nsx.Id);
                nsx1.TenNsx = nsx.TenNsx;
                nsx1.TrangThai = nsx.TrangThai;
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
