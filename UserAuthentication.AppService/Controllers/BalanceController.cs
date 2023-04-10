using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using UserAuthentication.Entities.Entities;
using UserAuthentication.Entities.Features.Balance.Commands;
using UserAuthentication.Entities.Features.Balance.Queries;
using UserAuthentication.UseCase.Gateway.Repository;

namespace UserAuthentication.AppService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BalanceController : ControllerBase
	{
		private readonly IBalanceRepository _balanceRepository;
		private readonly IMapper _mapper;

		public BalanceController(IBalanceRepository balanceRepository, IMapper mapper)
		{
			_balanceRepository = balanceRepository;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<string> CreateBalance([FromBody] CreateBalanceCommand command)
		{
			return await _balanceRepository.CreateBalanceAsync(command);
		}

		[HttpPut("UpdateBalance")]
		public async Task<string> UpdateBalance([FromBody] UpdateBalanceCommand command)
		{
			return await _balanceRepository.UpdateBalanceAsync(command);
		}

		[HttpDelete("DeleteBalance")]
		public async Task<string> DeleteBalance(DeleteBalanceCommand command)
		{
			return await _balanceRepository.DeleteBalanceAsync(command);
		}

		[HttpPut("ResetBalance")]
		public async Task<string> ResetBalance([FromBody] ResetBalanceCommand command)
		{
			return await _balanceRepository.ResetBalanceAsync(command);
		}

		[HttpPut("SetBalance")]
		public async Task<string> SetBalance([FromBody] SetBalanceCommand command)
		{
			return await _balanceRepository.SetBalanceAsync(command);
		}

		[HttpPut("DeductBalance")]
		public async Task<string> DeductBalance([FromBody] SetBalanceCommand command)
		{
			return await _balanceRepository.DeductBalanceAsync(command);
		}

		[HttpGet("GetBalanceUser/{id}")]
		public async Task<List<BalanceEntity>> GetBalanceByUserId(string id)
		{
			return await _balanceRepository.GetBalanceByUserAsync(id);
		}
	}
}
