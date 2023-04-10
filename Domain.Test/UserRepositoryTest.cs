using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuthentication.Entities.Entities;
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
				Email = "juan@correo.com",
				FireBaseId = "AATTRR"
			};

			var user = "User Created";

			_userRepositoryMock.Setup(x => x.CreateUserAsync(userToCreate)).ReturnsAsync(user);

			//Act

			var userResult = await _userRepositoryMock.Object.CreateUserAsync(userToCreate);

			//Assert

			Assert.Equal(user, userResult);

		}


		[Fact]
		public async Task DeleteUserAsync()
		{
			//Arrange
			var userToDelete = new DeleteUserCommand
			{
				UserId = "6434318b1e01e1b13701d864"
			};

			var user = "User Deleted";

			_userRepositoryMock.Setup(x => x.DeleteUserAsync(userToDelete)).ReturnsAsync(user);

			//Act

			var userResult = await _userRepositoryMock.Object.DeleteUserAsync(userToDelete);

			//Assert

			Assert.Equal(user, userResult);

		}


		[Fact]
		public async Task GetUserByFireBaseId()
		{
			//Arrange
			var fireBaseId = "AATTRR";

			var user = new UserEntity
			{
				UserId = "6434318b1e01e1b13701d864",
				Name = "Cuenta1",
				Email = "juan@correo.com",
				FireBaseId = "AATTRR",
				IsDeleted = false
			};

			_userRepositoryMock.Setup(x => x.GetUserByFireBaseIdAsync(fireBaseId)).ReturnsAsync(user);

			// Act
			var result = await _userRepositoryMock.Object.GetUserByFireBaseIdAsync(fireBaseId);

			// Assert
			Assert.Equal(user, result);
		}


		[Fact]
		public async Task UpdateUserAsync()
		{
			//Arrange
			var userToUpdate = new UpdateUserCommand
			{
				UserId = "6434318b1e01e1b13701d864",
				Name = "Cuenta1",
				Email = "juan@correo.com",
			};

			var result = "User Updated";

			_userRepositoryMock.Setup(x => x.UpdateUserAsync(userToUpdate)).ReturnsAsync(result);

			//Act

			var userResult = await _userRepositoryMock.Object.UpdateUserAsync(userToUpdate);

			//Assert

			Assert.Equal(result, userResult);

		}


	}
}
