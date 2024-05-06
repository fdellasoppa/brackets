using Brackets.Domain.Tournaments;

namespace Brackets.Application.Tournaments;

public interface ITournamentRepository
{
	Task<List<Tournament>> GetAllAsync(CancellationToken cancel);
}
