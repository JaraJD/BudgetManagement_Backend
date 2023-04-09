using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLog.Application.Features.Transaction.Commands.UpdateTransaction
{
	public class UpdateTransactionCommand : IRequest<string>
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }

		public string? Type { get; set; }

		public decimal Amount { get; set; }

		public string? Description { get; set; }

		public int CategoryId { get; set; }
	}
}
