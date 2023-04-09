using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Application.Features.Transaction.Queries.Common;
using AutoMapper;
using MediatR;

namespace ActivityLog.Application.Features.Transaction.Queries.GetTransactionCategory
{
	public class GetTransactionCategoryQueryHandler : IRequestHandler<GetTransactionCategoryQuery, List<TransactionVm>>
	{
		private readonly ITransactionRepository _transactionRepository;
		private readonly IMapper _mapper;

		public GetTransactionCategoryQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
		{
			_transactionRepository = transactionRepository;
			_mapper = mapper;
		}

		public async Task<List<TransactionVm>> Handle(GetTransactionCategoryQuery request, CancellationToken cancellationToken)
		{
			var transactionList = await _transactionRepository.GetTransactionByCategory(request._UserId, request._CategoryId);

			return _mapper.Map<List<TransactionVm>>(transactionList);
		}
	}
}
