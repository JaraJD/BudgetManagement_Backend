using ActivityLog.Application.Features.Transaction.Queries.Common;
using MediatR;

namespace ActivityLog.Application.Features.Transaction.Queries.GetTransactionDate
{
	public class GetTransactionDateQuery : IRequest<List<TransactionVm>>
	{
		public string _UserId { get; set; } = string.Empty;

		public DateTime _Date { get; set; }

		public GetTransactionDateQuery(string userId, DateTime date)
		{
			_UserId = userId ?? throw new ArgumentNullException(nameof(userId));
			_Date = date;
		}
	}
}
