using FinancialGoal.Application.Features.TargetSaving.Queries.Common;
using MediatR;

namespace FinancialGoal.Application.Features.TargetSaving.Queries.GetTargetSavingList
{
    public class GetTargetSavingListQuery : IRequest<List<TargetSavingVm>>
	{
		public string _State { get; set; } = string.Empty;

		public string _IdUser { get; set; } = string.Empty;
		public GetTargetSavingListQuery(string IdUser, string state)
		{
			_State = state ?? throw new ArgumentNullException(nameof(state));
			_IdUser = IdUser ?? throw new ArgumentNullException(nameof(IdUser));
		}
	}
}
