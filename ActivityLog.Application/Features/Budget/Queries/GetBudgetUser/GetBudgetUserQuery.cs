using ActivityLog.Application.Features.Budget.Queries.Common;
using MediatR;

namespace ActivityLog.Application.Features.Budget.Queries.GetBudgetUser
{
	public class GetBudgetUserQuery : IRequest<List<BudgetVm>>
	{
		public string _UserId { get; set; } = string.Empty;

		public GetBudgetUserQuery(string userId)
		{
			_UserId = userId ?? throw new ArgumentNullException(nameof(userId));
		}
	}
}
