using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.IServices
{
    public interface IGioHangServices
    {
        public bool CreateGioHang(GioHang gh);
        public bool UpdateGioHang(GioHang gh);
        public bool DeleteGioHang(Guid id);
        public List<GioHang> GetAllGioHang();
        public GioHang GetGioHangById(Guid id);
        public List<GioHang> GetGioHangByName(string name);
    }
}

