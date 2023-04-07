using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLog.Domain.Entities.Common
{
	public class BaseDomainModel
	{
		public int Id { get; set; }

		public Boolean IsDeleted { get; set; }
	}
}
