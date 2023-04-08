using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Application.Features.Budget.Queries.Common;
using AutoMapper;
using MediatR;

namespace ActivityLog.Application.Features.Budget.Queries.GetBudgetUser
{
	public class GetBudgetUserQueryHandler : IRequestHandler<GetBudgetUserQuery, List<BudgetVm>>
	{
		private readonly IBudgetRepository _budgetRepository;
		private readonly IMapper _mapper;

		public GetBudgetUserQueryHandler(IBudgetRepository budgetRepository, IMapper mapper)
		{
			_budgetRepository = budgetRepository;
			_mapper = mapper;
		}

		public async Task<List<BudgetVm>> Handle(GetBudgetUserQuery request, CancellationToken cancellationToken)
		{
			var budgetList = await _budgetRepository.GetBudgetByUser(request._UserId);

			return _mapper.Map<List<BudgetVm>>(budgetList);
		}
	}
}
