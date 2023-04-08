using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLog.Application.Features.Budget.Commands.DeleteBudget
{
	public class DeleteBudgetCommand : IRequest<string>
	{
		public int Id { get; set; }
	}
}
