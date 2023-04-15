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
		public async Task CreateTBudgetAsync()
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
	}
}
