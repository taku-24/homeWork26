namespace GeometryFigures;

public struct Cone : ICalculatable
{
    public string Name { get; }
    public double Radius { get; }
    public double Height { get; }

    public Cone(string name, double radius, double height)
    {
        Name = name;
        Radius = radius;
        Height = height;
    }

    public double CalculateVolume()
    {
        return (1.0 / 3.0) * Math.PI * Math.Pow(Radius, 2) * Height;
    }

    public double CalculateSquare()
    {
        double slantHeight = Math.Sqrt(Math.Pow(Radius, 2) + Math.Pow(Height, 2));
        return Math.PI * Radius * (Radius + slantHeight);
    }
}