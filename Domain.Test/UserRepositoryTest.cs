using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuthentication.Entities.Features.Balance.Commands;
using UserAuthentication.Entities.Features.User.Commands;
using UserAuthentication.UseCase.Gateway.Repository;

namespace Domain.Test
{
	public class UserRepositoryTest
	{
		private readonly Mock<IUserRepository> _userRepositoryMock;

		public UserRepositoryTest()
		{
			_userRepositoryMock= new Mock<IUserRepository>();
		}

		[Fact]
		public async Task CreateUserAsync()
		{
			//Arrange
			var userToCreate = new CreateUserCommand
			{
				Name = "Cuenta1",
				Email = "6434318b1e01e1b13701d864",
				FireBaseId = "AATTRR"
			};

			var user = "User Created";

			_userRepositoryMock.Setup(x => x.CreateUserAsync(userToCreate)).ReturnsAsync(user);

			//Act

			var balanceResult = await _userRepositoryMock.Object.CreateUserAsync(userToCreate);

			//Assert

			Assert.Equal(user, balanceResult);

		}
	}
}
