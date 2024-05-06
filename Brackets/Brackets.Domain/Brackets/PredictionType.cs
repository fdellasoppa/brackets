namespace Brackets.Domain.Brackets;

public record PredictionType : IStringIdentifiable
{
    internal const string DEFAULT_TRANSLATION_LANGUAGE = "en";

    //[Obsolete("Database collection should have translations for each type")]
    //private static readonly Dictionary<string, string[]> translations 
    //    = new()
    //{
    //    {"es", new string[] { "Goleador","Equipo Goleador", "Most Assists",
    //        "Mejor Jugador", "Mejor Arquero", "Equipo Fair Play", "Equipo Valla Menos Vencida"} },
    //    {"en", new string[] { "Top Scorer", "Top Scorering Team", "Most Assists",
    //        "Best Player", "Best Goalkepper", "Fair Play Team", "Less Scored Against Team" } }
    //};

    public string Id { get; init; } = null!;
    public int Points { get; init; }
    public Dictionary<string, string> Names { get; init; } = [];

    public string GetName(string? langCode)
    {
        return langCode is null ?
            Names[DEFAULT_TRANSLATION_LANGUAGE]
            : Names[langCode];
    }
}
