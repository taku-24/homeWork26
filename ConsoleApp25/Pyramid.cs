namespace GeometryFigures;

public struct Pyramid : ICalculatable
{
    public string Name { get; }
    public double Length { get; }
    public double Width { get; }
    public double Height { get; }

    public Pyramid(string name, double length, double width, double height)
    {
        Name = name;
        Length = length;
        Width = width;
        Height = height;
    }

    public double CalculateVolume()
    {
        return (1.0 / 3.0) * (Length * Width) * Height;
    }

    public double CalculateSquare()
    {
        double baseArea = Length * Width;
        
        double slantWidth = Math.Sqrt(Math.Pow(Width / 2.0, 2) + Math.Pow(Height, 2));

        double slantLength = Math.Sqrt(Math.Pow(Length / 2.0, 2) + Math.Pow(Height, 2));

        double sideArea = Length * slantWidth + Width * slantLength;
        return baseArea + sideArea;
    }
}