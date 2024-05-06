using Brackets.Application.Abstractions;
using Brackets.Domain.Tournaments;

namespace Brackets.Application.Tournaments;

public class TournamentService : ITournamentService
{
	private readonly ITournamentRepository _tournamentRepository;

	public TournamentService(ITournamentRepository tournamentRepository)
	{
		_tournamentRepository = tournamentRepository;
	}

	public async Task<Result<List<Tournament>>> GetAllAsync(CancellationToken cancel)
	{
		var res = await _tournamentRepository.GetAllAsync(cancel);
		return Result<List<Tournament>>.Success(res);
	}
}