namespace GeometryWithUserInput
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Список фигур: параллелепипед, пирамида, сфера, цилиндр, конус");
            Console.WriteLine("Укажите фигуру:");
            string figureName = Console.ReadLine()?.Trim().ToLower();

            ICalculatable figure = CreateFigure(figureName);
            if (figure == null)
            {
                Console.WriteLine("Неизвестный тип фигуры.");
                return;
            }

            double? volume = figure.CalculateVolume();
            double? square = figure.CalculateSquare();
            
            Console.WriteLine();
            Console.WriteLine("Фигура     | Объём       | Площадь");
            Console.WriteLine("-----------|------------ |-------------");

            string volumeStr = volume.HasValue 
                ? volume.Value.ToString("F2") 
                : "Невозможно (параметры не заданы корректно)";
            string squareStr = square.HasValue 
                ? square.Value.ToString("F2") 
                : "Невозможно (параметры не заданы корректно)";

            Console.WriteLine($"{figure.Name,-10} | {volumeStr,-11} | {squareStr}");
        }
        
        private static ICalculatable CreateFigure(string figureType)
        {
            switch (figureType)
            {
                case "параллелепипед":
                    Console.WriteLine("Введите длину:");
                    double? lengthPar = ParseNullable(Console.ReadLine());
                    Console.WriteLine("Введите ширину:");
                    double? widthPar = ParseNullable(Console.ReadLine());
                    Console.WriteLine("Введите высоту:");
                    double? heightPar = ParseNullable(Console.ReadLine());

                    return new Parallelepiped("параллелепипед", lengthPar, widthPar, heightPar);

                case "пирамида":
                    Console.WriteLine("Введите длину основания:");
                    double? lengthPy = ParseNullable(Console.ReadLine());
                    Console.WriteLine("Введите ширину основания:");
                    double? widthPy = ParseNullable(Console.ReadLine());
                    Console.WriteLine("Введите высоту:");
                    double? heightPy = ParseNullable(Console.ReadLine());

                    return new Pyramid("пирамида", lengthPy, widthPy, heightPy);

                case "сфера":
                    Console.WriteLine("Введите радиус:");
                    double? radiusSphere = ParseNullable(Console.ReadLine());

                    return new Sphere("сфера", radiusSphere);

                case "цилиндр":
                    Console.WriteLine("Введите радиус основания:");
                    double? radiusCyl = ParseNullable(Console.ReadLine());
                    Console.WriteLine("Введите высоту:");
                    double? heightCyl = ParseNullable(Console.ReadLine());

                    return new Cylinder("цилиндр", radiusCyl, heightCyl);

                case "конус":
                    Console.WriteLine("Введите радиус основания:");
                    double? radiusCone = ParseNullable(Console.ReadLine());
                    Console.WriteLine("Введите высоту:");
                    double? heightCone = ParseNullable(Console.ReadLine());

                    return new Cone("конус", radiusCone, heightCone);

                default:
                    return null;
            }
        }
        private static double? ParseNullable(string input)
        {
            if (double.TryParse(input, out double result))
            {
                return result;
            }
            return null;
        }
    }
}
