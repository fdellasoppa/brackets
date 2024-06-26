﻿using Brackets.Domain.Matches;
using Brackets.Domain.Tournaments;

namespace Brackets.Domain.Brackets;

public record GoalScore : IGoals, IStringIdentifiable
{
    protected const int GOAL_PREDICTION_VALUE = 5;
    protected const int RESULT_PREDICTION_VALUE = 3;
    protected const int MISS_PREDICTION_VALUE = 0;
    protected const int NONE_PREDICTION_VALUE = 0;

    public string Id { get; init; } = null!;
    public int? LocalGoals { get; init; }
    public int? AwayGoals { get; init; }
    public int? LocalPenalties { get; init; }
    public int? AwayPenalties { get; init; }

    protected GoalScore() { }

    public GoalScore(int? localGoals, int? awayGoals, int? localPenalties, int? awayPenalties)
    {
        LocalGoals = localGoals;
        AwayGoals = awayGoals;
        LocalPenalties = localPenalties;
        AwayPenalties = awayPenalties;
    }

    public PredictionResult GetPredictionResult(IGoals match)
    {
        return match.LocalGoals == LocalGoals &&
            match.AwayGoals == AwayGoals ?
            PredictionResult.Goals :
                Match.CalculateResult(match) == Match.CalculateResult(this) ?
                PredictionResult.Match :
                PredictionResult.Miss;
    }

    public int GetPredictionScore(PredictionResult result)
    {
        return result switch
        {
            PredictionResult.Goals => GOAL_PREDICTION_VALUE,
            PredictionResult.Match => RESULT_PREDICTION_VALUE,
            PredictionResult.Miss => MISS_PREDICTION_VALUE,
            _ => NONE_PREDICTION_VALUE
        };
    }

}
