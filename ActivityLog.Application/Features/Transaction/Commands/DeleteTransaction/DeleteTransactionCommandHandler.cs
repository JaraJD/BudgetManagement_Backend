using ActivityLog.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ActivityLog.Application.Features.Transaction.Commands.DeleteTransaction
{
	public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, string>
	{
		private readonly ITransactionRepository _transactionRepository;

		public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository)
		{
			_transactionRepository = transactionRepository;
		}

		public async Task<string> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
		{
			var transactionToDelete = await _transactionRepository.GetByIdAsync(request.Id);
			if (transactionToDelete == null)
			{
				throw new ArgumentNullException(nameof(transactionToDelete));
			}
			transactionToDelete.IsDeleted = true;
			await _transactionRepository.UpdateAsync(transactionToDelete);

			return JsonSerializer.Serialize($"Transaction {request.Id} Deleted");


		}
	}
}
