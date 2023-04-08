using ActivityLog.Domain.Entities;
using MediatR;

namespace ActivityLog.Application.Features.BudgetExpense.Commands.CreateBudgetExpense
{
	public class CreateBudgetExpenseCommand : IRequest<string>
	{
		public decimal Amount { get; set; }

		public string? Description { get; set; }

		public int BudgetId { get; set; }

		public int CategoryId { get; set; }

	}
}
