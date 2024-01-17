using Brackets.Domain.Users;

namespace Brackets.Domain.Brackets;

public record BracketUser : IIdentifiable
{
	public BracketUser() { }

	public long? Id { get; init; }
	public AppUser AppUser { get; init; } = null!;

	public IList<Bracket> Brackets { get; set; } = new List<Bracket>();

	public Bracket? GetCupBracket(long cupId)
	{
		return Brackets?.FirstOrDefault(b => b.Tournament.Id == cupId);
	}
}
