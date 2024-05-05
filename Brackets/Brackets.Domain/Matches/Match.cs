using Brackets.Domain.Tournament;

namespace Brackets.Domain.Matches;

public class Match : IGoals, IIdentifiable, IEquatable<Match>
{
    public const int MATCH_LOCK_HOURS = 6;

	public string Id { get; init; } = null!;

	public Team LocalTeam { get; init; } = null!;
	public Team AwayTeam { get; init; } = null!;
	public DateTime MatchDate { get; init; }

	public Tournament.Tournament Cup { get; init; } = null!;
	public Stage Stage { get; init; } = null!;

	public int? LocalGoals { get; init; }
	public int? AwayGoals { get; init; }
	public int? LocalPenalties { get; init; }
	public int? AwayPenalties { get; init; }

	#region IEquatable

	public override bool Equals(object? obj)
	{
		return Equals(obj as Match);
	}

	public virtual bool Equals(Match? other)
    {
        return other is not null && Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

	#endregion

	public bool IsMatchLocked => 
		IsMatchPlayed 
		|| DateTime.UtcNow.AddHours(MATCH_LOCK_HOURS) > MatchDate;

	public bool IsMatchPlayed => 
		LocalGoals != null && AwayGoals != null;

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
	
}
