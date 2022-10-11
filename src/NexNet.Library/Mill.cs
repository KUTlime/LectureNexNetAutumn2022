using System.Security.Cryptography.X509Certificates;

namespace NexNet.Library;

public class Mill
{
    public ToolPath Path { get; set; }

    public RadialMeasurement Measurement { get; set; }

    public Mill(double nominalDiameterValue, double previousProcessedPath = 0)
    {
        Path = new ToolPath(previousProcessedPath);
        Measurement = new RadialMeasurement(nominalDiameterValue);
    }
}

public class ToolPath
{
    public double Value { get; private set; }

    public ToolPath(double previousValue = default)
    {
        Value = previousValue;
    }

    public void AddPathLength(double processedPath)
    {
        Value += processedPath;
    }
}


public class ChangeTool
{
    public bool yesNo;

    public ChangeTool(double processedPath) => yesNo = processedPath > 5000 ? true : false;

}

public abstract class MeasurementBase
{
    public double NominalValue { get; init; }
    public double MeasuredValue { get; set; }
    public double Difference => NominalValue - MeasuredValue;

    public MeasurementBase(double nominalValue)
    {
        NominalValue = nominalValue;
    }
}

public class RadialMeasurement : MeasurementBase
{
    public RadialMeasurement(double nominalValue) : base(nominalValue)
    {}
}

public class AxialMeasurement: MeasurementBase
{
    public AxialMeasurement(double nominalValue) : base(nominalValue)
    {
    }
}

