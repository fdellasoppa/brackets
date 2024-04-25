
using Brackets.Application.Matches;
using Brackets.Infrastructure.Matches;
using Microsoft.Extensions.DependencyInjection;

namespace Brackets.Infrastructure.Configuration;

public static class RepositoryMapper
{
	public static void MapRepositories(this IServiceCollection services)
	{
		services.AddTransient<IMatchRepository, MatchRepository>();
	}
}
