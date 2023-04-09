using ActivityLog.Domain.Entities.Common;

namespace ActivityLog.Domain.Entities
{
	public class Transaction : BaseDomainModel
	{
		public DateTime Date { get; set; }

		public string? Type { get; set; }

		public decimal Amount { get; set; }

		public string? Description { get; set; }

		public string? UserId { get; set; }

		public int CategoryId { get; set; }

		public int? BudgetId { get; set; }

		public virtual Category? Category { get; set; }

		public virtual Budget? Budget { get; set; }
	}
}
