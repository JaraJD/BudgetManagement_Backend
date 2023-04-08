using ActivityLog.Application.Features.BudgetExpense.Queries.Common;
using MediatR;

namespace ActivityLog.Application.Features.BudgetExpense.Queries.GetBudgetExpenseBudget
{
	public class GetBudgetExpenseBudgetQuery : IRequest<List<BudgetExpenseVm>>
	{
		public int _BudgetId { get; set; }

		public GetBudgetExpenseBudgetQuery(int budgetId)
		{
			_BudgetId = budgetId;
		}
	}
}
