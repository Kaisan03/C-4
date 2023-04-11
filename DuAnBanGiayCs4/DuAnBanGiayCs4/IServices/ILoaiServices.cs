using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.IServices
{
    public interface ILoaiServices
    {
        public bool CreateLoai(Loai loai);
        public bool UpdateLoai(Loai loai);
        public bool DeleteLoai(Guid id);
        public List<Loai> GetAllLoai();
        public Loai GetLoaiById(Guid id);
        public List<Loai> GetLoaiByName(string name);
    }
}
