namespace Brackets.Domain.Matches;

public record Player : IIdentifiable
{
    public Player() { 
    }

    public long? Id { get; init; }
    public Country Country { get; set; } = default!;
    public string Name { get; init; } = string.Empty;
    public int Position { get; init; }
    public int Number { get; init; }
}
