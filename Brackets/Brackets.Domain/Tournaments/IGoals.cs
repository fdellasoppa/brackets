namespace Brackets.Domain.Tournaments;

public interface IGoals
{
    public int? LocalGoals { get; init; }
    public int? AwayGoals { get; init; }
    public int? LocalPenalties { get; init; }
    public int? AwayPenalties { get; init; }
}
