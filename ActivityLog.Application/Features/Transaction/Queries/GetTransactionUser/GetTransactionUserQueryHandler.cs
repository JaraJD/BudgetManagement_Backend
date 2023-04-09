using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Application.Features.Transaction.Queries.Common;
using AutoMapper;
using MediatR;

namespace ActivityLog.Application.Features.Transaction.Queries.GetTransactionUser
{
	public class GetTransactionUserQueryHandler : IRequestHandler<GetTransactionUserQuery, List<TransactionVm>>
	{
		private readonly ITransactionRepository _transactionRepository;
		private readonly IMapper _mapper;

		public GetTransactionUserQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
		{
			_transactionRepository = transactionRepository;
			_mapper = mapper;
		}

		public async Task<List<TransactionVm>> Handle(GetTransactionUserQuery request, CancellationToken cancellationToken)
		{
			var transactionList = await _transactionRepository.GetTransactionByUser(request._UserId);

			return _mapper.Map<List<TransactionVm>>(transactionList);
		}
	}
}
