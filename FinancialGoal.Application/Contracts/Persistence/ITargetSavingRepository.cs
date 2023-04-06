using FinancialGoal.Domain.Entitie;

namespace FinancialGoal.Application.Contracts.Persistence
{
	public interface ITargetSavingRepository : IAsyncRepository<TargetSaving>
	{
		Task<IEnumerable<TargetSaving>> GetTargetSavingByState(string state);
	}
}
