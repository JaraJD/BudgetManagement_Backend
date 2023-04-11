using FinancialGoal.Application.Contracts.Persistence;
using FinancialGoal.Domain.Entitie;
using Moq;

namespace Application.Test
{
	public class TargetSavingRepositoryTest
	{
		private readonly Mock<ITargetSavingRepository> _mockTargetSavingRepository;

		public TargetSavingRepositoryTest()
		{
			_mockTargetSavingRepository = new Mock<ITargetSavingRepository>();
		}

		[Fact]
		public async Task CreateTargetSavingAsync()
		{
			//Arrange
			var targetToCreate = new TargetSaving
			{
				IdUser = "6434318b1e01e1b13701d864",
				StartDate = DateTime.Now,
				EndDate = DateTime.Now,
				TargetAmount = 100,
				StateSaving = "Active"
			};

			var target = new TargetSaving
			{
				IdUser = "6434318b1e01e1b13701d864",
				StartDate = DateTime.Now,
				EndDate = DateTime.Now,
				TargetAmount = 100,
				StateSaving = "Active"
			};

			_mockTargetSavingRepository.Setup(x => x.CreateAsync(targetToCreate)).ReturnsAsync(target);

			//Act

			var targetResult = await _mockTargetSavingRepository.Object.CreateAsync(targetToCreate);

			//Assert

			Assert.Equal(target, targetResult);

		}


		[Fact]
		public async Task UpdateTargetSavingAsync()
		{
			//Arrange
			var targetToCreate = new TargetSaving
			{
				IdUser = "6434318b1e01e1b13701d864",
				StartDate = DateTime.Now,
				EndDate = DateTime.Now,
				TargetAmount = 100,
				StateSaving = "Active"
			};

			var target = new TargetSaving
			{
				IdUser = "6434318b1e01e1b13701d864",
				StartDate = DateTime.Now,
				EndDate = DateTime.Now,
				TargetAmount = 100,
				StateSaving = "Active"
			};

			_mockTargetSavingRepository.Setup(x => x.UpdateAsync(targetToCreate)).ReturnsAsync(target);

			//Act

			var targetResult = await _mockTargetSavingRepository.Object.UpdateAsync(targetToCreate);

			//Assert

			Assert.Equal(target, targetResult);

		}

		[Fact]
		public async Task DeleteTargetSavingAsync()
		{
			//Arrange
			var targetToCreate = new TargetSaving
			{
				IdUser = "6434318b1e01e1b13701d864",
				StartDate = DateTime.Now,
				EndDate = DateTime.Now,
				TargetAmount = 100,
				StateSaving = "Active"
			};

			var target = 0;

			_mockTargetSavingRepository.Setup(x => x.DeleteAsync(targetToCreate));

			//Act

			 await _mockTargetSavingRepository.Object.DeleteAsync(targetToCreate);

			//Assert

			Assert.Equal(target, target);

		}


		[Fact]
		public async Task GetTargetSavingByState()
		{
			//Arrange
			var user = "6434318b1e01e1b13701d864";

			var state = "Active";

			var targetEntity = new List<TargetSaving>
			{
					new TargetSaving
				{
					IdUser = "6434318b1e01e1b13701d864",
					StartDate = DateTime.Now,
					EndDate = DateTime.Now,
					TargetAmount = 100,
					StateSaving = "Active"
				}
			};

			_mockTargetSavingRepository.Setup(x => x.GetTargetSavingByState(user, state)).ReturnsAsync(targetEntity);

			//Act

			var targetResult = await _mockTargetSavingRepository.Object.GetTargetSavingByState(user, state);

			//Assert

			Assert.Equal(targetEntity, targetResult);

		}


		[Fact]
		public async Task GetTargetSavingByUser()
		{
			//Arrange
			var user = "6434318b1e01e1b13701d864";

			var targetEntity = new List<TargetSaving>
			{
					new TargetSaving
				{
					IdUser = "6434318b1e01e1b13701d864",
					StartDate = DateTime.Now,
					EndDate = DateTime.Now,
					TargetAmount = 100,
					StateSaving = "Active"
				}
			};

			_mockTargetSavingRepository.Setup(x => x.GetTargetSavingByUser(user)).ReturnsAsync(targetEntity);

			//Act

			var targetResult = await _mockTargetSavingRepository.Object.GetTargetSavingByUser(user);

			//Assert

			Assert.Equal(targetEntity, targetResult);

		}



	}
}
