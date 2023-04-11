namespace DuAnBanGiayCs4.Models
{
    public class Anh
    {
        public Guid Id { get; set; }
        public string TenAnh { get; set; }
        public string Url { get; set; }
        public string Url1 { get; set; }
        public string Url2 { get; set; }
        public string Url3 { get; set; }
        public int TrangThai { get; set; }
        public virtual List<ChiTietSanPham> ChiTietSanPhams { get; set; }

    }
}
