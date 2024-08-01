using Brackets.Application.Abstractions;
using Brackets.Domain.Matches;

namespace Brackets.Application.Matches;

public class MatchService : IMatchService
{
	private readonly IMatchRepository _matchRepository;

	public MatchService(IMatchRepository matchRepository)
	{
		_matchRepository = matchRepository;
	}

	public async Task<Result<IList<Match>>> GetAllAsync(string tournamentId, 
		CancellationToken cancel)
	{
		var res = await _matchRepository.GetAllAsync(tournamentId, cancel);
		return Result<IList<Match>>.Success(res);
	}
}
