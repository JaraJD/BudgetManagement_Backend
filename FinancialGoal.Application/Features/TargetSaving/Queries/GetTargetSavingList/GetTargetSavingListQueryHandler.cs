using AutoMapper;
using FinancialGoal.Application.Contracts.Persistence;
using FinancialGoal.Application.Features.TargetSaving.Queries.Common;
using MediatR;

namespace FinancialGoal.Application.Features.TargetSaving.Queries.GetTargetSavingList
{
    public class GetTargetSavingListQueryHandler : IRequestHandler<GetTargetSavingListQuery, List<TargetSavingVm>>
	{
		private readonly ITargetSavingRepository _targetSavingRepository;
		private readonly IMapper _mapper;

		public GetTargetSavingListQueryHandler(ITargetSavingRepository targetSavingRepository, IMapper mapper)
		{
			_targetSavingRepository = targetSavingRepository;
			_mapper = mapper;
		}

		public async Task<List<TargetSavingVm>> Handle(GetTargetSavingListQuery request, CancellationToken cancellationToken)
		{
			var savingList = await _targetSavingRepository.GetTargetSavingByState(request._IdUser, request._State);
			
			return _mapper.Map<List<TargetSavingVm>>(savingList);
		}
	}
}
