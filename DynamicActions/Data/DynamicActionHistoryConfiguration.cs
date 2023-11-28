using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DynamicActions.Models;

namespace DynamicActions.Data
{
    public class DynamicActionHistoryConfiguration : IEntityTypeConfiguration<DynamicActionHistory>
    {
        public void Configure(EntityTypeBuilder<DynamicActionHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder
                .Property(b => b.Result)
                .HasMaxLength(1000)
                .IsRequired();

            builder
              .Property(b => b.X)
              .HasMaxLength(250)
              .IsRequired();

            builder
              .Property(b => b.Y)
              .HasMaxLength(250)
              .IsRequired();

            builder.HasOne(b => b.DynamicAction)
                .WithMany()
                .HasForeignKey(x=> x.DynamicActionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
