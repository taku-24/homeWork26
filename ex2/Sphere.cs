namespace GeometryWithUserInput;

public struct Sphere : ICalculatable
{
    public string Name { get; }
    public double? Radius { get; }

    public Sphere(string name, double? radius)
    {
        Name = name;
        Radius = radius;
    }

    public double? CalculateVolume()
    {
        if (Radius.HasValue)
        {
            return 4.0 / 3.0 * Math.PI * Math.Pow(Radius.Value, 3);
        }
        return null;
    }

    public double? CalculateSquare()
    {
        if (Radius.HasValue)
        {
            return 4.0 * Math.PI * Math.Pow(Radius.Value, 2);
        }
        return null;
    }
}