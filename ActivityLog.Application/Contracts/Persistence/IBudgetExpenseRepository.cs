using ActivityLog.Domain.Entities;

namespace ActivityLog.Application.Contracts.Persistence
{
	public interface IBudgetExpenseRepository : IAsyncRepository<BudgetExpense>
	{
		Task<IEnumerable<BudgetExpense>> GetBudgetExpenseByBudget(int budgetId);
	}
}
