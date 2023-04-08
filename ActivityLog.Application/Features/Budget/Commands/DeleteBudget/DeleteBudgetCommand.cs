using MediatR;

namespace ActivityLog.Application.Features.Budget.Commands.DeleteBudget
{
	public class DeleteBudgetCommand : IRequest<string>
	{
		public int Id { get; set; }
	}
}
