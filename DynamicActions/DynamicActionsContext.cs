using DynamicActions.Data;
using DynamicActions.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicActions
{
    public class DynamicActionsContext : DbContext
    {
        public DbSet<DynamicAction> DynamicActions { get; set; }
        public DbSet<DynamicActionHistory> DynamicActionHistorys { get; set; }

        public DynamicActionsContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Define DB assemblys
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DynamicActionConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DynamicActionHistoryConfiguration).Assembly);
            modelBuilder.Entity<DynamicAction>().HasData(new[]
            {
                new DynamicAction
                {
                    Id = 1,
                    Name = "SUM",
                    DynamicActionType = DynamicActionType.Numeric,
                    Expression = "X + Y",
                    Created = new DateTime(2023, 11, 28)
                },
                new DynamicAction
                {
                    Id = 2,
                    Name = "SUB",
                    DynamicActionType = DynamicActionType.Numeric,
                    Expression = "X - Y",
                    Created = new DateTime(2023, 11, 28)
                },
                new DynamicAction
                {
                    Id = 3,
                    Name = "Concat",
                    DynamicActionType = DynamicActionType.Text,
                    Expression = "String.Concat(X, Y)",
                    Created = new DateTime(2023, 11, 28)
                },
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
