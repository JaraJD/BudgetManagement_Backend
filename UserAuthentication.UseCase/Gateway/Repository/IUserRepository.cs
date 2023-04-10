using UserAuthentication.Entities.Entities;
using UserAuthentication.Entities.Features.User.Commands;
using UserAuthentication.Entities.Features.User.Queries;

namespace UserAuthentication.UseCase.Gateway.Repository
{
	public interface IUserRepository
	{
		Task<string> CreateUserAsync(CreateUserCommand user);

		Task<string> UpdateUserAsync(UpdateUserCommand user);

		Task<string> DeleteUserAsync(DeleteUserCommand user);

		Task<UserEntity> GetUserByFireBaseIdAsync(GetUserByFireBaseIdQuery fireBaseId);
	}
}
