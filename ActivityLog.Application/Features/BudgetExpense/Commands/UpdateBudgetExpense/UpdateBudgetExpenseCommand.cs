using ActivityLog.Domain.Entities;
using MediatR;

namespace ActivityLog.Application.Features.BudgetExpense.Commands.UpdateBudgetExpense
{
	public class UpdateBudgetExpenseCommand : IRequest<string>
	{
		public int Id { get; set; }

		public decimal Amount { get; set; }

		public string? Description { get; set; }

		public int CategoryId { get; set; }

	}
}
