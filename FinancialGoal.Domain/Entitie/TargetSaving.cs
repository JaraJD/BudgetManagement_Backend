using FinancialGoal.Domain.Entitie.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Domain.Entitie
{
	public class TargetSaving : BaseDomainModel
	{
		public string? IdUser { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public decimal TargetAmount { get; set; }

		public string? StateSaving { get; set; }

		public void SetState()
		{
			if(StartDate < DateTime.Now && StartDate < EndDate)
			{
				StateSaving = "in progress";
			}
			if (StartDate > DateTime.Now && StartDate< EndDate)
			{
				StateSaving = "not started";
			}
			if (StartDate < DateTime.Now && EndDate < DateTime.Now && StartDate < EndDate)
			{
				StateSaving = "completed";
			}
		} 
	}
}
