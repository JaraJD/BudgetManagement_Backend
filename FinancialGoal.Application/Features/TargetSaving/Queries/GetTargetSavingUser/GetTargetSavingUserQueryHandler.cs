using AutoMapper;
using FinancialGoal.Application.Contracts.Persistence;
using FinancialGoal.Application.Features.TargetSaving.Queries.Common;
using MediatR;

namespace FinancialGoal.Application.Features.TargetSaving.Queries.GetTargetSavingUser
{
    public class GetTargetSavingUserQueryHandler : IRequestHandler<GetTargetSavingUserQuery, List<TargetSavingVm>>
	{
		private readonly ITargetSavingRepository _targetSavingRepository;
		private readonly IMapper _mapper;

		public GetTargetSavingUserQueryHandler(ITargetSavingRepository targetSavingRepository, IMapper mapper)
		{
			_targetSavingRepository = targetSavingRepository;
			_mapper = mapper;
		}

		public async Task<List<TargetSavingVm>> Handle(GetTargetSavingUserQuery request, CancellationToken cancellationToken)
		{
			var savingList = await _targetSavingRepository.GetTargetSavingByUser(request._IdUser);

			return _mapper.Map<List<TargetSavingVm>>(savingList);
		}
	}
}
