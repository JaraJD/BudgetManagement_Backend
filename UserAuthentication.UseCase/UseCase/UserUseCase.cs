using UserAuthentication.Entities.Entities;
using UserAuthentication.Entities.Features.User.Commands;
using UserAuthentication.Entities.Features.User.Queries;
using UserAuthentication.UseCase.Gateway;
using UserAuthentication.UseCase.Gateway.Repository;

namespace UserAuthentication.UseCase.UseCase
{
	public class UserUseCase : IUserUseCase
	{
		private readonly IUserRepository _repository;

		public UserUseCase(IUserRepository repository)
		{
			_repository = repository;
		}

		public async Task<string> CreateUser(CreateUserCommand user)
		{
			return await _repository.CreateUserAsync(user);
		}

		public async Task<string> DeleteUser(DeleteUserCommand user)
		{
			return await _repository.DeleteUserAsync(user);
		}

		public async Task<UserEntity> GetUserByFireBaseId(GetUserByFireBaseIdQuery fireBaseId)
		{
			return await _repository.GetUserByFireBaseIdAsync(fireBaseId);
		}

		public Task<string> UpdateUser(UpdateUserCommand user)
		{
			return _repository.UpdateUserAsync(user);
		}
	}
}
