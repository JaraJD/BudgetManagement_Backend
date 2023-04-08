using ActivityLog.Domain.Entities;

namespace ActivityLog.Application.Features.Transaction.Queries.Common
{
	public class TransactionVm
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }

		public string? Type { get; set; }

		public decimal Amount { get; set; }

		public string? Description { get; set; }

		public int CategoryId { get; set; }

		public int? BugetId { get; set; }

		public virtual Category? Category { get; set; }

		public virtual Domain.Entities.Budget? Budget { get; set; }
	}
}
