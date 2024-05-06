
namespace Brackets.Domain.Matches;

public record Team(TeamId Id,
	Dictionary<string, string> Names,
	string ImageName);
