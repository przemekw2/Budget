using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class SpendConfiguration : IEntityTypeConfiguration<Spend>
    {
        public void Configure(EntityTypeBuilder<Spend> builder)
        {

            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.CreatedAt).IsRequired();
            builder.Property(s => s.Amount).HasColumnType("decimal(18,4)");
            builder.Property(s => s.Description).HasMaxLength(255);
            builder.HasOne(s => s.Category).WithMany()
                .HasForeignKey(s => s.CategoryId);
            
        }
    }
}