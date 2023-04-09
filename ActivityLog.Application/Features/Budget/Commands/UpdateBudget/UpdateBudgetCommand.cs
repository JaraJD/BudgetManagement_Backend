using ActivityLog.Domain.Entities;
using MediatR;

namespace ActivityLog.Application.Features.Budget.Commands.UpdateBudget
{
	public class UpdateBudgetCommand : IRequest<string>
	{
		public int Id { get; set; }

		public string? Name { get; set; }

		public DateTime TargetMonth { get; set; }

		public decimal Balance { get; set; }

		public string? State { get; set;}
	}
}
