using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Domain.Entities;
using ActivityLog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ActivityLog.Infrastructure.Repositories
{
	public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
	{
		public TransactionRepository(ActivityLogDbContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Transaction>> GetTransactionByCategory(string user, int categoryId)
		{
			return await _context.Transaction!.Where(t => t.UserId == user && t.CategoryId == categoryId && t.IsDeleted == false).ToListAsync();
		}

		public async Task<IEnumerable<Transaction>> GetTransactionByDate(string user, DateTime date)
		{
			return await _context.Transaction!.Where(t => t.UserId == user &&
												t.Date.Month == date.Month &&
												t.Date.Year == date.Year &&
												t.IsDeleted == false).ToListAsync();
		}

		public async Task<IEnumerable<Transaction>> GetTransactionByType(string user, string type)
		{
			return await _context.Transaction!.Where(t => t.UserId == user && t.Type == type && t.IsDeleted == false).ToListAsync();
		}

		public async Task<IEnumerable<Transaction>> GetTransactionByUser(string user)
		{
			return await _context.Transaction!.Where(t => t.UserId == user && t.IsDeleted == false).ToListAsync();
		}
	}
}
