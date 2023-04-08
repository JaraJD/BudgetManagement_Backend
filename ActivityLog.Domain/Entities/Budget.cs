using ActivityLog.Domain.Entities.Common;

namespace ActivityLog.Domain.Entities
{
	public class Budget : BaseDomainModel
	{
		public string? IdUser { get; set; }

		public string? Name { get; set; }

		public DateTime TargetMonth { get; set; }

		public decimal Balance { get; set; }

		public decimal MonthlyTotal { get; set; }

		public string? State { get; set; }

		public virtual List<BudgetExpense>? BudgetExpense { get; set; }
	}
}
