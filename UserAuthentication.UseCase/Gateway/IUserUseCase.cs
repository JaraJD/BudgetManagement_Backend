
using UserAuthentication.Entities.Entities;
using UserAuthentication.Entities.Features.User.Commands;
using UserAuthentication.Entities.Features.User.Queries;

namespace UserAuthentication.UseCase.Gateway
{
	public interface IUserUseCase
	{
		Task<string> CreateUser(CreateUserCommand user);

		Task<string> UpdateUser(UpdateUserCommand user);

		Task<string> DeleteUser(DeleteUserCommand user);

		Task<UserEntity> GetUserByFireBaseId(string fireBaseId);
	}
}
