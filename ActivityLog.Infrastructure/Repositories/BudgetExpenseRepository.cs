using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Domain.Entities;
using ActivityLog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ActivityLog.Infrastructure.Repositories
{
	public class BudgetExpenseRepository : RepositoryBase<BudgetExpense>, IBudgetExpenseRepository
	{
		public BudgetExpenseRepository(ActivityLogDbContext context) : base(context)
		{

		}

		public async Task<IEnumerable<BudgetExpense>> GetBudgetExpenseByBudget(int budgetId)
		{
			return await _context.Budget_Expense!.Where(t => t.BudgetId == budgetId && t.IsDeleted == false).ToListAsync();
		}
	}
}
