using FinancialGoal.Domain.Entitie.Common;

namespace FinancialGoal.Application.Contracts.Persistence
{
	public interface IAsyncRepository<T> where T : BaseDomainModel 
	{
		Task<IReadOnlyList<T>> GetAllAsync();
		Task<T> CreateAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task DeleteAsync(T entity);

		Task<T> GetByIdAsync(int id);


	}
}
