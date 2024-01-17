using LanguageCode = System.String;
using CountryLang = System.String;


namespace Brackets.Domain.Matches;

public record Team : IIdentifiable
{
    public Team() { }

    public long? Id { get; init; }
    protected string Name { get; init; } = string.Empty;
    public Country Country { get; init; } = default!;
    public IDictionary<LanguageCode, CountryLang> CountryLangs { get; init; } = default!;

    /// <summary>
    /// Gets the name of the country according to the language. English is the default.
    /// </summary>
    public string GetName(string? lang)
    {
        if (Country == null)
            return Name;

        return lang is null || lang.StartsWith("en") ? 
            Country.Name
            : CountryLangs[lang];
    }

    public string GetFlagCode()
    {
        return Country != null ? Country.FlagImageCode : string.Empty;
    }

}
