using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.IServices
{
    public interface IGioHangChiTietServices
    {
        public bool CreateGioHangChiTiet(GioHangChiTiet ghct);
        public bool UpdateGioHangChiTiet(GioHangChiTiet ghct);
        public bool DeleteGioHangChiTiet(Guid id);
        public List<GioHangChiTiet> GetAllGioHangChiTiet();
        public List<GioHangChiTiet> GetGioHangByUserLogin();
        public GioHangChiTiet GetGioHangChiTietById(Guid id); 
        public List<GioHangChiTiet> GetGioHangChiTietByName(Guid id);
    }
}
