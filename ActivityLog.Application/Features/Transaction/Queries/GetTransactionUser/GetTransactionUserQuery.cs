using ActivityLog.Application.Features.Transaction.Queries.Common;
using MediatR;

namespace ActivityLog.Application.Features.Transaction.Queries.GetTransactionUser
{
    public class GetTransactionUserQuery : IRequest<List<TransactionVm>>
    {
        public string _UserId { get; set; } = string.Empty;

        public GetTransactionUserQuery(string userId)
        {
            _UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        }
    }
}
