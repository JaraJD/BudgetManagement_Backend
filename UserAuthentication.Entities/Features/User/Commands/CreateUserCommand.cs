using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuthentication.Entities.Entities;

namespace UserAuthentication.Entities.Features.User.Commands
{
	public class CreateUserCommand
	{

		public string? Name { get; set; }

		public string? Email { get; set; }

		public string? FireBaseId { get; set; }
	}
}
