namespace DuAnBanGiayCs4.Models
{
    public class Size
    {
        public Guid Id { get; set; }
        public int SoSize { get; set; }
        public int TrangThai { get; set; }
        public virtual List<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
