namespace DuAnBanGiayCs4.Models
{
    public class Loai
    {
        public Guid Id { get; set; }
        public string TenLoai { get; set; }
        public int TrangThai { get; set; }
        public List<ChiTietSanPham> chiTietSanPhams { get; set; }

    }
}
