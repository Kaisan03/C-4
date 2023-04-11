using DuAnBanGiayCs4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuAnBanGiayCs4.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.HoTenDem).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Ten).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Email).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.DiaChi).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.MatKhau).HasColumnType("nvarchar(1000)");
            builder.HasOne(x => x.ChucVu).WithMany(x => x.Users).HasForeignKey(x => x.IdCv);
            
        }
    }
}
