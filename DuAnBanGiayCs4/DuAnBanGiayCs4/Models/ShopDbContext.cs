using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DuAnBanGiayCs4.Models
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext()
        {
            
        }
        public ShopDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Anh> Anhs { get; set; }
        public DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<GioHangChiTiet> GioHangChiTiets { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public DbSet<MauSac> MauSacs { get; set; }
        public DbSet<Nsx> Nsxes { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ThanhToan> ThanhToans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loai> Loais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-OF-KHAI\SQLEXPRESS;Initial Catalog=DuAnBanGiayCs4;Persist Security Info=True;User ID=khainq03;Password=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
