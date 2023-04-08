using ActivityLog.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace ActivityLog.Application.Features.Transaction.Commands.UpdateTransaction
{
	public class UpdateTransacionCommandHandler : IRequestHandler<UpdateTransacionCommand, string>
	{
		private readonly ITransactionRepository _transactionRepository;
		private readonly IMapper _mapper;

		public UpdateTransacionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper)
		{
			_transactionRepository = transactionRepository;
			_mapper = mapper;
		}

		public async Task<string> Handle(UpdateTransacionCommand request, CancellationToken cancellationToken)
		{
			var transactionToUpdate = await _transactionRepository.GetByIdAsync(request.Id);
			if (transactionToUpdate == null)
			{
				throw new ArgumentException(nameof(request));
			}
			_mapper.Map(request, transactionToUpdate, typeof(UpdateTransacionCommand), typeof(Domain.Entities.Transaction));

			await _transactionRepository.UpdateAsync(transactionToUpdate);

			return $"Transaction {request.Id} Updated";
		}
	}
}
