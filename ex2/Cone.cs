namespace GeometryWithUserInput;

public struct Cone : ICalculatable
{
    public string Name { get; }
    public double? Radius { get; }
    public double? Height { get; }

    public Cone(string name, double? radius, double? height)
    {
        Name = name;
        Radius = radius;
        Height = height;
    }

    public double? CalculateVolume()
    {
        if (Radius.HasValue && Height.HasValue)
        {
            return (1.0 / 3.0) * Math.PI * Math.Pow(Radius.Value, 2) * Height.Value;
        }
        return null;
    }

    public double? CalculateSquare()
    {
        if (Radius.HasValue && Height.HasValue)
        {
            double slantHeight = Math.Sqrt(Math.Pow(Radius.Value, 2) + Math.Pow(Height.Value, 2));
            return Math.PI * Radius.Value * (Radius.Value + slantHeight);
        }
        return null;
    }
}