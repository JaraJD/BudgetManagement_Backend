using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Domain.Entities;
using ActivityLog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ActivityLog.Infrastructure.Repositories
{
	public class BudgetRepository : RepositoryBase<Budget>, IBudgetRepository
	{
		public BudgetRepository(ActivityLogDbContext context) : base(context)
		{

		}

		public async Task<IEnumerable<Budget>> GetBudgetByDate(string user, DateTime date)
		{
			return await _context.Budget!.Where(t => t.IdUser == user &&
												t.TargetMonth.Month == date.Month &&
												t.TargetMonth.Year == date.Year &&
												t.IsDeleted == false).ToListAsync();
		}

		public async Task<IEnumerable<Budget>> GetBudgetByName(string user, string name)
		{
			return await _context.Budget!.Where(t => t.IdUser == user && t.Name == name && t.IsDeleted == false).ToListAsync();
		}

		public async Task<IEnumerable<Budget>> GetBudgetByState(string user, string state)
		{
			return await _context.Budget!.Where(t => t.IdUser == user && t.State == state && t.IsDeleted == false).ToListAsync();
		}

		public async Task<IEnumerable<Budget>> GetBudgetByUser(string user)
		{
			return await _context.Budget!.Where(t => t.IdUser == user && t.IsDeleted == false).ToListAsync();
		}
	}
}
