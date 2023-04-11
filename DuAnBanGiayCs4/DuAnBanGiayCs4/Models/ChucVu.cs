namespace DuAnBanGiayCs4.Models
{
    public class ChucVu
    {
        public Guid Id { get; set; }
        public string TenCv { get; set; }
        public int TrangThai { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
