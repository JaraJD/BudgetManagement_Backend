using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthentication.Entities.Entities
{
	public class UserEntity
	{
		public string UserId { get; set; }

		public string? Name { get; set; }

		public string? Email { get; set; }

		public string? FireBaseId { get; set; }

		public bool IsDeleted { get; set; }

		public virtual BalanceEntity? Balance { get; set; }
	}
}
