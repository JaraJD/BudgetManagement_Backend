using ActivityLog.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLog.Application.Features.Budget.Commands.UpdateBudget
{
	public class UpdateBudgetCommandHandler : IRequestHandler<UpdateBudgetCommand, string>
	{
		private readonly IBudgetRepository _budgetRepository;
		private readonly IMapper _mapper;

		public UpdateBudgetCommandHandler(IBudgetRepository budgetRepository, IMapper mapper)
		{
			_budgetRepository = budgetRepository;
			_mapper = mapper;
		}

		public async Task<string> Handle(UpdateBudgetCommand request, CancellationToken cancellationToken)
		{
			var budgetToUpdate = await _budgetRepository.GetByIdAsync(request.Id);

			if (budgetToUpdate == null)
			{
				throw new ArgumentNullException(nameof(budgetToUpdate));
			}

			_mapper.Map(request, budgetToUpdate, typeof(UpdateBudgetCommand), typeof(Domain.Entities.Budget));

			await _budgetRepository.UpdateAsync(budgetToUpdate);

			return $"Budget {request.Id} updated";
		}
	}
}
