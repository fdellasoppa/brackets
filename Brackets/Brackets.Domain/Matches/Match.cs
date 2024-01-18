namespace Brackets.Domain.Matches;

public record Match(MatchId Id,
    DateTime MatchDate,
    Team LocalTeam,
    Team AwayTeam) : IEquatable<Match>
{
    public virtual bool Equals(Match? other)
    {
        return other is not null && Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
};

