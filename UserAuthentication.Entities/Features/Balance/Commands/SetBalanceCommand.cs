

namespace UserAuthentication.Entities.Features.Balance.Commands
{
	public class SetBalanceCommand
	{
		public string UserId { get; set; }

		public decimal Value { get; set; }
	}
}
