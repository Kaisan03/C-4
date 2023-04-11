using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.IServices
{
    public interface ISanPhamServices
    {
        public bool CreateSanPham(SanPham sp);
        public bool UpdateSanPham(SanPham sp);
        public bool DeleteSanPham(Guid id);
        public List<SanPham> GetAllSanPham();
        public SanPham GetSanPhamById(Guid id);
        public List<SanPham> GetSanPhamByName(string name);
    }
}
