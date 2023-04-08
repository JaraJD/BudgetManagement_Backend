using ActivityLog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLog.Application.Features.Budget.Queries.Common
{
	public class BudgetVm
	{
		public string? Name { get; set; }

		public DateTime TargetMonth { get; set; }

		public decimal Balance { get; set; }

		public decimal MonthlyTotal { get; set; }

		public virtual List<BudgetExpense>? BudgetExpense { get; set; }
	}
}
