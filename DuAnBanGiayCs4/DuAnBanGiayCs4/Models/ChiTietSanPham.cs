namespace DuAnBanGiayCs4.Models
{
    public class ChiTietSanPham
    {
        public Guid Id { get; set; }
        public Guid IdSp { get; set; }
        public Guid IdAnh { get; set; }
        public Guid IdSize { get; set; }
        public Guid IdColor { get; set; }
        public Guid IdNsx { get; set; }
        public Guid IdLoai { get; set; }
        public int SoLuongTon { get; set; }
        public int GiaNhap { get; set; }
        public int GiaBan { get; set; }
        public int TrangThai { get; set; }
        public string MoTa { get; set; }
        public virtual MauSac MauSac { get; set; }
        public virtual Anh Anh { get; set; }
        public virtual Size Size { get; set; }
        public virtual SanPham SanPham { get; set; }
        public virtual Nsx Nsx { get; set; }
        public virtual Loai Loai { get; set; }
        public virtual List<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual List<GioHangChiTiet> GioHangChiTiets { get; set; }

    }
}
