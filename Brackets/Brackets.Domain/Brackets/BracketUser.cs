using Brackets.Domain.Tournaments;
using Brackets.Domain.Users;

namespace Brackets.Domain.Brackets;

public record BracketUser : IStringIdentifiable
{
	public BracketUser() { }

	public string Id { get; init; } = null!;
	public AppUser AppUser { get; init; } = null!;

	public IList<Bracket> Brackets { get; set; } = [];

	public Bracket? GetCupBracket(string cupId)
	{
		return Brackets?.FirstOrDefault(b => b.Tournament.Id == cupId);
	}
}
