namespace Brackets.Domain.Tournaments;


public enum MatchResult
{
	None = 0,
	Local,
	Tie,
	Away
}

public static class MatchResultExtensions
{
	private static Dictionary<string, string[]> translations = new()
	{
		{"es", new string [] {string.Empty, "Local", "Empate", "Visitante"} },
		{"en", new string [] {string.Empty, "Local", "Tie", "Away"} }
	};

	public static string ToString(this MatchResult result, string lang)
	{
		return lang.StartsWith("es") ?
			translations["es"][(int)result]
			: translations["en"][(int)result];
	}
}