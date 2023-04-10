
using UserAuthentication.Entities.Entities;
using UserAuthentication.Entities.Features.Balance.Commands;
using UserAuthentication.Entities.Features.Balance.Queries;

namespace UserAuthentication.UseCase.Gateway
{
	public interface IBalanceUseCase
	{
		Task<string> CreateBalance(CreateBalanceCommand balance);

		Task<string> UpdateBalance(UpdateBalanceCommand balance);

		Task<string> DeleteBalance(DeleteBalanceCommand balance);

		Task<string> ResetBalance(ResetBalanceCommand balance);

		Task<string> SetBalance(SetBalanceCommand balance);

		Task<string> DeductBalance(SetBalanceCommand balance);

		Task<List<BalanceEntity>> GetBalanceByUser(GetBalanceByUserId user);
	}
}
