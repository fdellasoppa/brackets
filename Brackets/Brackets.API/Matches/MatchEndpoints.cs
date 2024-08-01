using Brackets.API.Errors;
using Brackets.Domain.Matches;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace Brackets.API.Matches;

public static class MatchEndpoints
{
    [Authorize]
    public static void MapMatchEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("matches",
            [SwaggerResponse(200, Type = typeof(IList<Match>))]
            async (
            GetMatchesRequest request,
            IMediator mediator,
            CancellationToken cancel) => {
                return (await mediator.Send(request))
                    .HandleResult();
            })
			.WithOpenApi();
	}
}
