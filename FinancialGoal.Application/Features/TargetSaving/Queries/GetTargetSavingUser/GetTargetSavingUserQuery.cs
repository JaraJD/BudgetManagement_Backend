using FinancialGoal.Application.Features.TargetSaving.Queries.Common;
using MediatR;

namespace FinancialGoal.Application.Features.TargetSaving.Queries.GetTargetSavingUser
{
    public class GetTargetSavingUserQuery : IRequest<List<TargetSavingVm>>
	{
		public string _IdUser { get; set; } = string.Empty;
		public GetTargetSavingUserQuery(string IdUser)
		{
			_IdUser = IdUser ?? throw new ArgumentNullException(nameof(IdUser));
		}
	}
}
