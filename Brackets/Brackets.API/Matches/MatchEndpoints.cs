using Brackets.API.Errors;
using Brackets.Application.Abstractions;
using Brackets.Application.Matches;
using Brackets.Domain.Matches;
using Swashbuckle.AspNetCore.Annotations;

namespace Brackets.API.Matches;

public static class MatchEndpoints
{
    public static void MapMatchEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("matches",
            [SwaggerResponse(200, Type = typeof(List<Match>))]
            async (
            IMatchService matchService,
            CancellationToken cancel) => {
                Result<List<Match>> result = await matchService.GetAllAsync(cancel);
                return result.IsSuccess ? 
                    TypedResults.Ok(result.Value) 
                    : result.ToProblemDetails();
            })
			.WithOpenApi();
	}
}
