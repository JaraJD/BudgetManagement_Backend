using ActivityLog.Application.Features.Transaction.Queries.Common;
using MediatR;

namespace ActivityLog.Application.Features.Transaction.Queries.GetTransactionCategory
{
	public class GetTransactionCategoryQuery : IRequest<List<TransactionVm>>
	{
		public string _UserId { get; set; } = string.Empty;

		public int _CategoryId { get; set; }

		public GetTransactionCategoryQuery(string userId, int categoryId)
		{
			_UserId = userId ?? throw new ArgumentNullException(nameof(userId));
			_CategoryId = categoryId;
		}
	}
}
