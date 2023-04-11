using DuAnBanGiayCs4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuAnBanGiayCs4.Configurations
{
    public class ThanhToanConfiguration : IEntityTypeConfiguration<ThanhToan>
    {
        public void Configure(EntityTypeBuilder<ThanhToan> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.HoaDon).WithMany(x => x.ThanhToans).HasForeignKey(x => x.IdHD);
        }
    }
}
