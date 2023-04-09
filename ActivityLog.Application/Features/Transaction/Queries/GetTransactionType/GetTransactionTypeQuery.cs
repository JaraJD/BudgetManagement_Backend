using ActivityLog.Application.Features.Transaction.Queries.Common;
using MediatR;

namespace ActivityLog.Application.Features.Transaction.Queries.GetTransactionType
{
	public class GetTransactionTypeQuery : IRequest<List<TransactionVm>>
	{
		public string _UserId { get; set; } = string.Empty;

		public string _Type { get; set; } = string.Empty;

		public GetTransactionTypeQuery(string userId, string type)
		{
			_UserId = userId ?? throw new ArgumentNullException(nameof(userId));
			_Type = type ?? throw new ArgumentNullException(nameof(type));
		}
	}
}
