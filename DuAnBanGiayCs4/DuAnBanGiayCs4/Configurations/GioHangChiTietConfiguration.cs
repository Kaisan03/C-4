using DuAnBanGiayCs4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuAnBanGiayCs4.Configurations
{
    public class GioHangChiTietConfiguration : IEntityTypeConfiguration<GioHangChiTiet>
    {
        public void Configure(EntityTypeBuilder<GioHangChiTiet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ChiTietSanPham).WithMany(x => x.GioHangChiTiets).HasForeignKey(x => x.IdCtsp);
            builder.HasOne(x => x.GioHang).WithMany(x => x.GioHangChiTiets).HasForeignKey(x => x.IdGioHang);
        }
    }
}
