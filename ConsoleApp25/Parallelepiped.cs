namespace GeometryFigures;

public struct Parallelepiped : ICalculatable
{
    public string Name { get; }
    public double Length { get; }
    public double Width { get; }
    public double Height { get; }

    public Parallelepiped(string name, double length, double width, double height)
    {
        Name = name;
        Length = length;
        Width = width;
        Height = height;
    }

    public double CalculateVolume()
    {
        return Length * Width * Height;
    }

    public double CalculateSquare()
    {
        return 2 * (Length * Width + Length * Height + Width * Height);
    }
}