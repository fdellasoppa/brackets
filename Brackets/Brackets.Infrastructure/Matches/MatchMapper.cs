using Brackets.Domain.Matches;
using Brackets.Infrastructure.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Brackets.Infrastructure.Matches;

internal sealed class MatchMapper : IMongoMapper
{
    public void Map()
    {
        BsonClassMap.RegisterClassMap<Match>(cm =>
        {
            cm.MapIdProperty(p => p.Id)
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.ObjectId));

            cm.MapProperty(p => p.MatchDate).SetElementName("matchDate");
            cm.MapProperty(p => p.LocalTeam).SetElementName("localTeam");
            cm.MapProperty(p => p.AwayTeam).SetElementName("awayTeam");

            cm.MapProperty(p => p.LocalGoals).SetElementName("result.localGoals");
            cm.MapProperty(p => p.AwayGoals).SetElementName("result.awayGoals");

            cm.SetIgnoreExtraElements(true);
        });
    }
}
