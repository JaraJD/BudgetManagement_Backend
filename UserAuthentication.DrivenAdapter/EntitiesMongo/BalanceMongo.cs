using MongoDB.Bson.Serialization.Attributes;

namespace UserAuthentication.DrivenAdapter.EntitiesMongo
{
	public class BalanceMongo
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string BalanceId { get; set; }

		public string UserId { get; set; }

		public string? Name { set; get; }

		public decimal Amount { get; set; }

		public bool IsDeleted { get; set; }
	}
}
