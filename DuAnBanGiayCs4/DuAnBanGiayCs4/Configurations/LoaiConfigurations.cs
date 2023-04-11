using DuAnBanGiayCs4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuAnBanGiayCs4.Configurations
{
    public class LoaiConfigurations : IEntityTypeConfiguration<Loai>
    {
        public void Configure(EntityTypeBuilder<Loai> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.TenLoai).HasColumnType("nvarchar(1000)");

        }
    }
}
