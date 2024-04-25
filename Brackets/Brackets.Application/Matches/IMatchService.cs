using Brackets.Application.Abstractions;
using Brackets.Domain.Matches;

namespace Brackets.Application.Matches;

public interface IMatchService
{
	Task<Result<List<Match>>> GetAllAsync(CancellationToken cancel);
}
