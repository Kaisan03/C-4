using DuAnBanGiayCs4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuAnBanGiayCs4.Configurations
{
    public class NsxConfiguration : IEntityTypeConfiguration<Nsx>
    {
        public void Configure(EntityTypeBuilder<Nsx> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.TenNsx).HasColumnType("nvarchar(1000)");
        }
    }
}
