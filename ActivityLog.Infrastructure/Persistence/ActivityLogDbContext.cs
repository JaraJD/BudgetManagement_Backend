using ActivityLog.Domain.Entities;
using ActivityLog.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ActivityLog.Infrastructure.Persistence
{
	public class ActivityLogDbContext : DbContext
	{
		public ActivityLogDbContext(DbContextOptions<ActivityLogDbContext> options) : base(options)
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

		public DbSet<Budget>? Budget { get; set; }
		public DbSet<BudgetExpense>? Budget_Expense { get; set; }
		public DbSet<Category>? Category { get; set; }
		public DbSet<Transaction>? Transaction { get; set; }
	}
}
