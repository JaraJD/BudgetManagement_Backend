using ActivityLog.Domain.Entities;
using MediatR;

namespace ActivityLog.Application.Features.Budget.Commands.CreateBudget
{
	public class CreateBudgetCommand : IRequest<string>
	{
		public string IdUser { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;

		public DateTime TargetMonth { get; set; }

		public decimal? Balance { get; set; }

		public string State = string.Empty;
	}
}
