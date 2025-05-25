namespace GeometryWithUserInput;

public struct Parallelepiped : ICalculatable
{
    public string Name { get; }
    public double? Length { get; }
    public double? Width { get; }
    public double? Height { get; }

    public Parallelepiped(string name, double? length, double? width, double? height)
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
            return Length.Value * Width.Value * Height.Value;
        }
        return null;
    }

    public double? CalculateSquare()
    {
        if (Length.HasValue && Width.HasValue && Height.HasValue)
        {
            return 2 * (Length.Value * Width.Value + 
                        Length.Value * Height.Value + 
                        Width.Value * Height.Value);
        }
        return null;
    }
}