using ActivityLog.Application.Features.Transaction.Commands.CreateTransaction;
using ActivityLog.Application.Features.Transaction.Commands.DeleteTransaction;
using ActivityLog.Application.Features.Transaction.Commands.UpdateTransaction;
using ActivityLog.Application.Features.Transaction.Queries.Common;
using ActivityLog.Application.Features.Transaction.Queries.GetTransactionCategory;
using ActivityLog.Application.Features.Transaction.Queries.GetTransactionDate;
using ActivityLog.Application.Features.Transaction.Queries.GetTransactionType;
using ActivityLog.Application.Features.Transaction.Queries.GetTransactionUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ActivityLog.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TransactionController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TransactionController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost(Name = "CreateTransaction")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<string>> CreateTransaction([FromBody] CreateTransactionCommand command)
		{
			return await _mediator.Send(command);
		}

		[HttpDelete("{id}", Name = "DeleteTransaction")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<string>> DeleteTransaction(int id)
		{
			var command = new DeleteTransactionCommand
			{
				Id = id
			};
			return await _mediator.Send(command);
		}

		[HttpPut(Name = "UpdateTransaction")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<string>> UpdateTransaction([FromBody] UpdateTransactionCommand command)
		{
			return await _mediator.Send(command);
		}

		[HttpGet("{idUser}/{category}", Name = "GetTransactionCategory")]
		[ProducesResponseType(typeof(IEnumerable<TransactionVm>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<TransactionVm>>> GetTransactionByCategory(string idUser, int category)
		{
			var query = new GetTransactionCategoryQuery(idUser, category);
			var savings = await _mediator.Send(query);
			return Ok(savings);
		}

		[HttpGet("{idUser}/{date}", Name = "GetTransactionDate")]
		[ProducesResponseType(typeof(IEnumerable<TransactionVm>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<TransactionVm>>> GetTransactionByDate(string idUser, DateTime date)
		{
			var query = new GetTransactionDateQuery(idUser, date);
			var savings = await _mediator.Send(query);
			return Ok(savings);
		}

		[HttpGet("{idUser}/{type}", Name = "GetTransactionType")]
		[ProducesResponseType(typeof(IEnumerable<TransactionVm>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<TransactionVm>>> GetTransactionByType(string idUser, string type)
		{
			var query = new GetTransactionTypeQuery(idUser, type);
			var savings = await _mediator.Send(query);
			return Ok(savings);
		}

		[HttpGet("{idUser}", Name = "GetTransactionUser")]
		[ProducesResponseType(typeof(IEnumerable<TransactionVm>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<TransactionVm>>> GetTransactionByUser(string idUser)
		{
			var query = new GetTransactionUserQuery(idUser);
			var savings = await _mediator.Send(query);
			return Ok(savings);
		}
	}
}
