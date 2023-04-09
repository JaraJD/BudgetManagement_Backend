using MediatR;

namespace ActivityLog.Application.Features.Budget.Commands.SetTotalBudget
{
	public class SetTotalBudgetCommand : IRequest<string>
	{
		public int Id { get; set; }
		public decimal Amount { get; set; }
	}
}
