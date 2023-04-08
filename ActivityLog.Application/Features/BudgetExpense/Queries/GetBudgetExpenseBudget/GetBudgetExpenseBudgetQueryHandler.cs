using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Application.Features.BudgetExpense.Queries.Common;
using AutoMapper;
using MediatR;

namespace ActivityLog.Application.Features.BudgetExpense.Queries.GetBudgetExpenseBudget
{
	public class GetBudgetExpenseBudgetQueryHandler : IRequestHandler<GetBudgetExpenseBudgetQuery, List<BudgetExpenseVm>>
	{
		private readonly IBudgetExpenseRepository _budgetExpenseRepository;
		private readonly IMapper _mapper;

		public GetBudgetExpenseBudgetQueryHandler(IBudgetExpenseRepository budgetExpenseRepository, IMapper mapper)
		{
			_budgetExpenseRepository = budgetExpenseRepository;
			_mapper = mapper;
		}

		public async Task<List<BudgetExpenseVm>> Handle(GetBudgetExpenseBudgetQuery request, CancellationToken cancellationToken)
		{
			var budgetExpenseList = await _budgetExpenseRepository.GetBudgetExpenseByBudget(request._BudgetId);

			return _mapper.Map<List<BudgetExpenseVm>>(budgetExpenseList);
		}
	}
}
