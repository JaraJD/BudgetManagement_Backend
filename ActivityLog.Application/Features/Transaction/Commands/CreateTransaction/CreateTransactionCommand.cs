using ActivityLog.Domain.Entities;
using MediatR;

namespace ActivityLog.Application.Features.Transaction.Commands.CreateTransaction
{
	public class CreateTransactionCommand : IRequest<string>
	{
		public DateTime Date { get; set; }

		public string? Type { get; set; }

		public decimal Amount { get; set; }

		public string? Description { get; set; }

		public string? UserId { get; set; }

		public int? CategoryId { get; set; }

		public int? BugetId { get; set; }
	}
}
