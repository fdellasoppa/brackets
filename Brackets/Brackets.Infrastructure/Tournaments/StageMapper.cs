using Brackets.Domain.Tournaments;
using Brackets.Infrastructure.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Brackets.Infrastructure.Tournaments;

internal sealed class StageMapper : IMongoMapper
{
	public void Map()
	{
		BsonClassMap.RegisterClassMap<Stage>(cm => {
			cm.MapIdProperty(p => p.Id)
				.SetIdGenerator(StringObjectIdGenerator.Instance)
				.SetSerializer(new StringSerializer(BsonType.ObjectId));

			cm.MapProperty(p => p.Names).SetElementName("names");

			cm.MapProperty(p => p.Order).SetElementName("order");
		});
	}
}
