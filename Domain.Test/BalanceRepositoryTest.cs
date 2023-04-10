using Moq;
using UserAuthentication.Entities.Entities;
using UserAuthentication.Entities.Features.Balance.Commands;
using UserAuthentication.UseCase.Gateway.Repository;

namespace Domain.Test
{
	public class BalanceRepositoryTest
	{
		private readonly Mock<IBalanceRepository> _mockBalanceRepository;

		public BalanceRepositoryTest()
		{
			_mockBalanceRepository = new Mock<IBalanceRepository>();
		}

		[Fact]
		public async Task CreateBalanceAsync()
		{
			//Arrange
			var balanceToCreate = new CreateBalanceCommand
			{
				UserId = "6434318b1e01e1b13701d864",
				Name = "Cuenta1",
				Amount = 1000
			};

			var balance = "Balance Created";

			_mockBalanceRepository.Setup(x => x.CreateBalanceAsync(balanceToCreate)).ReturnsAsync(balance);

			//Act

			var balanceResult = await _mockBalanceRepository.Object.CreateBalanceAsync(balanceToCreate);

			//Assert

			Assert.Equal(balance, balanceResult);

		}

		[Fact]
		public async Task UpdateBalanceAsync()
		{
			//Arrange
			var balanceToUpdate = new UpdateBalanceCommand
			{
				BalanceId = "6434318b1e01e1b13701d864",
				Name = "cuenta1"
			};

			var balance = "Balance Updated";

			_mockBalanceRepository.Setup(x => x.UpdateBalanceAsync(balanceToUpdate)).ReturnsAsync(balance);

			// Act
			var result = await _mockBalanceRepository.Object.UpdateBalanceAsync(balanceToUpdate);

			// Assert
			Assert.Equal(balance, result);
		}

		[Fact]
		public async Task DeleteBalanceAsync()
		{
			//Arrange
			var balanceToDelete = new DeleteBalanceCommand
			{
				BalanceId = "6434318b1e01e1b13701d864",
			};

			var balance = "Balance Deleted";

			_mockBalanceRepository.Setup(x => x.DeleteBalanceAsync(balanceToDelete)).ReturnsAsync(balance);

			// Act
			var result = await _mockBalanceRepository.Object.DeleteBalanceAsync(balanceToDelete);

			// Assert
			Assert.Equal(balance, result);
		}

		[Fact]
		public async Task ResetBalanceAsync()
		{
			//Arrange
			var balanceToReset = new ResetBalanceCommand
			{
				BalanceId = "6434318b1e01e1b13701d864",
			};

			var balance = "Balance Reset";

			_mockBalanceRepository.Setup(x => x.ResetBalanceAsync(balanceToReset)).ReturnsAsync(balance);

			// Act
			var result = await _mockBalanceRepository.Object.ResetBalanceAsync(balanceToReset);

			// Assert
			Assert.Equal(balance, result);
		}

		[Fact]
		public async Task SetBalanceAsync()
		{
			//Arrange
			var balanceToSet = new SetBalanceCommand
			{
				BalanceId = "6434318b1e01e1b13701d864",
				Value = 2000
			};

			var balance = "Balance Set";

			_mockBalanceRepository.Setup(x => x.SetBalanceAsync(balanceToSet)).ReturnsAsync(balance);

			// Act
			var result = await _mockBalanceRepository.Object.SetBalanceAsync(balanceToSet);

			// Assert
			Assert.Equal(balance, result);
		}

		[Fact]
		public async Task GetBalanceByUser()
		{
			//Arrange
			var balanceId = "6434318b1e01e1b13701d864";

			var balanceEntity = new List<BalanceEntity>
			{
				new BalanceEntity
				{
					BalanceId = "6434318b1e01e1b13701d864",
					UserId = "5678",
					Name = "John Doe",
					Amount = 100,
					IsDeleted = false
				}
			};

			_mockBalanceRepository.Setup(x => x.GetBalanceByUserAsync(balanceId)).ReturnsAsync(balanceEntity);

			// Act
			var result = await _mockBalanceRepository.Object.GetBalanceByUserAsync(balanceId);

			// Assert
			Assert.Equal(balanceEntity, result);
		}


		[Fact]
		public async Task DeductBalanceAsync()
		{
			//Arrange
			var balanceToSet = new SetBalanceCommand
			{
				BalanceId = "6434318b1e01e1b13701d864",
				Value = 1000
			};

			var balance = "Balance Deduct";

			_mockBalanceRepository.Setup(x => x.DeductBalanceAsync(balanceToSet)).ReturnsAsync(balance);

			// Act
			var result = await _mockBalanceRepository.Object.DeductBalanceAsync(balanceToSet);

			// Assert
			Assert.Equal(balance, result);
		}


	}
}
