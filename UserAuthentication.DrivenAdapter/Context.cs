using MongoDB.Driver;
using UserAuthentication.DrivenAdapter.EntitiesMongo;
using UserAuthentication.DrivenAdapter.Interfaces;

namespace UserAuthentication.DrivenAdapter
{
	public class Context : IContext
	{
		private readonly IMongoDatabase _database;

		public Context(string stringConnection, string DBname)
		{
			MongoClient client = new MongoClient(stringConnection);
			_database = client.GetDatabase(DBname);
		}

		public IMongoCollection<UserMongo> User => _database.GetCollection<UserMongo>("user");

		public IMongoCollection<BalanceMongo> Balance => _database.GetCollection<BalanceMongo>("balance");

	}
}
