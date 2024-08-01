using Brackets.Application.Matches;
using Brackets.Domain.Matches;
using Brackets.Infrastructure.Data;
using MongoDB.Driver;

namespace Brackets.Infrastructure.Matches;

public class MatchRepository : IMatchRepository
{
	private const string CollectionName = "matches";

	private readonly IMongoDbContext _mongoDbContext;

	public MatchRepository(IMongoDbContext mongoDbContext) => 
		_mongoDbContext = mongoDbContext;

	public Task<List<Match>> GetAllAsync(string tournamentId, 
		CancellationToken cancel)
	{
		return _mongoDbContext.GetCollection<Match>(CollectionName)
			.Find(m => m.Tournament.Id == tournamentId).ToListAsync(cancel);
	}
}
