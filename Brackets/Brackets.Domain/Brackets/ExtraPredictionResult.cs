using Brackets.Domain.Matches;
using Brackets.Domain.Tournament;

namespace Brackets.Domain.Brackets;

public record ExtraPredictionResult: IIdentifiable
{
    public ExtraPredictionResult() { }

    public long? Id { get; init; }
    public WorldCup Cup { get; init; } = default!;
    public PredictionType PredictionType { get; init; } = default!;
    public Player? Player { get; init; } = default;
    public Team? Team { get; init; } = default;
}

