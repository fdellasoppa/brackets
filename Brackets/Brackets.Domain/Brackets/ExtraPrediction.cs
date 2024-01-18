using Brackets.Domain.Matches;

namespace Brackets.Domain.Brackets;

public record ExtraPrediction: IIdentifiable
{
    // TODO: Remove hardcoding
    private static readonly List<long?> MOST_ASSISTS_Q_2022_IDS = new()
    { 
        88L, 162L, 232L, 427L, 514L
    };

    public ExtraPrediction() { }
    public long? Id { get; init; }
    public Bracket Bracket { get; set; } = null!;
    public Player? Player { get; set; } = default;
    public Team? Team { get; set; } = default;
    public PredictionType PredictionType { get; set; } = default!;

    public int GetPredictionResult(ExtraPredictionResult? epr, List<PredictionType> predTypes)
    {
        if (Player == null && Team == null) return 0;

        if (epr == null 
            || epr.PredictionType == null 
            || PredictionType == null 
            || PredictionType.Id != epr.PredictionType.Id)
            return 0;

        if (epr.Player == null && epr.Team == null) return 0;

        if (predTypes == null || predTypes.Count == 0) return 0;

        ExtraPredResult predResult = ExtraPredResult.None;
        var predPoints = predTypes
            .Where(k => k.Id == epr.PredictionType!.Id)
            .Select(q => q.Points)
            .FirstOrDefault(0);

        IIdentifiable? eprId = null;
        IIdentifiable? thisId = null;

        if (Player == null && Team != null)
        {
            thisId = Team!.Id;
            eprId = epr.Team!.Id;
        }
        else if (Player != null && Team == null)
        {
            thisId = Player!.Id;
         
            if (epr.PredictionType!.Id == 10) // Most Assist
            {
                if (MOST_ASSISTS_Q_2022_IDS.Contains(thisId.Id))
                    eprId = thisId;
            }
            else 
            {
                eprId = epr.Player!.Id;
            }
        }

        if (eprId?.Id is null || thisId?.Id is null) 
            return 0;

        predResult = eprId == thisId ? 
            ExtraPredResult.Match 
            : ExtraPredResult.Miss;

        return predResult == ExtraPredResult.Match ? 
            predPoints 
            : 0;
    }
}

