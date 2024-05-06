
using Brackets.Application.Matches;
using Brackets.Application.Tournaments;
using Brackets.Infrastructure.Matches;
using Brackets.Infrastructure.Tournaments;
using Microsoft.Extensions.DependencyInjection;

namespace Brackets.Infrastructure.Configuration;

public static class RepositoryMapper
{
	private readonly static ICollection<IMongoMapper> mappers = [
		new MatchMapper(),
		new TournamentMapper(),
	];

	public static void ConfigRepositories(this IServiceCollection services)
	{
		services.AddTransient<IMatchRepository, MatchRepository>();
		services.AddTransient<ITournamentRepository, TournamentRepository>();

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
