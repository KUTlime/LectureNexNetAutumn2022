namespace NexNet.Library;

public class Tool
{
    public string Name { get; init; } = string.Empty;
    public double? Length { get; init; }
    public uint CuttingEdgeNumber { get; init; }
    private decimal _cost;
    public decimal Cost
    {
        get => _cost;
        //   podmínka ? pokudPravda : pokudNepravda;
        //   is this condition true ? yes : no;
        set => _cost = value < 0 ? 0 : value;
    }
}