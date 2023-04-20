using ActivityLog.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System.Text.Json;

namespace ActivityLog.Application.Features.Transaction.Commands.UpdateTransaction
{
	public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, string>
	{
		private readonly ITransactionRepository _transactionRepository;
		private readonly IMapper _mapper;

		public UpdateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper)
		{
			_transactionRepository = transactionRepository;
			_mapper = mapper;
		}

		public async Task<string> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
		{
			var transactionToUpdate = await _transactionRepository.GetByIdAsync(request.Id);
			if (transactionToUpdate == null)
			{
				throw new ArgumentException(nameof(request));
			}
			_mapper.Map(request, transactionToUpdate, typeof(UpdateTransactionCommand), typeof(Domain.Entities.Transaction));

			await _transactionRepository.UpdateAsync(transactionToUpdate);

			return JsonSerializer.Serialize($"Transaction {request.Id} Updated");
		}
	}
}
