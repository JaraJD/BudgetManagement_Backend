using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Application.Features.Budget.Queries.Common;
using AutoMapper;
using MediatR;

namespace ActivityLog.Application.Features.Budget.Queries.GetBudgetName
{
	public class GetBudgetNameQueryHandler : IRequestHandler<GetBudgetNameQuery, List<BudgetVm>>
	{
		private readonly IBudgetRepository _budgetRepository;
		private readonly IMapper _mapper;

		public GetBudgetNameQueryHandler(IBudgetRepository budgetRepository, IMapper mapper)
		{
			_budgetRepository = budgetRepository;
			_mapper = mapper;
		}

		public async Task<List<BudgetVm>> Handle(GetBudgetNameQuery request, CancellationToken cancellationToken)
		{
			var budgetList = await _budgetRepository.GetBudgetByName(request._UserId, request._Name);

			return _mapper.Map<List<BudgetVm>>(budgetList);
		}
	}
}
