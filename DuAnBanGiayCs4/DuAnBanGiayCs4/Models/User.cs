namespace DuAnBanGiayCs4.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid IdCv { get; set; }
        public string HoTenDem { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public int Sdt { get; set; }
        public string DiaChi { get; set; }
        public int GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string MatKhau { get; set;}
        public DateTime NgayDangKy { get; set; }
        public DateTime NgayCapNhatThongTin { get; set; }
        public virtual List<HoaDon> HoaDons { get; set; }
        public virtual GioHang GioHang { get; set; }
        public virtual ChucVu ChucVu { get; set; }

    }
}
