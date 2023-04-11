using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.IServices
{
    public interface IMauSacServices
    {
        public bool CreateMauSac(MauSac ms);
        public bool UpdateMauSac(MauSac ms);
        public bool DeleteMauSac(Guid id);
        public List<MauSac> GetAllMauSac();
        public MauSac GetMauSacById(Guid id);
        public List<MauSac> GetMauSacByName(string name);
    }
}
