using Ardalis.GuardClauses;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using UserAuthentication.DrivenAdapter.EntitiesMongo;
using UserAuthentication.DrivenAdapter.Interfaces;
using UserAuthentication.Entities.Entities;
using UserAuthentication.Entities.Features.Balance.Commands;
using UserAuthentication.Entities.Features.Balance.Queries;
using UserAuthentication.UseCase.Gateway.Repository;

namespace UserAuthentication.DrivenAdapter.Repositories
{
	public class BalanceRepository : IBalanceRepository
	{
		private readonly IMongoCollection<BalanceMongo> coleccionBalance;
		private readonly IMapper _mapper;

		public BalanceRepository(IContext context, IMapper mapper)
		{
			coleccionBalance = context.Balance;
			_mapper = mapper;
		}

		public async Task<string> CreateBalanceAsync(CreateBalanceCommand balance)
		{
			Guard.Against.Null(balance, nameof(balance));
			Guard.Against.NullOrEmpty(balance.UserId, nameof(balance.UserId), "UserId Required. ");
			Guard.Against.NullOrEmpty(balance.Name, nameof(balance.Name));
			Guard.Against.NullOrEmpty(balance.Amount.ToString(), nameof(balance.Amount));

			var balanceToCreate = _mapper.Map<BalanceMongo>(balance);
			balanceToCreate.IsDeleted = false;
			await coleccionBalance.InsertOneAsync(balanceToCreate);
			return "Balance Created";
		}

		public async Task<string> UpdateBalanceAsync(UpdateBalanceCommand balance)
		{
			Guard.Against.NullOrEmpty(balance.Name, nameof(balance.Name));

			var filter = Builders<BalanceMongo>.Filter.Eq(b => b.BalanceId, balance.BalanceId);
			var update = Builders<BalanceMongo>.Update.Set(b => b.Name, balance.Name);
			var result = await coleccionBalance.UpdateOneAsync(filter, update);

			return "Balance Updated";
		}

		public async Task<string> DeleteBalanceAsync(DeleteBalanceCommand balance)
		{
			var filter = Builders<BalanceMongo>.Filter.Eq(b => b.BalanceId, balance.BalanceId);
			var balanceToDelete = await coleccionBalance.Find(filter).FirstOrDefaultAsync();

			Guard.Against.Null(balanceToDelete, nameof(balanceToDelete));

			balanceToDelete.IsDeleted = true;
			var updateResult = await coleccionBalance.ReplaceOneAsync(filter, balanceToDelete);

			return "Balance Eliminated";
		}

		public async Task<string> ResetBalanceAsync(ResetBalanceCommand balance)
		{
			var filter = Builders<BalanceMongo>.Filter.Eq(b => b.BalanceId, balance.BalanceId);
			var balanceToReset = await coleccionBalance.Find(filter).FirstOrDefaultAsync();

			Guard.Against.Null(balanceToReset, nameof(balanceToReset));

			balanceToReset.Amount = 0;
			var updateResult = await coleccionBalance.ReplaceOneAsync(filter, balanceToReset);

			return "Balance Reset";
		}

		public async Task<string> SetBalanceAsync(SetBalanceCommand balance)
		{
			var filter = Builders<BalanceMongo>.Filter.And(
								Builders<BalanceMongo>.Filter.Eq(b => b.BalanceId, balance.BalanceId),
								Builders<BalanceMongo>.Filter.Eq(b => b.IsDeleted, false));

			var balanceToSet = await coleccionBalance.Find(filter).FirstOrDefaultAsync();

			Guard.Against.Null(balanceToSet, nameof(balanceToSet));

			balanceToSet.Amount += balance.Value;
			var updateResult = await coleccionBalance.ReplaceOneAsync(filter, balanceToSet);

			return "Balance Set";
		}

		public async Task<List<BalanceEntity>> GetBalanceByUserAsync(string balance)
		{
			var filter = Builders<BalanceMongo>.Filter.And(
								Builders<BalanceMongo>.Filter.Eq(b => b.UserId, balance),
								Builders<BalanceMongo>.Filter.Eq(b => b.IsDeleted, false));

			var balances = await coleccionBalance.FindAsync(filter);
			var balanceList = balances.ToEnumerable().Select(b => _mapper.Map<BalanceEntity>(b)).ToList();

			return balanceList;
		}

		public async Task<string> DeductBalanceAsync(SetBalanceCommand balance)
		{
			var filter = Builders<BalanceMongo>.Filter.And(
								Builders<BalanceMongo>.Filter.Eq(b => b.BalanceId, balance.BalanceId),
								Builders<BalanceMongo>.Filter.Eq(b => b.IsDeleted, false));

			var balanceToDeduct = await coleccionBalance.Find(filter).FirstOrDefaultAsync();

			Guard.Against.Null(balanceToDeduct, nameof(balanceToDeduct));

			if(balanceToDeduct.Amount <= 0 || balanceToDeduct.Amount < balance.Value)
			{
				balanceToDeduct.Amount = 0;
				return "Amount greater than the balance";
			}

			balanceToDeduct.Amount -= balance.Value;

			var updateResult = await coleccionBalance.ReplaceOneAsync(filter, balanceToDeduct);

			return "Balance Set";
		}
	}
}
