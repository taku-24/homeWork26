namespace GeometryFigures
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICalculatable[] figures =
            {
                new Parallelepiped("Параллелепипед", 2, 3, 4),
                new Pyramid("Пирамида", 3, 4, 5),
                new Sphere("Сфера", 2),
                new Cylinder("Цилиндр", 1, 1),
                new Cone("Конус", 2, 5)
            };
            FindAndPrintMaxFigures(figures);
        }
        
        static void FindAndPrintMaxFigures(ICalculatable[] figures)
        {
            if (figures == null || figures.Length == 0)
            {
                Console.WriteLine("Массив фигур пуст!");
                return;
            }

            ICalculatable maxVolumeFigure = figures[0];
            ICalculatable maxSquareFigure = figures[0];

            foreach (var figure in figures)
            {
                if (figure.CalculateVolume() > maxVolumeFigure.CalculateVolume())
                {
                    maxVolumeFigure = figure;
                }

                if (figure.CalculateSquare() > maxSquareFigure.CalculateSquare())
                {
                    maxSquareFigure = figure;
                }
            }

            Console.WriteLine($"Фигура с наибольшим объёмом: {maxVolumeFigure.Name}");
            Console.WriteLine($"   Объём: {maxVolumeFigure.CalculateVolume()}");
            Console.WriteLine($"Фигура с наибольшей поверхностью: {maxSquareFigure.Name}");
            Console.WriteLine($"   Площадь: {maxSquareFigure.CalculateSquare()}");
        }
    }
}
