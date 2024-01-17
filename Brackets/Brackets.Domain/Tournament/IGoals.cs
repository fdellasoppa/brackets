namespace Brackets.Domain.Tournament;

public interface IGoals
{
    public int? LocalGoals { get; set; }
    public int? AwayGoals { get; set; }
    public int? LocalPenalties { get; set; }
    public int? AwayPenalties { get; set; }
}
