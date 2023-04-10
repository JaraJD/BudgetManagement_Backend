

using UserAuthentication.Entities.Entities;
using UserAuthentication.Entities.Features.Balance.Commands;
using UserAuthentication.Entities.Features.Balance.Queries;

namespace UserAuthentication.UseCase.Gateway.Repository
{
	public interface IBalanceRepository
	{
		Task<string> CreateBalanceAsync(CreateBalanceCommand balance);

		Task<string> UpdateBalanceAsync(UpdateBalanceCommand balance);

		Task<string> DeleteBalanceAsync(DeleteBalanceCommand balance);

		Task<string> ResetBalanceAsync(ResetBalanceCommand balance);

		Task<string> SetBalanceAsync(SetBalanceCommand balance);

		Task<string> DeductBalanceAsync(SetBalanceCommand balance);

		Task<List<BalanceEntity>> GetBalanceByUserAsync(string balance);
	}
}
