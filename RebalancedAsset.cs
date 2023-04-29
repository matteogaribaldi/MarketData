namespace MarketData;

public class RebalancedAsset
{
    public string? name { get; set; }
    public float? currentPrice{ get; set; }
    public int? number { get; set; }
    public float? totalPrice { get; set; }
    public float? ratio { get; set; }
    public float? targetRatio { get; set; }
    public float? calculatedTargetNumber { get; set; }
    public float? calculatedTargetDelta { get; set; }
    public float? calculatedTotalPrice { get; set; }
}
