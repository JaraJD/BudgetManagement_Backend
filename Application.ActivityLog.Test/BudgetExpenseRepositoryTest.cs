using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Domain.Entities;
using Moq;

namespace Application.ActivityLog.Test
{
	public class BudgetExpenseRepositoryTest
	{
		private readonly Mock<IBudgetExpenseRepository> _mockBudgetExpenseRepository;

		public BudgetExpenseRepositoryTest()
		{
			_mockBudgetExpenseRepository = new Mock<IBudgetExpenseRepository>();
		}


		[Fact]
		public async Task CreateTBudgetExpenseAsync()
		{
			//Arrange
			var budgetExpenseToCreate = new BudgetExpense
			{
				Amount = 2500,
				Description = "Home",
				BudgetId = 3,
				CategoryId = 5
			};

			var budgetExpense = new BudgetExpense
			{
				Amount = 2500,
				Description = "Home",
				BudgetId = 3,
				CategoryId = 5
			};

			_mockBudgetExpenseRepository.Setup(x => x.CreateAsync(budgetExpenseToCreate)).ReturnsAsync(budgetExpense);

			//Act

			var expenseResult = await _mockBudgetExpenseRepository.Object.CreateAsync(budgetExpenseToCreate);

			//Assert

			Assert.Equal(budgetExpense, expenseResult);

		}


		[Fact]
		public async Task UpdateBudgetExpenseAsync()
		{
			//Arrange
			var budgetExpenseToUpdate = new BudgetExpense
			{
				Amount = 2500,
				Description = "Home",
				BudgetId = 3,
				CategoryId = 5
			};

			var budgetExpense = new BudgetExpense
			{
				Amount = 2500,
				Description = "Home",
				BudgetId = 3,
				CategoryId = 5
			};

			_mockBudgetExpenseRepository.Setup(x => x.UpdateAsync(budgetExpenseToUpdate)).ReturnsAsync(budgetExpense);

			//Act

			var ExpenseResult = await _mockBudgetExpenseRepository.Object.UpdateAsync(budgetExpenseToUpdate);

			//Assert

			Assert.Equal(budgetExpense, ExpenseResult);

		}


		[Fact]
		public async Task DeleteBudgetExpenseAsync()
		{
			//Arrange
			var budgetExpenseToDelete = new BudgetExpense
			{
				Amount = 2500,
				Description = "Home",
				BudgetId = 3,
				CategoryId = 5
			};

			var expense = 0;

			_mockBudgetExpenseRepository.Setup(x => x.DeleteAsync(budgetExpenseToDelete));

			//Act

			await _mockBudgetExpenseRepository.Object.DeleteAsync(budgetExpenseToDelete);

			//Assert

			Assert.Equal(expense, expense);

		}


		[Fact]
		public async Task GetBudgetExpenseByBudget()
		{
			//Arrange
			var budget = 1;

			var BudgetExpenseEntity = new List<BudgetExpense>
			{
				new BudgetExpense
				{
				Amount = 2500,
				Description = "Home",
				BudgetId = 3,
				CategoryId = 5
				}
			};

			_mockBudgetExpenseRepository.Setup(x => x.GetBudgetExpenseByBudget(budget)).ReturnsAsync(BudgetExpenseEntity);

			//Act

			var expenseResult = await _mockBudgetExpenseRepository.Object.GetBudgetExpenseByBudget(budget);

			//Assert

			Assert.Equal(BudgetExpenseEntity, expenseResult);

		}



	}
}
