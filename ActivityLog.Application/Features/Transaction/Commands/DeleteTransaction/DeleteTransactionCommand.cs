using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLog.Application.Features.Transaction.Commands.DeleteTransaction
{
	public class DeleteTransactionCommand : IRequest<string>
	{
		public int Id { get; set; }
	}
}
