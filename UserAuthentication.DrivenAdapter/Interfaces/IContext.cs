using MongoDB.Driver;
using UserAuthentication.DrivenAdapter.EntitiesMongo;

namespace UserAuthentication.DrivenAdapter.Interfaces
{
	public interface IContext
	{
		public IMongoCollection<UserMongo> User { get; }
		public IMongoCollection<BalanceMongo> Balance { get; }
	}
}
