using ActivityLog.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System.Text.Json;
using BudgetExp = ActivityLog.Domain.Entities.BudgetExpense;

namespace ActivityLog.Application.Features.BudgetExpense.Commands.CreateBudgetExpense
{
	public class CreateBudgetExpenseCommandHandler : IRequestHandler<CreateBudgetExpenseCommand, string>
	{
		private readonly IBudgetExpenseRepository _budgetExpenseRepository;
		private readonly IMapper _mapper;

		public CreateBudgetExpenseCommandHandler(IBudgetExpenseRepository budgetExpenseRepository, IMapper mapper)
		{
			_budgetExpenseRepository = budgetExpenseRepository;
			_mapper = mapper;
		}

		public async Task<string> Handle(CreateBudgetExpenseCommand request, CancellationToken cancellationToken)
		{
			var BudgetExpenseToCreate = _mapper.Map<BudgetExp>(request);
			var result = await _budgetExpenseRepository.CreateAsync(BudgetExpenseToCreate);

			return JsonSerializer.Serialize($"Budget Expense {result.Id} Created");
		}
	}
}
