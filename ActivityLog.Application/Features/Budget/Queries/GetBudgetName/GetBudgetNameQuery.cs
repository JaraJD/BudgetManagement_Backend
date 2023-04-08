using ActivityLog.Application.Features.Budget.Queries.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLog.Application.Features.Budget.Queries.GetBudgetName
{
	public class GetBudgetNameQuery : IRequest<List<BudgetVm>>
	{
		public string _UserId { get; set; } = string.Empty;

		public string _Name { get; set; } = string.Empty;

		public GetBudgetNameQuery(string userId, string name)
		{
			_UserId = userId ?? throw new ArgumentNullException(nameof(userId));
			_Name = name ?? throw new ArgumentNullException(nameof(name));
		}
	}
}
