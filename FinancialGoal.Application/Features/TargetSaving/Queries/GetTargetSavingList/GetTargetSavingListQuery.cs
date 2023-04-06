using MediatR;

namespace FinancialGoal.Application.Features.TargetSaving.Queries.GetTargetSavingList
{
	public class GetTargetSavingListQuery : IRequest<List<TargetSavingVm>>
	{
		public string _State { get; set; } = string.Empty;

		public GetTargetSavingListQuery(string state)
		{
			_State = state ?? throw new ArgumentNullException(nameof(state));
		}
	}
}
