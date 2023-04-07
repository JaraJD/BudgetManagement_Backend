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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
			foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
			{
				switch (entry.State)
				{
					case EntityState.Added:
						entry.Entity.IsDeleted = false;
						break;
				}
			}

			return base.SaveChangesAsync(cancellationToken);
		}

        public DbSet<TargetSaving>? Target_Saving { get; set; }

    }
}
