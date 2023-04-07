using ActivityLog.Domain.Entities;

namespace ActivityLog.Application.Contracts.Persistence
{
	public interface ITransactionRepository : IAsyncRepository<Transaction>
	{
		Task<IEnumerable<Transaction>> GetTransactionByUser(string user);
		Task<IEnumerable<Transaction>> GetTransactionByDate(string user, DateTime date);
		Task<IEnumerable<Transaction>> GetTransactionByType(string user, string name);
		Task<IEnumerable<Transaction>> GetTransactionByCategory(string user, int categoryId);
	}
}
