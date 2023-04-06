using AutoMapper;
using FinancialGoal.Application.Contracts.Persistence;
using FinancialGoal.Application.Exceptions;
using MediatR;

namespace FinancialGoal.Application.Features.TargetSaving.Commands.UpdateTargetSaving
{
	public class UpdateTargetSavingCommandHandler : IRequestHandler<UpdateTargetSavingCommand, int>
	{
		private readonly ITargetSavingRepository _targetSavingRepository;
		private readonly IMapper _mapper;

		public UpdateTargetSavingCommandHandler(ITargetSavingRepository targetSavingRepository, IMapper mapper)
		{
			_targetSavingRepository = targetSavingRepository;
			_mapper = mapper;
		}

		public async Task<int> Handle(UpdateTargetSavingCommand request, CancellationToken cancellationToken)
		{
			var targetSavingToUpdate = await _targetSavingRepository.GetByIdAsync(request.Id);
			
			if (targetSavingToUpdate == null)
			{
				throw new NotFoundException(nameof(TargetSaving), request.Id);
			}

			_mapper.Map(request, targetSavingToUpdate, typeof(UpdateTargetSavingCommand), typeof(Domain.Entitie.TargetSaving));

			await _targetSavingRepository.UpdateAsync(targetSavingToUpdate);

			return request.Id;
		}
	}
}
