using Brackets.Application.Tournaments;
using Brackets.Domain.Tournaments;
using Brackets.Infrastructure.Data;
using MongoDB.Driver;

namespace Brackets.Infrastructure.Tournaments;

public class TournamentRepository : ITournamentRepository
{
	private const string CollectionName = "tournaments";

	private readonly IMongoDbContext _mongoDbContext;

	public TournamentRepository(IMongoDbContext mongoDbContext) => 
		_mongoDbContext = mongoDbContext;

	public Task<List<Tournament>> GetAllAsync(CancellationToken cancel)
	{
		return _mongoDbContext.GetCollection<Tournament>(CollectionName)
			.Find(Builders<Tournament>.Filter.Empty).ToListAsync(cancel);
	}
}
