using Brackets.Domain.Matches;

namespace Brackets.Domain.Tournaments;

public class Tournament : IIdentifiable
{
    public Tournament() { }

    public string Id { get; init; } = null!;

    public string Name { get; init; } = string.Empty;
    public int Year { get; init; }
    public DateTime StartDate { get; init; }

	public IList<Stage> Stages { get; init; } = [];
	public IList<Match> Matches { get; init; } = [];

    /// <summary>
    /// Number of matches played so far, used for caching results.
    /// </summary>
    public int LastScoresCalculation { get; set; }
    public bool IsBeingUpdated { get; set; } = false;

    public bool AreScoresUpdated =>
        Matches.Count(m => m.IsMatchPlayed) == LastScoresCalculation;

}
