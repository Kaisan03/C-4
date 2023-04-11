namespace DuAnBanGiayCs4.Models
{
    public class SanPham
    {
        public Guid Id { get; set; }
        public string TenSp { get; set; }
        public int TrangThai { get; set; }
        public virtual List<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
