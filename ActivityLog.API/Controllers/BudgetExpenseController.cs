using ActivityLog.Application.Features.Budget.Commands.SetTotalBudget;
using ActivityLog.Application.Features.BudgetExpense.Commands.CreateBudgetExpense;
using ActivityLog.Application.Features.BudgetExpense.Commands.DeleteBudgetExpense;
using ActivityLog.Application.Features.BudgetExpense.Commands.UpdateBudgetExpense;
using ActivityLog.Application.Features.BudgetExpense.Queries.Common;
using ActivityLog.Application.Features.BudgetExpense.Queries.GetBudgetExpenseBudget;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ActivityLog.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BudgetExpenseController : ControllerBase
	{
		private readonly IMediator _mediator;

		public BudgetExpenseController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost(Name = "CreateBudgetExpense")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<string>> CreateBudgetExpense([FromBody] CreateBudgetExpenseCommand command)
		{
			return await _mediator.Send(command);
		}

		[HttpDelete("{id}", Name = "DeleteBudgetExpense")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<string>> DeleteBudgetExpense(int id)
		{
			var command = new DeleteBudgetExpenseCommand
			{
				Id = id
			};
			return await _mediator.Send(command);
		}

		[HttpPut(Name = "UpdateBudgetExpense")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<string>> UpdateBudgetExpense([FromBody] UpdateBudgetExpenseCommand command)
		{
			return await _mediator.Send(command);
		}

		[HttpGet("{budgetId}", Name = "GetBudgetExpenseBudget")]
		[ProducesResponseType(typeof(IEnumerable<BudgetExpenseVm>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<BudgetExpenseVm>>> GetBudgetExpenseByBudget(int budgetId)
		{
			var query = new GetBudgetExpenseBudgetQuery(budgetId);
			var savings = await _mediator.Send(query);
			return Ok(savings);
		}

		
	}
}
