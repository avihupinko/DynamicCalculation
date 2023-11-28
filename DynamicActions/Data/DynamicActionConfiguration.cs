using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DynamicActions.Models;

namespace DynamicActions.Data
{
    public class DynamicActionConfiguration : IEntityTypeConfiguration<DynamicAction>
    {
        public void Configure(EntityTypeBuilder<DynamicAction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasIndex(x => x.Name).IsUnique();
            builder
                .Property(b => b.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder
                .Property(b => b.Expression)
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}
