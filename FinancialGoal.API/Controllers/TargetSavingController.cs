using FinancialGoal.Application.Features.TargetSaving.Commands.CreateTargetSaving;
using FinancialGoal.Application.Features.TargetSaving.Commands.DeleteTargetSaving;
using FinancialGoal.Application.Features.TargetSaving.Commands.UpdateTargetSaving;
using FinancialGoal.Application.Features.TargetSaving.Queries.Common;
using FinancialGoal.Application.Features.TargetSaving.Queries.GetTargetSavingList;
using FinancialGoal.Application.Features.TargetSaving.Queries.GetTargetSavingUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FinancialGoal.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class TargetSavingController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TargetSavingController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost(Name = "CreateTargetSaving")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<int>> CreateTargetSaving([FromBody] CreateTargetSavingCommand command)
		{
			return await _mediator.Send(command);
		}

		[HttpGet("{idUser}/{state}", Name = "GetTargetSavingActive")]
		[ProducesResponseType(typeof(IEnumerable<TargetSavingVm>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<TargetSavingVm>>> GetTargetSavingByState(string idUser, string state)
		{
			var query = new GetTargetSavingListQuery(idUser, state);
			var savings =  await _mediator.Send(query);
			return Ok(savings);
		}

		[HttpGet("{idUser}", Name = "GetTargetSavingByUser")]
		[ProducesResponseType(typeof(IEnumerable<TargetSavingVm>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<TargetSavingVm>>> GetTargetSavingBySUser(string idUser)
		{
			var query = new GetTargetSavingUserQuery(idUser);
			var savings = await _mediator.Send(query);
			return Ok(savings);
		}

		[HttpPut(Name = "UpdateTargetSaving")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<int>> UpdateTargetSaving([FromBody] UpdateTargetSavingCommand command)
		{
			return await _mediator.Send(command);
		}

		[HttpDelete("{id}", Name = "DeleteTargetSaving")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<int>> DeleteTargetSaving(int id)
		{
			var command = new DeleteTargetSavingCommand
			{
				Id = id
			};
			return await _mediator.Send(command);
		}
	}
}
