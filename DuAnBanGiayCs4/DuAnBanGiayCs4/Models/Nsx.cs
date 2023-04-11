namespace DuAnBanGiayCs4.Models
{
    public class Nsx
    {
        public Guid Id { get; set; }
        public string TenNsx { get; set; }
        public int TrangThai { get; set; }
        public virtual List<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
