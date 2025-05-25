using System.Text.Json;

namespace GeometryJsonLogger
{

    class Program
    {
        private const string JsonFilePath = "results.json";

        static void Main()
        {
            List<FigureResult> calculations = new List<FigureResult>();

            if (File.Exists(JsonFilePath))
            {
                try
                {
                    string existingData = File.ReadAllText(JsonFilePath);
                    var existingList = JsonSerializer.Deserialize<List<FigureResult>>(existingData);
                    if (existingList != null)
                    {
                        calculations = existingList;
                    }
                }
                catch
                {
                    Console.WriteLine(
                        "Не удалось считать данные из существующего JSON-файла. Будет создан новый список результатов.");
                }
            }

            Console.WriteLine("Список доступных фигур:");
            Console.WriteLine("cфера, параллелепипед, пирамида, цилиндр, конус, усеченный конус");
            Console.WriteLine("Для выхода введите \"выход\".");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Введите название фигуры или \"выход\": ");
                string input = Console.ReadLine()?.Trim().ToLower();
                
                if (input == "выход" || string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Работа программы завершена. Все результаты сохранены в JSON-файл.");
                    break;
                }
                
                ICalculatable figure = CreateFigure(input);
                if (figure == null)
                {
                    Console.WriteLine("Неизвестная фигура. Повторите ввод.");
                    continue;
                }
                
                double? volume = figure.CalculateVolume();
                double? surface = figure.CalculateSurface();
                
                string volumeStr = volume.HasValue
                    ? volume.Value.ToString("F2")
                    : "Невозможно (параметры не заданы корректно)";
                string surfaceStr = surface.HasValue
                    ? surface.Value.ToString("F2")
                    : "Невозможно (параметры не заданы корректно)";
                
                Console.WriteLine();
                Console.WriteLine($"Фигура: {figure.Name}");
                Console.WriteLine($"Объём: {volumeStr}");
                Console.WriteLine($"Площадь: {surfaceStr}");
                
                calculations.Add(new FigureResult
                {
                    FigureName = figure.Name,
                    Volume = volume,
                    Surface = surface
                });
                SaveResultsToJson(calculations);
            }
        }
        
        private static ICalculatable CreateFigure(string figureType)
        {
            switch (figureType)
            {
                case "сфера":
                {
                    double? radius = PromptForDouble("Введите радиус:");
                    return new Sphere("сфера", radius);
                }
                case "параллелепипед":
                {
                    double? length = PromptForDouble("Введите длину:");
                    double? width = PromptForDouble("Введите ширину:");
                    double? height = PromptForDouble("Введите высоту:");
                    return new Parallelepiped("параллелепипед", length, width, height);
                }
                case "пирамида":
                {
                    double? length = PromptForDouble("Введите длину основания:");
                    double? width = PromptForDouble("Введите ширину основания:");
                    double? height = PromptForDouble("Введите высоту:");
                    return new Pyramid("пирамида", length, width, height);
                }
                case "цилиндр":
                {
                    double? radius = PromptForDouble("Введите радиус основания:");
                    double? height = PromptForDouble("Введите высоту:");
                    return new Cylinder("цилиндр", radius, height);
                }
                case "конус":
                {
                    double? radius = PromptForDouble("Введите радиус основания:");
                    double? height = PromptForDouble("Введите высоту:");
                    return new Cone("конус", radius, height);
                }
                case "усеченный конус":
                {
                    double? lowerRadius = PromptForDouble("Введите радиус нижнего основания:");
                    double? upperRadius = PromptForDouble("Введите радиус верхнего основания:");
                    double? height = PromptForDouble("Введите высоту:");
                    return new TruncatedCone("усеченный конус", lowerRadius, upperRadius, height);
                }
                default:
                    return null;
            }
        }
        
        private static double? PromptForDouble(string message)
        {
            Console.Write($"{message} ");
            string input = Console.ReadLine();
            if (double.TryParse(input, out double value))
            {
                return value;
            }

            return null;
        }
        
        private static void SaveResultsToJson(List<FigureResult> results)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(results, options);
                File.WriteAllText(JsonFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в JSON-файл: {ex.Message}");
            }
        }
    }
}
