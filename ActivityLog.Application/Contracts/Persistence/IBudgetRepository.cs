using ActivityLog.Domain.Entities;

namespace ActivityLog.Application.Contracts.Persistence
{
	public interface IBudgetRepository : IAsyncRepository<Budget>
	{
		Task<IEnumerable<Budget>> GetBudgetByUser(string user);
		Task<IEnumerable<Budget>> GetBudgetByDate(string user, DateTime date);
		Task<IEnumerable<Budget>> GetBudgetByName(string user, string name);
		Task<IEnumerable<Budget>> GetBudgetByState(string user, string state);
	}
}
