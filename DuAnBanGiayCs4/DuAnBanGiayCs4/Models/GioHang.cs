namespace DuAnBanGiayCs4.Models
{
    public class GioHang
    {
        public Guid Id { get; set; }
        public Guid IdNguoiDung { get; set; }
        public int TrangThai { get; set; }
        public virtual User User { get; set; }
        public virtual List<GioHangChiTiet> GioHangChiTiets { get; set; }
    }
}
