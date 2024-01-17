﻿namespace Brackets.Domain.Tournament;

public record Stage
{
    public const int NUMBER_GROUPS = 10;
    public const int ELIMINATION_ID_START = 100;
    public const int ELIMINATION_ID_END = 104;

    private static readonly Dictionary<string, string[]> Translations = new Dictionary<string, string[]>()
    {
        {"es", new string[] {"Grupo", "Octavos", "Cuartos", "Semifinal", "Final", "Tercer Lugar", "Otros"} },
        {"en", new string[] {"Group", "RoundOf16", "Quarter", "Semifinal", "Final", "Third Place", "Others"} }
    };

    public Stage() { }

    public virtual long Id { get; set; }
    //public virtual int Order { get; set; } // Use Id as order
    public virtual string Name { get; set; } = string.Empty;

    public virtual string GetName(string? lang)
    {
        var langIndex = lang is null || lang.StartsWith("en") ? "en" : "es";

        if (Id <= NUMBER_GROUPS)
        {
            // Fase de grupos
            return Translations[langIndex][0] + " " + Name;
        }
        else if (Id >= ELIMINATION_ID_START && Id <= ELIMINATION_ID_END)
        {
            // Eliminatorias
            return Translations[langIndex][Id - (ELIMINATION_ID_START - 1)];
        }
        else
        {
            // Otros partidos
            return Translations[langIndex][5];
        }
    }
}