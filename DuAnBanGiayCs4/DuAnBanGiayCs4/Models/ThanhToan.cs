namespace DuAnBanGiayCs4.Models
{
    public class ThanhToan
    {
        public Guid Id { get; set; }
        public Guid IdHD { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public int SoTienDaThanhToan { get; set; }
        public int PhuongThucThanhToan { get; set; }
        public virtual HoaDon HoaDon { get; set; }
    }
}
