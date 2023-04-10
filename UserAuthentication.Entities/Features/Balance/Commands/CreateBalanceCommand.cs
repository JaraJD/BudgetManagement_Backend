

namespace UserAuthentication.Entities.Features.Balance.Commands
{
	public class CreateBalanceCommand
	{
		public string UserId { get; set; }
		public string? Name { set; get; }

		public decimal Amount { get; set; }
	}
}
