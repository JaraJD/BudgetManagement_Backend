using ActivityLog.Application.Contracts.Persistence;
using MediatR;
using System.Text.Json;

namespace ActivityLog.Application.Features.BudgetExpense.Commands.DeleteBudgetExpense
{
	public class DeleteBudgetExpenseCommandHandler : IRequestHandler<DeleteBudgetExpenseCommand, string>
	{
		private readonly IBudgetExpenseRepository _budgetExpenseRepository;

		public DeleteBudgetExpenseCommandHandler(IBudgetExpenseRepository budgetExpenseRepository)
		{
			_budgetExpenseRepository = budgetExpenseRepository;
		}

		public async Task<string> Handle(DeleteBudgetExpenseCommand request, CancellationToken cancellationToken)
		{
			var budgetExpenseToDelete = await _budgetExpenseRepository.GetByIdAsync(request.Id);
			if (budgetExpenseToDelete == null)
			{
				throw new ArgumentNullException(nameof(budgetExpenseToDelete));
			}

			budgetExpenseToDelete.IsDeleted = true;
			await _budgetExpenseRepository.UpdateAsync(budgetExpenseToDelete);

			return JsonSerializer.Serialize($"Budget Expense {request.Id} Deleted");
		}
	}
}
