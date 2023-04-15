using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Application.Features.Budget.Queries.Common;
using ActivityLog.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActivityLog.Test
{
	public class TransactionRepositoryTest
	{
		private readonly Mock<ITransactionRepository> _mockTransactionRepository;

		public TransactionRepositoryTest()
		{
			_mockTransactionRepository = new Mock<ITransactionRepository>();
		}

		[Fact]
		public async Task CreateTransactionAsync()
		{
			//Arrange
			var transactionToCreate = new Transaction
			{
				Date = DateTime.Now,
				Type = "Gato",
				Amount = 2500,
				Description = "Pagos online",
				UserId = "6434318b1e01e1b13701d864",
				CategoryId = 1,
				BudgetId = 1
			};

			var transaction = new Transaction
			{
				Date = DateTime.Now,
				Type = "Gato",
				Amount = 2500,
				Description = "Pagos online",
				UserId = "6434318b1e01e1b13701d864",
				CategoryId = 1,
				BudgetId = 1
			};

			_mockTransactionRepository.Setup(x => x.CreateAsync(transactionToCreate)).ReturnsAsync(transaction);

			//Act

			var transactionResult = await _mockTransactionRepository.Object.CreateAsync(transactionToCreate);

			//Assert

			Assert.Equal(transaction, transactionResult);
		}

		[Fact]
		public async Task UpdateTransactionAsync()
		{
			//Arrange
			var transactionToUpdate = new Transaction
			{
				Id= 1,
				Date = DateTime.Now,
				Type = "Gato",
				Amount = 2500,
				Description = "Pagos online",
				UserId = "6434318b1e01e1b13701d864",
				CategoryId = 1,
				BudgetId = 1
			};

			var transaction = new Transaction
			{
				Id= 1,
				Date = DateTime.Now,
				Type = "Gato",
				Amount = 2500,
				Description = "Pagos online",
				UserId = "6434318b1e01e1b13701d864",
				CategoryId = 1,
				BudgetId = 1
			};

			_mockTransactionRepository.Setup(x => x.UpdateAsync(transactionToUpdate)).ReturnsAsync(transaction);

			//Act

			var transactionResult = await _mockTransactionRepository.Object.UpdateAsync(transactionToUpdate);

			//Assert

			Assert.Equal(transaction, transactionResult);
		}

		[Fact]
		public async Task GetTransactionByUser()
		{
			//Arrange
			var userId = "6434318b1e01e1b13701d864";

			var transactions = new List<Transaction>
			{
				new Transaction
				{
				Date = DateTime.Now,
				Type = "Gato",
				Amount = 2500,
				Description = "Pagos online",
				UserId = "6434318b1e01e1b13701d864",
				CategoryId = 1,
				BudgetId = 1
				}
			};

			_mockTransactionRepository.Setup(x => x.GetTransactionByUser(userId)).ReturnsAsync(transactions);

			//Act

			var transactionResult = await _mockTransactionRepository.Object.GetTransactionByUser(userId);

			//Assert

			Assert.Equal(transactions, transactionResult);
		}


		[Fact]
		public async Task GetTransactionByDate()
		{
			//Arrange
			var userId = "6434318b1e01e1b13701d864";

			var date = DateTime.Now;

			var transactions = new List<Transaction>
			{
				new Transaction
				{
				Date = DateTime.Now,
				Type = "Gato",
				Amount = 2500,
				Description = "Pagos online",
				UserId = "6434318b1e01e1b13701d864",
				CategoryId = 1,
				BudgetId = 1
				}
			};

			_mockTransactionRepository.Setup(x => x.GetTransactionByDate(userId, date)).ReturnsAsync(transactions);

			//Act

			var transactionResult = await _mockTransactionRepository.Object.GetTransactionByDate(userId, date);

			//Assert

			Assert.Equal(transactions, transactionResult);
		}


		[Fact]
		public async Task GetTransactionByType()
		{
			//Arrange
			var userId = "6434318b1e01e1b13701d864";

			var type = "Expense";

			var transactions = new List<Transaction>
			{
				new Transaction
				{
				Date = DateTime.Now,
				Type = "Expense",
				Amount = 2500,
				Description = "online",
				UserId = "6434318b1e01e1b13701d864",
				CategoryId = 1,
				BudgetId = 1
				}
			};

			_mockTransactionRepository.Setup(x => x.GetTransactionByType(userId, type)).ReturnsAsync(transactions);

			//Act

			var transactionResult = await _mockTransactionRepository.Object.GetTransactionByType(userId, type);

			//Assert

			Assert.Equal(transactions, transactionResult);
		}


		[Fact]
		public async Task GetTransactionByCategory()
		{
			//Arrange
			var userId = "6434318b1e01e1b13701d864";

			var categoryId = 1;

			var transactions = new List<Transaction>
			{
				new Transaction
				{
				Date = DateTime.Now,
				Type = "Expense",
				Amount = 2500,
				Description = "online",
				UserId = "6434318b1e01e1b13701d864",
				CategoryId = 1,
				BudgetId = 1
				}
			};

			_mockTransactionRepository.Setup(x => x.GetTransactionByCategory(userId, categoryId)).ReturnsAsync(transactions);

			//Act

			var transactionResult = await _mockTransactionRepository.Object.GetTransactionByCategory(userId, categoryId);

			//Assert

			Assert.Equal(transactions, transactionResult);
		}




	}
}
