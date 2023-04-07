using ActivityLog.Domain.Entities.Common;

namespace ActivityLog.Domain.Entities
{
	public class BudgetExpense : BaseDomainModel
	{
		public decimal Amount { get; set; }

		public string? Description { get; set; }

		public int BudgetId { get; set; }

		public int CategoryId { get; set; }

		public virtual Budget? Budget { get; set; }

		public virtual Category? Category { get; set; }
	}
}
