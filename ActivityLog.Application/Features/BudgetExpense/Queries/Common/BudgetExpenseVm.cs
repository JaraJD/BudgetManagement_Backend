using ActivityLog.Domain.Entities;

namespace ActivityLog.Application.Features.BudgetExpense.Queries.Common
{
	public class BudgetExpenseVm
	{
		public int Id { get; set; }
		public decimal Amount { get; set; }

		public string? Description { get; set; }

		public virtual Category? Category { get; set; }
	}
}
