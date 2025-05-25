namespace GeometryJsonLogger;

public interface ICalculatable
{
    double? CalculateVolume();
    double? CalculateSurface();
    string Name { get; }
}