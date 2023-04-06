using MediatR;

namespace FinancialGoal.Application.Features.TargetSaving.Commands.UpdateTargetSaving
{
	public class UpdateTargetSavingCommand : IRequest<int>
	{
		public int Id { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public decimal TargetAmount { get; set; }
	}
}
