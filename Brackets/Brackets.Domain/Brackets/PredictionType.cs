namespace Brackets.Domain.Brackets;

public record PredictionType : IIdentifiable
{
    private static readonly Dictionary<string, string[]> translations 
        = new()
    {
        {"es", new string[] { "Goleador","Equipo Goleador", "Most Assists",
            "Mejor Jugador", "Mejor Arquero", "Equipo Fair Play", "Equipo Valla Menos Vencida"} },
        {"en", new string[] { "Top Scorer", "Top Scorering Team", "Most Assists",
            "Best Player", "Best Goalkepper", "Fair Play Team", "Less Scored Against Team" } }
    };

    public PredictionType() { }

    public long? Id { get; init; }
    public int Points { get; init; }

    public string GetName(string? lang)
    {
        return lang is null || lang.StartsWith("en") ?
            translations["en"][(int)(Id! - 1)]
            : translations["es"][(int)(Id! - 1)];
    }
}
