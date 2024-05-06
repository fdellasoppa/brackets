using MongoDB.Bson.Serialization;
using Brackets.Domain;

namespace Brackets.Infrastructure.Configuration;

internal sealed class StringTranslationsMapper : IMongoMapper
{
	public void Map()
	{
		BsonClassMap.RegisterClassMap<StringTranslations>(cm =>
		{
			cm.MapProperty(p => p.Translations).SetElementName("translations");
		});
	}
}
