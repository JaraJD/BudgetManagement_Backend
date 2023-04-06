using AutoMapper;
using FinancialGoal.Application.Contracts.Persistence;
using FinancialGoal.Application.Exceptions;
using MediatR;

namespace FinancialGoal.Application.Features.TargetSaving.Commands.DeleteTargetSaving
{
	public class DeleteTargetSavingCommandHandler : IRequestHandler<DeleteTargetSavingCommand, int>
	{
		private readonly ITargetSavingRepository _TargetSavingrepository;
		private readonly IMapper _Mapper;

		public DeleteTargetSavingCommandHandler(ITargetSavingRepository targetSavingrepository, IMapper mapper)
		{
			_TargetSavingrepository = targetSavingrepository;
			_Mapper = mapper;
		}

		public async Task<int> Handle(DeleteTargetSavingCommand request, CancellationToken cancellationToken)
		{
			var savingToDelete = await _TargetSavingrepository.GetByIdAsync(request.Id);
			if (savingToDelete == null)
			{
				throw new NotFoundException(nameof(TargetSaving), request.Id);
			}

			await _TargetSavingrepository.DeleteAsync(savingToDelete);

			return request.Id;

		}
	}
}
