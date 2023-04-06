using FinancialGoal.Application.Contracts.Persistence;
using FinancialGoal.Domain.Entitie;
using FinancialGoal.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoal.Infrastructure.Repositories
{
    public class TargetSavingRepository : RepositoryBase<TargetSaving>, ITargetSavingRepository
	{
		public TargetSavingRepository(TargetSavingDbContext context) : base(context)
		{

		}
		public async Task<IEnumerable<TargetSaving>> GetTargetSavingByState(string state)
		{
			return await _context.Target_Saving!.Where(t => t.StateSaving == state).ToListAsync();
		}
	}
}
