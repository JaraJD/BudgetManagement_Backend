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
			return await _context.Transaction!.Where(t => t.UserId == user && t.CategoryId == categoryId && t.IsDeleted == false).Include(r => r.Category).Include(b => b.Budget).ToListAsync();
		}

		public async Task<IEnumerable<Transaction>> GetTransactionByDate(string user, DateTime date)
		{
			return await _context.Transaction!.Where(t => t.UserId == user &&
												t.Date.DayOfYear == date.DayOfYear &&
												t.IsDeleted == false).Include(r => r.Category).Include(b => b.Budget).ToListAsync();
		}

		public async Task<IEnumerable<Transaction>> GetTransactionByType(string user, string type)
		{
			return await _context.Transaction!.Where(t => t.UserId == user && t.Type == type && t.IsDeleted == false).Include(r => r.Category).Include(b => b.Budget).ToListAsync();
		}

		public async Task<IEnumerable<Transaction>> GetTransactionByUser(string user)
		{
			return await _context.Transaction!.Where(t => t.UserId == user && t.IsDeleted == false).Include(r => r.Category).Include(b => b.Budget).ToListAsync();
		}
	}
}
