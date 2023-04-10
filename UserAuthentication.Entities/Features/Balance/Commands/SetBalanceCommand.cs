

namespace UserAuthentication.Entities.Features.Balance.Commands
{
	public class SetBalanceCommand
	{
		public string BalanceId { get; set; }

		public decimal Value { get; set; }
	}
}
