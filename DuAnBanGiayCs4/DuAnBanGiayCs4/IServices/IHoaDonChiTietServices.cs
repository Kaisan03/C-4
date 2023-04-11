using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.IServices
{
    public interface IHoaDonChiTietServices
    {
        public bool CreateHoaDonChiTiet(HoaDonChiTiet hdct);
        public bool UpdateHoaDonChiTiet(HoaDonChiTiet hdct);
        public bool DeleteHoaDonChiTiet(Guid id);
        public List<HoaDonChiTiet> GetAllHoaDonChiTiet();
        public HoaDonChiTiet GetHoaDonChiTietById(Guid id);
        public List<HoaDonChiTiet> GetHoaDonChiTietByName(string name);
    }
}

