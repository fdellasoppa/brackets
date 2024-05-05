namespace Brackets.Domain.Tournament;

public record Stage : IIdentifiable
{
    public const int NUMBER_GROUPS = 10;
    public const int ELIMINATION_ID_START = 100;
    public const int ELIMINATION_ID_END = 104;

	//[Obsolete("Database collection should have translations for each type")]
	//private static readonly Dictionary<string, string[]> Translations = new Dictionary<string, string[]>()
 //   {
 //       {"es", new string[] {"Grupos", "Octavos", "Cuartos", "Semifinal", "Final", "Tercer Lugar", "Otros"} },
 //       {"en", new string[] {"Groups", "RoundOf16", "Quarter", "Semifinal", "Final", "Third Place", "Others"} }
 //   };

    public Stage() { }

    public string Id { get; init; } = null!;
    public int Order { get; init; }
    public Dictionary<string, string> Names { get; init; } = [];

	public string GetName(string? lang)
    {
        var langIndex = lang ?? "en";

        return Names.TryGetValue(langIndex, out string? value) ? 
            value 
            : "Other";
    }
}