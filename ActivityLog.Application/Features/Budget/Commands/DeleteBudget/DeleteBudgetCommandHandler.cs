using ActivityLog.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLog.Application.Features.Budget.Commands.DeleteBudget
{
	public class DeleteBudgetCommandHandler : IRequestHandler<DeleteBudgetCommand, string>
	{
		public readonly IBudgetRepository _budgetRepository;
		public readonly IMapper _mapper;

		public DeleteBudgetCommandHandler(IBudgetRepository budgetRepository, IMapper mapper)
		{
			_budgetRepository = budgetRepository;
			_mapper = mapper;
		}

		public async Task<string> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
		{
			var BudgetToDelete = await _budgetRepository.GetByIdAsync(request.Id);
			if (BudgetToDelete == null)
			{
				throw new ArgumentNullException(nameof(BudgetToDelete));
			}

			BudgetToDelete.IsDeleted = true;
			await _budgetRepository.UpdateAsync(BudgetToDelete);

			return $"Budget {request.Id} deleted ";
		}
	}
}
