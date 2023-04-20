using ActivityLog.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System.Text.Json;

namespace ActivityLog.Application.Features.Budget.Commands.CreateBudget
{
	public class CreateBudgetCommandHandler : IRequestHandler<CreateBudgetCommand, string>
	{
		private readonly IBudgetRepository _budgetRepository;
		private readonly IMapper _mapper;

		public CreateBudgetCommandHandler(IBudgetRepository budgetRepository, IMapper mapper)
		{
			_budgetRepository = budgetRepository;
			_mapper = mapper;
		}

		public async Task<string> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
		{
			var budgetToCreate = _mapper.Map<Domain.Entities.Budget>(request);
			var result = await _budgetRepository.CreateAsync(budgetToCreate);

			return JsonSerializer.Serialize($"Budget {result.Id} Created");
		}
	}
}
