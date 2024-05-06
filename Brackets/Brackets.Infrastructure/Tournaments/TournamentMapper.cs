using Brackets.Domain.Tournaments;
using Brackets.Infrastructure.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Brackets.Infrastructure.Tournaments;

internal class TournamentMapper : IMongoMapper
{
	public void Map()
	{
		BsonClassMap.RegisterClassMap<Tournament>(cm => {
			cm.AutoMap();
			cm.MapIdProperty(c => c.Id)
				.SetIdGenerator(StringObjectIdGenerator.Instance)
				.SetSerializer(new StringSerializer(BsonType.ObjectId));
			cm.SetIgnoreExtraElements(true);
		});
	}
}
