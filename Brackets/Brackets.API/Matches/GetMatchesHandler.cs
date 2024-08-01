using Brackets.Application.Abstractions;
using Brackets.Application.Matches;
using Brackets.Domain.Matches;
using MediatR;

namespace Brackets.API.Matches;

public class GetMatchesHandler : IRequestHandler<GetMatchesRequest, Result<IList<Match>>>
{
    private IMatchService _matchService;

    public GetMatchesHandler(IMatchService matchService)
    {
        _matchService = matchService;
    }

    public Task<Result<IList<Match>>> Handle(GetMatchesRequest request, 
        CancellationToken cancellationToken)
    {
        return _matchService.GetAllAsync(request.TournamentId, cancellationToken);
    }
}
