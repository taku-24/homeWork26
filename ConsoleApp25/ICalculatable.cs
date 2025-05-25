namespace GeometryFigures;

public interface ICalculatable
{
    double CalculateVolume();
    double CalculateSquare();
    string Name { get; }
}