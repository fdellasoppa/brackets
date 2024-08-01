using Brackets.Application.Abstractions;
using Brackets.Domain.Matches;
using MediatR;

namespace Brackets.API.Matches;

public class GetMatchesRequest : IRequest<Result<IList<Match>>>
{
    public string TournamentId { get; set; } = string.Empty;
}