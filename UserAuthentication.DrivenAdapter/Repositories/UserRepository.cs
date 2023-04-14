using Ardalis.GuardClauses;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using UserAuthentication.DrivenAdapter.EntitiesMongo;
using UserAuthentication.DrivenAdapter.Interfaces;
using UserAuthentication.Entities.Entities;
using UserAuthentication.Entities.Features.User.Commands;
using UserAuthentication.Entities.Features.User.Queries;
using UserAuthentication.UseCase.Gateway.Repository;

namespace UserAuthentication.DrivenAdapter.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IMongoCollection<UserMongo> coleccionUser;
		private readonly IMapper _mapper;

		public UserRepository(IContext context, IMapper mapper)
		{
			coleccionUser = context.User;
			_mapper = mapper;
		}

		public async Task<string> CreateUserAsync(CreateUserCommand user)
		{
			Guard.Against.Null(user, nameof(user));
			Guard.Against.NullOrEmpty(user.Name, nameof(user.Name), "Name Required. ");
			Guard.Against.NullOrEmpty(user.Email, nameof(user.Email));
			Guard.Against.NullOrEmpty(user.FireBaseId, nameof(user.FireBaseId));

			var userToCreate = _mapper.Map<UserMongo>(user);
			userToCreate.IsDeleted = false;
			await coleccionUser.InsertOneAsync(userToCreate);
			return "User Created".ToJson();
		}

		public async Task<string> DeleteUserAsync(DeleteUserCommand user)
		{
			var filter = Builders<UserMongo>.Filter.Eq(u => u.UserId, user.UserId);
			var userToDelete = await coleccionUser.Find(filter).FirstOrDefaultAsync();

			Guard.Against.Null(userToDelete, nameof(userToDelete));

			userToDelete.IsDeleted = true;
			var updateResult = await coleccionUser.ReplaceOneAsync(filter, userToDelete);

			return "User Eliminated".ToJson();
		}

		public async Task<UserEntity> GetUserByFireBaseIdAsync(string fireBaseId)
		{
			var filter = Builders<UserMongo>.Filter.And(
								Builders<UserMongo>.Filter.Eq(u => u.FireBaseId, fireBaseId),
								Builders<UserMongo>.Filter.Eq(b => b.IsDeleted, false));


			var user = await coleccionUser.Find(filter).FirstOrDefaultAsync();
			return _mapper.Map<UserEntity>(user);
		}

		public async Task<string> UpdateUserAsync(UpdateUserCommand user)
		{
			Guard.Against.NullOrEmpty(user.Name, nameof(user.Name), "Name Required. ");
			Guard.Against.NullOrEmpty(user.Email, nameof(user.Email));

			var filter = Builders<UserMongo>.Filter.Eq(u => u.UserId, user.UserId);
			var update = Builders<UserMongo>.Update.Set(u => u.Name, user.Name).Set(u => u.Email, user.Email);
			var result = await coleccionUser.UpdateOneAsync(filter, update);

			return "User Updated".ToJson();
		}
	}
}
