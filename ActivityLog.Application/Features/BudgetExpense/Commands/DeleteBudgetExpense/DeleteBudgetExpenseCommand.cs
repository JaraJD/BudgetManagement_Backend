using MediatR;

namespace ActivityLog.Application.Features.BudgetExpense.Commands.DeleteBudgetExpense
{
	public class DeleteBudgetExpenseCommand : IRequest<string>
	{
		public int Id { get; set; }
	}
}
