using MongoDB.Bson.Serialization.Attributes;

namespace UserAuthentication.DrivenAdapter.EntitiesMongo
{
	public class UserMongo
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string UserId { get; set; }

		public string? Name { get; set; }

		public string? Email { get; set; }

		public string? FireBaseId { get; set; }

		public bool IsDeleted { get; set; }
	}
}
