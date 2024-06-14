using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ
{

    public static class RectangleUt
    {
        public static Rectangle GetBoundingRectangle(List<Rectangle> rectangles, List<Color> colorsToInclude = null, bool ignoreOutside = false)
        {
            //Проверка входных
            if (rectangles == null || rectangles.Count == 0)
                return null;

            //Фильтруем прямоугольники по цвету 
            var filteredRectangles = rectangles.Where(r => colorsToInclude == null || colorsToInclude.Contains(r.Color)).ToList();

            //Список пуст? NULL
            if (filteredRectangles.Count == 0)
                return null;

            double minX = double.MaxValue;
            double minY = double.MaxValue;
            double maxX = double.MinValue;
            double maxY = double.MinValue;

            //Проверяем каждую точку. Игнорирование вкл? 
            foreach (var rect in filteredRectangles)
            {
                var points = new List<Point> { rect.BotLeft, rect.TopLeft, rect.BotRight, rect.TopRight };

                foreach (var point in points)
                {
                    if (ignoreOutside && (point.X < 0 || point.Y < 0 || point.X > 5 || point.Y > 5)) //Игнорирование вкл ? игнорируем точки вне наших (0,0)(5,5)
                        continue;

                    if (point.X < minX) minX = point.X;
                    if (point.Y < minY) minY = point.Y;
                    if (point.X > maxX) maxX = point.X;
                    if (point.Y > maxY) maxY = point.Y;
                }
            }
            //Границы не обновились ? NULL
            if (minX == double.MaxValue || minY == double.MaxValue || maxX == double.MinValue || maxY == double.MinValue)
                return null;

            //Обновились создем новый Rectangle
            return new Rectangle(Color.Empty, new Point(minX, minY), new Point(minX, maxY), new Point(maxX, minY), new Point(maxX, maxY)); 
        }
    }
}
    
