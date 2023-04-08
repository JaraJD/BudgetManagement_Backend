using ActivityLog.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace ActivityLog.Application.Features.Transaction.Commands.CreateTransaction
{
	public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, string>
	{ 
		private readonly ITransactionRepository _transactionRepository;
		private readonly IMapper _mapper;

		public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper)
		{
			_transactionRepository = transactionRepository;
			_mapper = mapper;
		}

		public async Task<string> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
		{
			var transactionToCreate = _mapper.Map<Domain.Entities.Transaction>(request);
			var result = await _transactionRepository.CreateAsync(transactionToCreate);

			return $"Transaction {result.Id} created";
		}
	}
}
