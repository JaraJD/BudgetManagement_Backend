using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAuthentication.DrivenAdapter.Repositories;
using UserAuthentication.Entities.Entities;
using UserAuthentication.Entities.Features.Balance.Commands;
using UserAuthentication.Entities.Features.Balance.Queries;
using UserAuthentication.Entities.Features.User.Commands;
using UserAuthentication.Entities.Features.User.Queries;
using UserAuthentication.UseCase.Gateway.Repository;

namespace UserAuthentication.AppService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UserController(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<string> CreateUser([FromBody] CreateUserCommand command)
		{
			return await _userRepository.CreateUserAsync(command);
		}

		[HttpDelete("DeleteUser")]
		public async Task<string> DeleteUser(DeleteUserCommand command)
		{
			return await _userRepository.DeleteUserAsync(command);
		}

		[HttpGet("GetUser")]
		public async Task<UserEntity> GetUserById(string id)
		{
			return await _userRepository.GetUserByFireBaseIdAsync(id);
		}

		[HttpPut("UpdateUser")]
		public async Task<string> UpdateUser([FromBody] UpdateUserCommand command)
		{
			return await _userRepository.UpdateUserAsync(command);
		}
	}
}
