using Brackets.Application.Matches;
using Brackets.Domain.Matches;
using Brackets.Infrastructure.Data;
using MongoDB.Driver;

namespace Brackets.Infrastructure.Matches;

public class MatchRepository : IMatchRepository
{
	private const string CollectionName = nameof(Match);

	private readonly IMongoDbContext _mongoDbContext;

	public MatchRepository(IMongoDbContext mongoDbContext) => 
		_mongoDbContext = mongoDbContext;

	public Task<List<Match>> GetAllAsync(CancellationToken cancel)
	{
		return _mongoDbContext.GetCollection<Match>(CollectionName)
			.Find(Builders<Match>.Filter.Empty).ToListAsync(cancel);
	}
}
