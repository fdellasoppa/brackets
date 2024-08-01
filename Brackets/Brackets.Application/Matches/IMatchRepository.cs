using Brackets.Domain.Matches;

namespace Brackets.Application.Matches;

public interface IMatchRepository
{
	Task<List<Match>> GetAllAsync(string tournamentId, CancellationToken cancel);
}
