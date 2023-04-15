using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Domain.Entities;
using Moq;

namespace Application.ActivityLog.Test
{
	public class BudgetRepositoryTest
	{
		private readonly Mock<IBudgetRepository> _mockBudgetRepository;

		public BudgetRepositoryTest()
		{
			_mockBudgetRepository = new Mock<IBudgetRepository>();
		}

		[Fact]
		public async Task CreateBudgetAsync()
		{
			//Arrange
			var budgetToCreate = new Budget
			{
				IdUser = "6434318b1e01e1b13701d864",
				Name = "Prueba1",
				TargetMonth = DateTime.Now,
				Balance = 5000,
				MonthlyTotal = 2600,
				State = "Pending",
			};

			var budget = new Budget
			{
				IdUser = "6434318b1e01e1b13701d864",
				Name = "Prueba1",
				TargetMonth = DateTime.Now,
				Balance = 5000,
				MonthlyTotal = 2600,
				State = "Pending",
			};

			_mockBudgetRepository.Setup(x => x.CreateAsync(budgetToCreate)).ReturnsAsync(budget);

			//Act

			var budgetResult = await _mockBudgetRepository.Object.CreateAsync(budgetToCreate);

			//Assert

			Assert.Equal(budget, budgetResult);
		}


		[Fact]
		public async Task UpdateBudgetAsync()
		{
			//Arrange
			var budgetToUpdate = new Budget
			{
				Id = 1,
				IdUser = "6434318b1e01e1b13701d864",
				Name = "Prueba1",
				TargetMonth = DateTime.Now,
				Balance = 5000,
				MonthlyTotal = 2600,
				State = "Pending",
			};

			var budget = new Budget
			{
				Id = 1,
				IdUser = "6434318b1e01e1b13701d864",
				Name = "Prueba1",
				TargetMonth = DateTime.Now,
				Balance = 5000,
				MonthlyTotal = 2600,
				State = "Pending",
			};

			_mockBudgetRepository.Setup(x => x.UpdateAsync(budgetToUpdate)).ReturnsAsync(budget);

			//Act

			var budgetResult = await _mockBudgetRepository.Object.UpdateAsync(budgetToUpdate);

			//Assert

			Assert.Equal(budget, budgetResult);

		}


		[Fact]
		public async Task DeleteBudgetAsync()
		{
			//Arrange
			var budgetToDelete = new Budget
			{
				Id = 1,
			};

			var budgetId = 1;

			_mockBudgetRepository.Setup(x => x.DeleteAsync(budgetToDelete));

			//Act

			await _mockBudgetRepository.Object.DeleteAsync(budgetToDelete);

			//Assert

			Assert.Equal(budgetId, budgetId);

		}


		[Fact]
		public async Task GetBudgetByUser()
		{
			//Arrange
			var userId = "6434318b1e01e1b13701d864";

			var budget = new List<Budget>
			{
				new Budget
				{
				IdUser = "6434318b1e01e1b13701d864",
				Name = "Prueba1",
				TargetMonth = DateTime.Now,
				Balance = 5000,
				MonthlyTotal = 2600,
				State = "Pending",
				}
			};

			_mockBudgetRepository.Setup(x => x.GetBudgetByUser(userId)).ReturnsAsync(budget);

			//Act

			var budgetResult = await _mockBudgetRepository.Object.GetBudgetByUser(userId);

			//Assert

			Assert.Equal(budget, budgetResult);
		}



		[Fact]
		public async Task GetBudgetByDate()
		{
			//Arrange
			var userId = "6434318b1e01e1b13701d864";

			var date = DateTime.Now;

			var budget = new List<Budget>
			{
				new Budget
				{
				IdUser = "6434318b1e01e1b13701d864",
				Name = "Prueba1",
				TargetMonth = DateTime.Now,
				Balance = 5000,
				MonthlyTotal = 2600,
				State = "Pending",
				}
			};

			_mockBudgetRepository.Setup(x => x.GetBudgetByDate(userId, date)).ReturnsAsync(budget);

			//Act

			var budgetResult = await _mockBudgetRepository.Object.GetBudgetByDate(userId, date);

			//Assert

			Assert.Equal(budget, budgetResult);
		}


		[Fact]
		public async Task GetBudgetByName()
		{
			//Arrange
			var userId = "6434318b1e01e1b13701d864";

			var name = "Prueba1";

			var budget = new List<Budget>
			{
				new Budget
				{
				IdUser = "6434318b1e01e1b13701d864",
				Name = "Prueba1",
				TargetMonth = DateTime.Now,
				Balance = 5000,
				MonthlyTotal = 2600,
				State = "Pending",
				}
			};

			_mockBudgetRepository.Setup(x => x.GetBudgetByName(userId, name)).ReturnsAsync(budget);

			//Act

			var budgetResult = await _mockBudgetRepository.Object.GetBudgetByName(userId, name);

			//Assert

			Assert.Equal(budget, budgetResult);
		}


		[Fact]
		public async Task GetBudgetByState()
		{
			//Arrange
			var userId = "6434318b1e01e1b13701d864";

			var state = "Pending";

			var budget = new List<Budget>
			{
				new Budget
				{
				IdUser = "6434318b1e01e1b13701d864",
				Name = "Prueba1",
				TargetMonth = DateTime.Now,
				Balance = 5000,
				MonthlyTotal = 2600,
				State = "Pending",
				}
			};

			_mockBudgetRepository.Setup(x => x.GetBudgetByName(userId, state)).ReturnsAsync(budget);

			//Act

			var budgetResult = await _mockBudgetRepository.Object.GetBudgetByName(userId, state);

			//Assert

			Assert.Equal(budget, budgetResult);
		}


		[Fact]
		public async Task SetMonthlyTotalBudget()
		{
			//Arrange
			var budgetToSet = new Budget
			{
				IdUser = "6434318b1e01e1b13701d864",
				Name = "Prueba1",
				TargetMonth = DateTime.Now,
				Balance = 5000,
				MonthlyTotal = 2600,
				State = "Pending",
			};

			var result = "Updated";

			_mockBudgetRepository.Setup(x => x.SetMonthlyTotalBudget(budgetToSet)).ReturnsAsync(result);

			//Act

			var budgetResult = await _mockBudgetRepository.Object.SetMonthlyTotalBudget(budgetToSet);

			//Assert

			Assert.Equal(result, budgetResult);
		}


	}
}
