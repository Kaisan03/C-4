namespace DuAnBanGiayCs4.Models
{
    public class HoaDonChiTiet
    {
        public Guid Id { get; set; }
        public Guid IdHD { get; set; }
        public Guid IdCtsp { get; set; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public virtual HoaDon HoaDon { get; set; }
        public virtual ChiTietSanPham ChiTietSanPham { get; set; }
    }
}
