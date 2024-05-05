
using Brackets.Application.Matches;
using Brackets.Infrastructure.Configuration.Mappers;
using Brackets.Infrastructure.Matches;
using Microsoft.Extensions.DependencyInjection;

namespace Brackets.Infrastructure.Configuration;

public static class RepositoryMapper
{
	private readonly static ICollection<IMongoMapper> mappers = [
		new MatchMapper()
	];

	public static void ConfigRepositories(this IServiceCollection services)
	{
		services.AddTransient<IMatchRepository, MatchRepository>();

		MapCollections();
	}

	private static void MapCollections()
	{
		foreach (var mapper in mappers)
		{
			mapper.Map();
		}
	}
}
