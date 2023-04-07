using ActivityLog.Domain.Entities;

namespace ActivityLog.Application.Contracts.Persistence
{
	public interface IBudgetExpenseRepository : IAsyncRepository<BudgetExpense>
	{
	}
}
