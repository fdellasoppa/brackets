namespace Brackets.Domain.Matches;

public record Match : IIdentifiable, IEquatable<Match>
{
	public Match() { }

	public long? Id { get; init; }
	public DateTime MatchDate { get; init; }
	public Team LocalTeam { get; init; } = null!;
	public Team AwayTeam { get; init; } = null!;

    public virtual bool Equals(Match? other)
    {
		return other is not null && Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return GetHashCode();
    }
}

