using LanguageCode = System.String;
using CountryLang = System.String;

namespace Brackets.Domain.Matches;

public record Team(TeamId Id, 
    string Name, Country 
    Country, 
    IDictionary<LanguageCode, CountryLang> CountryLangs) 
{
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

};
