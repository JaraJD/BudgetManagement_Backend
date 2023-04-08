using ActivityLog.Application.Features.Budget.Queries.Common;
using MediatR;

namespace ActivityLog.Application.Features.Budget.Queries.GetBudgetDate
{
	public class GetBudgetDateQuery : IRequest<List<BudgetVm>>
	{
		public string _UserId { get; set; } = string.Empty;

		public DateTime _TargetMonth { get; set; }

		public GetBudgetDateQuery(string userId, DateTime targetMonth)
		{
			_UserId = userId ?? throw new ArgumentNullException(nameof(userId));
			_TargetMonth = targetMonth;
		}
	}
}
