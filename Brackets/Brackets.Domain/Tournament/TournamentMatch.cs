using Brackets.Domain.Matches;

namespace Brackets.Domain.Tournament;

public record TournamentMatch : IGoals, IIdentifiable, IEquatable<TournamentMatch>
{
	public const int MATCH_LOCK_HOURS = 6;
	
	public TournamentMatch() { }

	public long? Id { get; init; }
	public Match Match { get; init; } = null!;
	public Stage Stage { get; init; } = null!;
	public WorldCup Cup { get; set; } = null!;
    public int? LocalGoals { get; set; }
	public int? AwayGoals { get; set; }
	public int? LocalPenalties { get; set; }
	public int? AwayPenalties { get; set; }

	public bool IsMatchLocked => IsMatchPlayed || DateTime.UtcNow.AddHours(MATCH_LOCK_HOURS) > Match.MatchDate;
	public bool IsMatchPlayed => LocalGoals != null && AwayGoals != null;

    public MatchResult Result() => CalculateResult(this);

    public static MatchResult CalculateResult(IGoals goals)
    {
		if (goals.LocalGoals == null || goals.AwayGoals == null)
			return MatchResult.None;

		if (goals.LocalGoals > goals.AwayGoals)
			return MatchResult.Local;
		if (goals.LocalGoals < goals.AwayGoals)
			return MatchResult.Away;

		if (goals.LocalGoals == goals.AwayGoals)
			if (goals.LocalPenalties == null || goals.AwayPenalties == null)
				return MatchResult.Tie;

		if (goals.LocalPenalties > goals.AwayPenalties)
			return MatchResult.Local;
		if (goals.AwayPenalties > goals.LocalPenalties)
			return MatchResult.Away;

		return MatchResult.Tie;
	}

  //  public bool Equals(TournamentMatch? other)
  //  {
		//return other is not null && Id.Equals(other.Id);
  //  }
}

