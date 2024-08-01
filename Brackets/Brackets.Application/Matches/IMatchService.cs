using Brackets.Application.Abstractions;
using Brackets.Domain.Matches;

namespace Brackets.Application.Matches;

public interface IMatchService
{
	Task<Result<IList<Match>>> GetAllAsync(string tournamentId, CancellationToken cancel);
}
