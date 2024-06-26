﻿using Brackets.Domain.Tournaments;
using Brackets.Infrastructure.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Brackets.Infrastructure.Tournaments;

internal sealed class TournamentMapper : IMongoMapper
{
	public void Map()
	{
		BsonClassMap.RegisterClassMap<Tournament>(cm => {
			cm.MapIdProperty(p => p.Id)
				.SetIdGenerator(StringObjectIdGenerator.Instance)
				.SetSerializer(new StringSerializer(BsonType.ObjectId));

			cm.MapProperty(p => p.Names).SetElementName("names");

			cm.MapProperty(p => p.Year).SetElementName("year");
			cm.MapProperty(p => p.LastScoresCalculation)
				.SetElementName("lastScoresCalculation");
			cm.MapProperty(p => p.StartDate).SetElementName("startDate");

			cm.MapProperty(p => p.Stages).SetElementName("stages");
			cm.MapProperty(p => p.Matches).SetElementName("matches");

			cm.SetIgnoreExtraElements(true);
		});
	}
}
