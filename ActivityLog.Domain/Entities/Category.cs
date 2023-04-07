using ActivityLog.Domain.Entities.Common;

namespace ActivityLog.Domain.Entities
{
	public class Category : BaseDomainModel
	{
		public string? Name { get; set; }

		public string? Priority { get; set; }
	}
}
