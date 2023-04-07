using AutoMapper;
using FinancialGoal.Application.Contracts.Persistence;
using FinancialGoal.Application.Exceptions;
using FinancialGoal.Application.Features.TargetSaving.Commands.UpdateTargetSaving;
using MediatR;

namespace FinancialGoal.Application.Features.TargetSaving.Commands.DeleteTargetSaving
{
	public class DeleteTargetSavingCommandHandler : IRequestHandler<DeleteTargetSavingCommand, int>
	{
		private readonly ITargetSavingRepository _targetSavingRepository;
		private readonly IMapper _mapper;

		public DeleteTargetSavingCommandHandler(ITargetSavingRepository targetSavingrepository, IMapper mapper)
		{
			_targetSavingRepository = targetSavingrepository;
			_mapper = mapper;
		}

		public async Task<int> Handle(DeleteTargetSavingCommand request, CancellationToken cancellationToken)
		{
			var savingToDelete = await _targetSavingRepository.GetByIdAsync(request.Id);
			if (savingToDelete == null)
			{
				throw new NotFoundException(nameof(TargetSaving), request.Id);
			}

			_mapper.Map(request, savingToDelete, typeof(DeleteTargetSavingCommand), typeof(Domain.Entitie.TargetSaving));
			savingToDelete.IsDeleted = true;

			await _targetSavingRepository.UpdateAsync(savingToDelete);

			return request.Id;

		}
	}
}
