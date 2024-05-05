﻿using Brackets.Domain.Matches;
using Brackets.Domain.Tournament;

namespace Brackets.Domain.Brackets;

public record ExtraPredictionResult: IIdentifiable
{
    public ExtraPredictionResult() { }

    public string Id { get; init; } = null!;
    public Tournament.Tournament Cup { get; init; } = default!;
    public PredictionType PredictionType { get; init; } = default!;
    public Player? Player { get; init; } = default;
    public Team? Team { get; init; } = default;
}

