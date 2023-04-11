using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.IServices
{
    public interface IHoaDonServices
    {
        public bool CreateHoaDon(HoaDon hd);
        public bool UpdateHoaDon(HoaDon hd);
        public bool DeleteHoaDon(Guid id);
        public List<HoaDon> GetAllHoaDon();
        public HoaDon GetHoaDonById(Guid id);
        public List<HoaDon> GetHoaDonByName(string name);
    }
}

