using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Application.Features.Transaction.Queries.Common;
using AutoMapper;
using MediatR;

namespace ActivityLog.Application.Features.Transaction.Queries.GetTransactionDate
{
	public class GetTransactionDateQueryHandler : IRequestHandler<GetTransactionDateQuery, List<TransactionVm>>
	{
		private readonly ITransactionRepository _transactionRepository;
		private readonly IMapper _mapper;

		public GetTransactionDateQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
		{
			_transactionRepository = transactionRepository;
			_mapper = mapper;
		}

		public async Task<List<TransactionVm>> Handle(GetTransactionDateQuery request, CancellationToken cancellationToken)
		{
			var transactionList = await _transactionRepository.GetTransactionByDate(request._UserId, request._Date);

			return _mapper.Map<List<TransactionVm>>(transactionList);
		}
	}
}
