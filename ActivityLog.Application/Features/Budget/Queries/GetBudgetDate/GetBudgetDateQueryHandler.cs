using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Application.Features.Budget.Queries.Common;
using AutoMapper;
using MediatR;

namespace ActivityLog.Application.Features.Budget.Queries.GetBudgetDate
{
	public class GetBudgetDateQueryHandler : IRequestHandler<GetBudgetDateQuery, List<BudgetVm>>
	{
		private readonly IBudgetRepository _budgetRepository;
		private readonly IMapper _mapper;

		public GetBudgetDateQueryHandler(IBudgetRepository budgetRepository, IMapper mapper)
		{
			_budgetRepository = budgetRepository;
			_mapper = mapper;
		}

		public async Task<List<BudgetVm>> Handle(GetBudgetDateQuery request, CancellationToken cancellationToken)
		{
			var budgets = await _budgetRepository.GetBudgetByDate(request._UserId, request._TargetMonth);
			return _mapper.Map<List<BudgetVm>>(budgets);
		}
	}
}
