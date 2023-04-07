using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoal.Application.Features.TargetSaving.Queries.Common
{
    public class TargetSavingVm
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TargetAmount { get; set; }

        public string? StateSaving { get; set; }
    }
}
