using FinancialGoal.Domain.Entitie;

namespace FinancialGoal.Application.Contracts.Persistence
{
	public interface ITargetSavingRepository : IAsyncRepository<TargetSaving>
	{
		Task<IEnumerable<TargetSaving>> GetTargetSavingByUser(string user);
		Task<IEnumerable<TargetSaving>> GetTargetSavingByState(string user, string state);
	}
}
