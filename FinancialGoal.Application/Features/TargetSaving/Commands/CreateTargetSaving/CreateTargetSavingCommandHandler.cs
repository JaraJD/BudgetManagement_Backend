using AutoMapper;
using FinancialGoal.Application.Contracts.Persistence;
using MediatR;

namespace FinancialGoal.Application.Features.TargetSaving.Commands.CreateTargetSaving
{
    public class CreateTargetSavingCommandHandler : IRequestHandler<CreateTargetSavingCommand, int>
    {
        private readonly ITargetSavingRepository _targetSavingRepository;
        private readonly IMapper _mapper;

        public CreateTargetSavingCommandHandler(ITargetSavingRepository targetSavingRepository, IMapper mapper)
        {
            _targetSavingRepository = targetSavingRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTargetSavingCommand request, CancellationToken cancellationToken)
        {
            var targetSavingEntity = _mapper.Map<Domain.Entitie.TargetSaving>(request);
            var newSaving = await _targetSavingRepository.CreateAsync(targetSavingEntity);

            return newSaving.Id;
        }
    }
}
