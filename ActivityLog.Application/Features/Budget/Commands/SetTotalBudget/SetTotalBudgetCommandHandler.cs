using ActivityLog.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System.Text.Json;

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
			var validation = budgetToSet.MonthlyTotal + request.Amount;
			if (validation < 0)
			{
				budgetToSet.MonthlyTotal = 0;
			}
			else
			{
				budgetToSet.MonthlyTotal += request.Amount;
			}
			await _budgetRepository.SetMonthlyTotalBudget(budgetToSet);

			return JsonSerializer.Serialize($"Monthly Total Updated");
		}
	}
}
