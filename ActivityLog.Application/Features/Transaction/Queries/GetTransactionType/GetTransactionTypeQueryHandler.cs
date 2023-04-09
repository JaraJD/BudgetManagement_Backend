using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Application.Features.Transaction.Queries.Common;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLog.Application.Features.Transaction.Queries.GetTransactionType
{
	public class GetTransactionTypeQueryHandler : IRequestHandler<GetTransactionTypeQuery, List<TransactionVm>>
	{
		private readonly ITransactionRepository _transactionRepository;
		private readonly IMapper _mapper;

		public GetTransactionTypeQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
		{
			_transactionRepository = transactionRepository;
			_mapper = mapper;
		}

		public async Task<List<TransactionVm>> Handle(GetTransactionTypeQuery request, CancellationToken cancellationToken)
		{
			var transactionList = await _transactionRepository.GetTransactionByType(request._UserId, request._Type);

			return _mapper.Map<List<TransactionVm>>(transactionList);
		}
	}
}
