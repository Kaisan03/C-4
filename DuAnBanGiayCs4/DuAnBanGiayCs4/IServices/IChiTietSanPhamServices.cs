using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.IServices
{
    public interface IChiTietSanPhamServices
    {
        public bool CreateChiTietSanPham(ChiTietSanPham ctsp);
        public bool UpdateChiTietSanPham(ChiTietSanPham ctsp);
        public bool DeleteChiTietSanPham(Guid id);
        public List<ChiTietSanPham> GetAllChiTietSanPham();
        public ChiTietSanPham GetChiTietSanPhamById(Guid id);
        public List<ChiTietSanPham> GetChiTietSanPhamByName(string name);
    }
}
