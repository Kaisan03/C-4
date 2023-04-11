using System.Drawing;

namespace DuAnBanGiayCs4.Models
{
    public class MauSac
    {
        public Guid Id { get; set; }
        public string TenMau { get; set; }
        public int TrangThai { get; set; }
        public virtual List<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
