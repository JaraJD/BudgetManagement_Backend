using ActivityLog.Domain.Entities.Common;

namespace ActivityLog.Application.Contracts.Persistence
{
	public interface IAsyncRepository<T> where T : BaseDomainModel
	{
		//Task<IReadOnlyList<T>> GetAllAsync();
		Task<T> CreateAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task DeleteAsync(T entity);
		Task<T> GetByIdAsync(int id);

	}
}
