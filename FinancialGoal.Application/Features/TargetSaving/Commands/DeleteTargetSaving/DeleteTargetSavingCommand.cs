
using MediatR;

namespace FinancialGoal.Application.Features.TargetSaving.Commands.DeleteTargetSaving
{
	public class DeleteTargetSavingCommand : IRequest<int>
	{
		public int Id { get; set; }
	}
}
