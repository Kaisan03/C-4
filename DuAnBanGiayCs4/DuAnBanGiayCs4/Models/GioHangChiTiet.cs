namespace DuAnBanGiayCs4.Models
{
    public class GioHangChiTiet
    {
        public Guid Id { get; set; }
        public Guid IdGioHang { get; set; }
        public Guid IdCtsp { get; set; }
            
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public int TrangThai { get; set; }
        public virtual GioHang GioHang { get; set; }
        public virtual ChiTietSanPham ChiTietSanPham { get; set; }
    }
}
