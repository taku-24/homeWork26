namespace GeometryFigures;

public struct Cylinder : ICalculatable
{
    public string Name { get; }
    public double Radius { get; }
    public double Height { get; }

    public Cylinder(string name, double radius, double height)
    {
        Name = name;
        Radius = radius;
        Height = height;
    }

    public double CalculateVolume()
    {
        return Math.PI * Math.Pow(Radius, 2) * Height;
    }

    public double CalculateSquare()
    {
        return 2.0 * Math.PI * Radius * (Radius + Height);
    }
}