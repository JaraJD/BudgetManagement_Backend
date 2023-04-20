using ActivityLog.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System.Text.Json;

namespace ActivityLog.Application.Features.BudgetExpense.Commands.UpdateBudgetExpense
{
	public class UpdateBudgetExpenseCommandHandler : IRequestHandler<UpdateBudgetExpenseCommand, string>
	{
		private readonly IBudgetExpenseRepository _BudgetExpenseRepository;
		private readonly IMapper _mapper;

		public UpdateBudgetExpenseCommandHandler(IBudgetExpenseRepository budgetExpenseRepository, IMapper mapper)
		{
			_BudgetExpenseRepository = budgetExpenseRepository;
			_mapper = mapper;
		}

		public async Task<string> Handle(UpdateBudgetExpenseCommand request, CancellationToken cancellationToken)
		{
			var budgetExpenseToUpdate = await _BudgetExpenseRepository.GetByIdAsync(request.Id);
			if (budgetExpenseToUpdate == null)
			{
				throw new ArgumentNullException(nameof(budgetExpenseToUpdate));
			}

			_mapper.Map(request, budgetExpenseToUpdate, typeof(UpdateBudgetExpenseCommand), typeof(Domain.Entities.BudgetExpense));

			await _BudgetExpenseRepository.UpdateAsync(budgetExpenseToUpdate);

			return JsonSerializer.Serialize($"Budget Expense {request.Id} Updated");
		}
	}
}
