using ActivityLog.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace ActivityLog.Application.Features.Budget.Commands.SetTotalBudget
{
	public class SetTotalBudgetCommandHandler : IRequestHandler<SetTotalBudgetCommand, string>
	{
		private readonly IBudgetRepository _budgetRepository;
		private readonly IMapper _mapper;

		public SetTotalBudgetCommandHandler(IBudgetRepository budgetRepository, IMapper mapper)
		{
			_budgetRepository = budgetRepository;
			_mapper = mapper;
		}

		public async Task<string> Handle(SetTotalBudgetCommand request, CancellationToken cancellationToken)
		{
			var budgetToSet = await _budgetRepository.GetByIdAsync(request.Id);
			if (budgetToSet == null)
			{
				throw new ArgumentNullException(nameof(budgetToSet));
			}
			budgetToSet.MonthlyTotal += request.Amount;
			await _budgetRepository.SetMonthlyTotalBudget(budgetToSet);

			return $"Monthly Total Updated";
		}
	}
}
