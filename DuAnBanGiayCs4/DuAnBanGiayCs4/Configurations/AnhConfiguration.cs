using DuAnBanGiayCs4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuAnBanGiayCs4.Configurations
{
    public class AnhConfiguration : IEntityTypeConfiguration<Anh>
    {
        public void Configure(EntityTypeBuilder<Anh> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TenAnh).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Url).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Url1).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Url2).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Url3).HasColumnType("nvarchar(1000)");
        }
    }
}
