using DuAnBanGiayCs4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuAnBanGiayCs4.Configurations
{
    public class MauSacConfiguration : IEntityTypeConfiguration<MauSac>
    {
        public void Configure(EntityTypeBuilder<MauSac> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.TenMau).HasColumnType("nvarchar(1000)");
        }
    }
}
