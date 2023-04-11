using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.IServices
{
    public interface IChucVuServices
    {
        public bool CreateChucVu(ChucVu cv);
        public bool UpdateChucVu(ChucVu cv);
        public bool DeleteChucVu(Guid id);
        public List<ChucVu> GetAllChucVu();
        public ChucVu GetChucVuById(Guid id);
        public List<ChucVu> GetChucVuByName(string name);
    }
}

