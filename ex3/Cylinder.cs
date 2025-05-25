namespace GeometryJsonLogger;

public struct Cylinder : ICalculatable
{
    public string Name { get; }
    public double? Radius { get; }
    public double? Height { get; }

    public Cylinder(string name, double? radius, double? height)
    {
        Name = name;
        Radius = radius;
        Height = height;
    }

    public double? CalculateVolume()
    {
        if (Radius.HasValue && Height.HasValue)
        {
            return Math.PI * Math.Pow(Radius.Value, 2) * Height.Value;
        }
        return null;
    }

    public double? CalculateSurface()
    {
        if (Radius.HasValue && Height.HasValue)
        {
            return 2.0 * Math.PI * Radius.Value * (Radius.Value + Height.Value);
        }
        return null;
    }
}

