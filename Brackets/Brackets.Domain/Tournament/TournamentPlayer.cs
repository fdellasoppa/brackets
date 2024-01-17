using Brackets.Domain.Matches;

namespace Brackets.Domain.Tournament;

public record TournamentPlayer : IIdentifiable
{
    public long? Id { get; init; }
    public Player Player { get; init; } = null!;
    public decimal AverageScore { get; set; }
    public int Appearances { get; set; }
    public int Goals { get; set; }
    public int Assists { get; set; }
    public int GoalsConceded { get; set; }
    public int CleanSheets { get; set; }
    public int YellowCards { get; set; }
    public int RedCards { get; set; }
}
