using Brackets.Application.Matches;
using Microsoft.Extensions.DependencyInjection;

namespace Brackets.Application.Configuration;

public static class ServiceMapper
{
	public static void ConfigServices(this IServiceCollection services)
	{
		services.AddTransient<IMatchService, MatchService>();
	}
}
