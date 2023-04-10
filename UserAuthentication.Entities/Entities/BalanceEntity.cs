using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthentication.Entities.Entities
{
	public class BalanceEntity
	{
		public string BalanceId { get; set; }

		public string UserId { get; set; }

		public string? Name { set; get; }

		public decimal Amount { get; set; }
	}
}
