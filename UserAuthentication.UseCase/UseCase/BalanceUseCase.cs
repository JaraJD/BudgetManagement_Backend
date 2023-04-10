
using UserAuthentication.Entities.Entities;
using UserAuthentication.Entities.Features.Balance.Commands;
using UserAuthentication.Entities.Features.Balance.Queries;
using UserAuthentication.UseCase.Gateway;
using UserAuthentication.UseCase.Gateway.Repository;

namespace UserAuthentication.UseCase.UseCase
{
	public class BalanceUseCase : IBalanceUseCase
	{
		private readonly IBalanceRepository _repository;

		public BalanceUseCase(IBalanceRepository repository)
		{
			_repository = repository;
		}

		public async Task<string> CreateBalance(CreateBalanceCommand balance)
		{
			return await _repository.CreateBalanceAsync(balance);
		}

		public async Task<string> DeleteBalance(DeleteBalanceCommand balance)
		{
			return await _repository.DeleteBalanceAsync(balance);
		}

		public async Task<List<BalanceEntity>> GetBalanceByUser(string user)
		{
			return await _repository.GetBalanceByUserAsync(user);
		}

		public async Task<string> ResetBalance(ResetBalanceCommand balance)
		{
			return await _repository.ResetBalanceAsync(balance); 
		}

		public async Task<string> SetBalance(SetBalanceCommand balance)
		{
			return await _repository.SetBalanceAsync(balance);
		}

		public Task<string> UpdateBalance(UpdateBalanceCommand balance)
		{
			return _repository.UpdateBalanceAsync(balance);
		}

		public Task<string> DeductBalance(SetBalanceCommand balance)
		{
			return _repository.DeductBalanceAsync(balance);
		}
	}
}
