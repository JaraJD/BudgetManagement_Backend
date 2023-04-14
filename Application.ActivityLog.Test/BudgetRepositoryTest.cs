using ActivityLog.Application.Contracts.Persistence;
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


	}
}
