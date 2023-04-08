using ActivityLog.Application.Features.Budget.Queries.Common;
using MediatR;

namespace ActivityLog.Application.Features.Budget.Queries.GetBudgetState
{
	public class GetBudgetStateQuery : IRequest<List<BudgetVm>>
	{
		public string _UserId { get; set; } = string.Empty;

		public string _State { get; set; } = string.Empty;

		public GetBudgetStateQuery(string userId, string state)
		{
			_UserId = userId ?? throw new ArgumentNullException(nameof(userId));
			_State = state ?? throw new ArgumentNullException(nameof(state));
		}
	}
}
