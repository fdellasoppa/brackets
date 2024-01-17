namespace Brackets.Domain.Tournament;

public record WorldCup : IIdentifiable
{
    public WorldCup() { }

    public long? Id { get; init; }

    public string Name { get; init; } = string.Empty;
    public int Year { get; init; }
    public DateTime StartDate { get; init; }

    public IList<TournamentMatch> Matches { get; init; } = new List<TournamentMatch>();

    /// <summary>
    /// Number of matches played so far, used for caching results.
    /// </summary>
    public int LastScoresCalculation { get; set; }
    public bool IsBeingUpdated { get; set; } = false;

    public bool AreScoresUpdated =>
        Matches.Count(m => m.IsMatchPlayed) == LastScoresCalculation;

}
