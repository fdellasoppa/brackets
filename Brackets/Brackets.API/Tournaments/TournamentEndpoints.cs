using Brackets.API.Errors;
using Brackets.Application.Abstractions;
using Brackets.Application.Tournaments;
using Brackets.Domain.Tournaments;
using Swashbuckle.AspNetCore.Annotations;

namespace Brackets.API.Tournaments;

public static class TournamentEndpoints
{
    public static void MapTournamentEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("tournaments",
            [SwaggerResponse(200, Type = typeof(List<Tournament>))]
            async (
            ITournamentService tournamentService,
            CancellationToken cancel) => {
                Result<List<Tournament>> result = await tournamentService.GetAllAsync(cancel);
                return result.IsSuccess ? 
                    TypedResults.Ok(result.Value) 
                    : result.ToProblemDetails();
            })
			.WithOpenApi();
	}
}
