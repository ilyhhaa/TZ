using System.Drawing;
using TZ;
using Rectangle = TZ.Rectangle;
using Point = TZ.Point;

class Program
{
    static void Main(string[] args)
    {
        //Записываем логи в консоль
        Logger.SetDestination(Logger.LogDestination.Console);

        // Сюда вводим точки второстепенных треугольников 
        var rectangles = new List<Rectangle>
            {
                new Rectangle(Color.Green, new Point(1, 1), new Point(1, 4), new Point(4, 1), new Point(4, 4)),
                new Rectangle(Color.Red, new Point(2, 2), new Point(2, 5), new Point(5, 2), new Point(5, 5)),
                new Rectangle(Color.Blue, new Point(0, 0), new Point(0, 3), new Point(3, 0), new Point(3, 3))
            };

        //Находим главный прямоугольник
        var boundingRectangle = RectangleUt.GetBoundingRectangle(rectangles);

        if (boundingRectangle != null)
        {
            Logger.Log($"Bounding Rectangle: ({boundingRectangle.BotLeft.X}, {boundingRectangle.BotLeft.Y}) to ({boundingRectangle.TopRight.X}, {boundingRectangle.TopRight.Y})");
        }
        else
        {
            Logger.Log("No bounding rectangle found.");
        }

        // Фильтрация по цвету
        var filteredRectangle = RectangleUt.GetBoundingRectangle(rectangles, new List<Color> { Color.Green, Color.Blue });

        if (filteredRectangle != null)
        {
            Logger.Log($"Filtered Bounding Rectangle: ({filteredRectangle.BotLeft.X}, {filteredRectangle.BotLeft.Y}) to ({filteredRectangle.TopRight.X}, {filteredRectangle.TopRight.Y})");
        }
        else
        {
            Logger.Log("No filtered bounding rectangle found.");
        }

        // Игнорируем точки вне главного прямоугольника
        var ignoredRectangle = RectangleUt.GetBoundingRectangle(rectangles, ignoreOutside: true);

        if (ignoredRectangle != null)
        {
            Logger.Log($"Ignored Bounding Rectangle: ({ignoredRectangle.BotLeft.X}, {ignoredRectangle.BotLeft.Y}) to ({ignoredRectangle.TopRight.X}, {ignoredRectangle.TopRight.Y})");
        }
        else
        {
            Logger.Log("No ignored bounding rectangle found.");
        }
    }
}