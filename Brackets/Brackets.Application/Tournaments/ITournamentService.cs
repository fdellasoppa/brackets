using Brackets.Application.Abstractions;
using Brackets.Domain.Tournaments;

namespace Brackets.Application.Tournaments;

public interface ITournamentService
{
	Task<Result<List<Tournament>>> GetAllAsync(CancellationToken cancel);
}
