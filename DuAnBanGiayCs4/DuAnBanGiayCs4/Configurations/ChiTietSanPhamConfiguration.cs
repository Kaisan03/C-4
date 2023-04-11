using DuAnBanGiayCs4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuAnBanGiayCs4.Configurations
{
    public class ChiTietSanPhamConfiguration : IEntityTypeConfiguration<ChiTietSanPham>
    {
        public void Configure(EntityTypeBuilder<ChiTietSanPham> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.MoTa).HasColumnType("nvarchar(1000)");
            builder.HasOne(x => x.MauSac).WithMany(x => x.ChiTietSanPhams).HasForeignKey(x => x.IdColor);
            builder.HasOne(x => x.Size).WithMany(x => x.ChiTietSanPhams).HasForeignKey(x => x.IdSize);
            builder.HasOne(x => x.Anh).WithMany(x => x.ChiTietSanPhams).HasForeignKey(x => x.IdAnh);
            builder.HasOne(x => x.Nsx).WithMany(x => x.ChiTietSanPhams).HasForeignKey(x => x.IdNsx);
            builder.HasOne(x => x.SanPham).WithMany(x => x.ChiTietSanPhams).HasForeignKey(x => x.IdSp);
            builder.HasOne(x => x.Loai).WithMany(x => x.chiTietSanPhams).HasForeignKey(x => x.IdLoai);
        }
    }
}
