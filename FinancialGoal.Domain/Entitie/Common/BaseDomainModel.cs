

namespace FinancialGoal.Domain.Entitie.Common
{
	public abstract class BaseDomainModel
	{
		public int Id { get; set; }

		public Boolean IsDeleted { get; set; }
	}
}
