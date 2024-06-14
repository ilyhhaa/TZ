using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ
{
    public class Rectangle
    {
        public Color Color { get; set; }
        public Point BotLeft { get; set; }
        public Point TopLeft { get; set; }
        public Point BotRight { get; set; }
        public Point TopRight { get; set; }

        public Rectangle(Color color, Point botLeft, Point topLeft, Point botRight, Point topRight)
        {
            Color = color;
            BotLeft = botLeft;
            TopLeft = topLeft;
            BotRight = botRight;
            TopRight = topRight;
        }
    }
}
