namespace GeometryJsonLogger;

public struct TruncatedCone : ICalculatable
{
    public string Name { get; }
    public double? LowerRadius { get; }
    public double? UpperRadius { get; }
    public double? Height { get; }

    public TruncatedCone(string name, double? lowerRadius, double? upperRadius, double? height)
    {
        Name = name;
        LowerRadius = lowerRadius;
        UpperRadius = upperRadius;
        Height = height;
    }

    public double? CalculateVolume()
    {
        if (LowerRadius.HasValue && UpperRadius.HasValue && Height.HasValue)
        {
            double R = LowerRadius.Value;
            double r = UpperRadius.Value;
            double h = Height.Value;
            return (1.0 / 3.0) * Math.PI * h * (R*R + R*r + r*r);
        }
        return null;
    }

    public double? CalculateSurface()
    {
        if (LowerRadius.HasValue && UpperRadius.HasValue && Height.HasValue)
        {
            double R = LowerRadius.Value;
            double r = UpperRadius.Value;
            double h = Height.Value;

            double l = Math.Sqrt((R - r)*(R - r) + h*h);
            double basePart = Math.PI * (R * R + r * r);
            double sidePart = Math.PI * (R + r) * l;

            return basePart + sidePart;
        }
        return null;
    }
}
