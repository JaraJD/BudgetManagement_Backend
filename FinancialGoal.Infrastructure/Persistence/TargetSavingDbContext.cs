using FinancialGoal.Domain.Entitie;
using FinancialGoal.Domain.Entitie.Common;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoal.Infrastructure.Persistence
{
    public class TargetSavingDbContext : DbContext
    {
        public TargetSavingDbContext(DbContextOptions<TargetSavingDbContext> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted &&
                e.Metadata.GetProperties().Any(x => x.Name == "IsDeleted")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["IsDeleted"] = true;
            }

            return base.SaveChanges();
        }
        public DbSet<TargetSaving>? Target_Saving { get; set; }

    }
}
