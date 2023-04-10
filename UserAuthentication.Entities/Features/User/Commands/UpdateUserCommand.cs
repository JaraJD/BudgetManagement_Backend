using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuthentication.Entities.Entities;

namespace UserAuthentication.Entities.Features.User.Commands
{
	public class UpdateUserCommand
	{
		public string UserId { get; set; }

		public string? Name { get; set; }

		public string? Email { get; set; }
	}
}
