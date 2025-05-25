namespace GeometryJsonLogger;

public struct Pyramid : ICalculatable
{
    public string Name { get; }
    public double? Length { get; }
    public double? Width { get; }
    public double? Height { get; }

    public Pyramid(string name, double? length, double? width, double? height)
    {
        Name = name;
        Length = length;
        Width = width;
        Height = height;
    }

    public double? CalculateVolume()
    {
        if (Length.HasValue && Width.HasValue && Height.HasValue)
        {
            return (1.0 / 3.0) * (Length.Value * Width.Value) * Height.Value;
        }
        return null;
    }

    public double? CalculateSurface()
    {
        if (Length.HasValue && Width.HasValue && Height.HasValue)
        {
            double baseArea = Length.Value * Width.Value;
            double slantWidth = Math.Sqrt(Math.Pow(Width.Value / 2.0, 2) + Math.Pow(Height.Value, 2));
            double slantLength = Math.Sqrt(Math.Pow(Length.Value / 2.0, 2) + Math.Pow(Height.Value, 2));
            double sideArea = Length.Value * slantWidth + Width.Value * slantLength;
            return baseArea + sideArea;
        }
        return null;
    }
}
