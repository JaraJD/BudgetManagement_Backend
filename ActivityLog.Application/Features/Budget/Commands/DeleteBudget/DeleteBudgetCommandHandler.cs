using ActivityLog.Application.Contracts.Persistence;
using MediatR;

namespace ActivityLog.Application.Features.Budget.Commands.DeleteBudget
{
	public class DeleteBudgetCommandHandler : IRequestHandler<DeleteBudgetCommand, string>
	{
		public readonly IBudgetRepository _budgetRepository;

		public DeleteBudgetCommandHandler(IBudgetRepository budgetRepository)
		{
			_budgetRepository = budgetRepository;
		}

		public async Task<string> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
		{
			var BudgetToDelete = await _budgetRepository.GetByIdAsync(request.Id);
			if (BudgetToDelete == null)
			{
				throw new ArgumentNullException(nameof(BudgetToDelete));
			}

			BudgetToDelete.IsDeleted = true;
			await _budgetRepository.UpdateAsync(BudgetToDelete);

			return $"Budget {request.Id} deleted ";
		}
	}
}
