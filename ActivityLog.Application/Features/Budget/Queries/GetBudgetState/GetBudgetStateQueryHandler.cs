using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Application.Features.Budget.Queries.Common;
using AutoMapper;
using MediatR;

namespace ActivityLog.Application.Features.Budget.Queries.GetBudgetState
{
	public class GetBudgetStateQueryHandler : IRequestHandler<GetBudgetStateQuery, List<BudgetVm>>
	{
		private readonly IBudgetRepository _budgetRepository;
		private readonly IMapper _mapper;

		public GetBudgetStateQueryHandler(IBudgetRepository budgetRepository, IMapper mapper)
		{
			_budgetRepository = budgetRepository;
			_mapper = mapper;
		}

		public async Task<List<BudgetVm>> Handle(GetBudgetStateQuery request, CancellationToken cancellationToken)
		{
			var budgetList = await _budgetRepository.GetBudgetByState(request._UserId, request._State);

			return _mapper.Map<List<BudgetVm>>(budgetList);
		}
	}
}
