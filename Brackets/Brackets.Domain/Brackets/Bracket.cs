using Brackets.Domain.Matches;
using Brackets.Domain.Tournaments;

namespace Brackets.Domain.Brackets;

public enum PredictionResult
{
	None = 0,
	Goals,
	Match,
	Miss
}

public enum ExtraPredResult
{
	None = 0,
	Miss,
	Match
}

public record Bracket : IStringIdentifiable
{
	public Bracket() { }

    public string Id { get; init; } = null!;
	public BracketUser BracketUser { get; init; } = null!;
	public int Score { get; set; }
	public int Position { get; set; }
	public DateTime ModifiedDate { get; set; }
	public string ModifiedUser { get; set; } = string.Empty;

	public int GoalsResultCount { get; set; }
	public int MatchResultCount { get; set; }
	public int MissResultCount { get; set; }


	// TODO: Change to any tournament
	public Tournament Tournament { get; set; } = default!;

    public IDictionary<Match, GoalScore> Predictions { get; set; } 
		= new Dictionary<Match, GoalScore>();
	public IList<ExtraPrediction> ExtraPredictions { get; set; } = null!;

    public void UpdateCounts(PredictionResult res)
    {
        _ = res switch
        {
            PredictionResult.Goals => GoalsResultCount++,
            PredictionResult.Match => MatchResultCount++,
            PredictionResult.Miss => MissResultCount++,
			_ => MissResultCount // skip
		};
    }

	public void ResetCounts()
    {
		GoalsResultCount = 0;
		MatchResultCount = 0;
		MissResultCount = 0;
	}
}
