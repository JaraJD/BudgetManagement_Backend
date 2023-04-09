using ActivityLog.Application.Features.Budget.Commands.CreateBudget;
using ActivityLog.Application.Features.Budget.Commands.DeleteBudget;
using ActivityLog.Application.Features.Budget.Commands.SetTotalBudget;
using ActivityLog.Application.Features.Budget.Commands.UpdateBudget;
using ActivityLog.Application.Features.Budget.Queries.Common;
using ActivityLog.Application.Features.Budget.Queries.GetBudgetDate;
using ActivityLog.Application.Features.Budget.Queries.GetBudgetName;
using ActivityLog.Application.Features.Budget.Queries.GetBudgetState;
using ActivityLog.Application.Features.Budget.Queries.GetBudgetUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ActivityLog.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BudgetController : ControllerBase
	{
		private readonly IMediator _mediator;

		public BudgetController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost(Name = "CreateBudget")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<string>> CreateBudget([FromBody] CreateBudgetCommand command)
		{
			return await _mediator.Send(command);
		}

		[HttpDelete("Delete/{id}", Name = "DeleteBudget")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<string>> DeleteBudget(int id)
		{
			var command = new DeleteBudgetCommand
			{
				Id = id
			};
			return await _mediator.Send(command);
		}

		[HttpPut(Name = "UpdateBudget")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<string>> UpdateBudget([FromBody] UpdateBudgetCommand command)
		{
			return await _mediator.Send(command);
		}


		[HttpGet("Dates/{idUser}/{date}", Name = "GetBudgetDate")]
		[ProducesResponseType(typeof(IEnumerable<BudgetVm>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<BudgetVm>>> GetBudgetByDate(string idUser, DateTime date)
		{
			var query = new GetBudgetDateQuery(idUser, date);
			var savings = await _mediator.Send(query);
			return Ok(savings);
		}


		[HttpGet("Name/{idUser}/{name}", Name = "GetBudgetName")]
		[ProducesResponseType(typeof(IEnumerable<BudgetVm>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<BudgetVm>>> GetBudgetByName(string idUser, string name)
		{
			var query = new GetBudgetNameQuery(idUser, name);
			var savings = await _mediator.Send(query);
			return Ok(savings);
		}


		[HttpGet("State/{idUser}/{state}", Name = "GetBudgetState")]
		[ProducesResponseType(typeof(IEnumerable<BudgetVm>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<BudgetVm>>> GetBudgetBystate(string idUser, string state)
		{
			var query = new GetBudgetStateQuery(idUser, state);
			var savings = await _mediator.Send(query);
			return Ok(savings);
		}


		[HttpGet("{idUser}", Name = "GetBudgetUser")]
		[ProducesResponseType(typeof(IEnumerable<BudgetVm>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<BudgetVm>>> GetBudgetByUser(string idUser)
		{
			var query = new GetBudgetUserQuery(idUser);
			var savings = await _mediator.Send(query);
			return Ok(savings);
		}

		[HttpPut("SetTotalMonthly", Name = "SetMonthlyTotalBudget")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<string>> SetMonthlyTotal([FromBody] SetTotalBudgetCommand command)
		{
			return await _mediator.Send(command);
		}
	}
}
