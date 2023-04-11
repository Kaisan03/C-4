namespace DuAnBanGiayCs4.Models
{
    public class HoaDon
    {
        public Guid Id { get; set; }
        public Guid IdNguoiDung { get; set; }
        public DateTime NgayTao { get; set; }
        public int TongTien { get; set; }
        public virtual List<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual User User { get; set; }
        public virtual List<ThanhToan> ThanhToans { get; set; }
    }
}
