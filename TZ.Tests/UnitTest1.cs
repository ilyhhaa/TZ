
using System.Drawing;

namespace TZ.Tests
{
    public class RectangleUtTests
    {
        [Fact]
        public void TestBoundingRectangle_AllRectangles()
        {
            var rectangles = new List<Rectangle>
            {
                new Rectangle(Color.Green, new Point(1, 1), new Point(1, 4), new Point(4, 1), new Point(4, 4)),
                new Rectangle(Color.Red, new Point(2, 2), new Point(2, 5), new Point(5, 2), new Point(5, 5)),
                new Rectangle(Color.Blue, new Point(0, 0), new Point(0, 3), new Point(3, 0), new Point(3, 3))
            };

            var boundingRectangle = RectangleUt.GetBoundingRectangle(rectangles);

            Assert.NotNull(boundingRectangle);
            Assert.Equal(0, boundingRectangle.BotLeft.X);
            Assert.Equal(0, boundingRectangle.BotLeft.Y);
            Assert.Equal(5, boundingRectangle.TopRight.X);
            Assert.Equal(5, boundingRectangle.TopRight.Y);
        }

        [Fact]
        public void TestBoundingRectangle_WithColorFilter()
        {
            var rectangles = new List<Rectangle>
            {
                new Rectangle(Color.Green, new Point(1, 1), new Point(1, 4), new Point(4, 1), new Point(4, 4)),
                new Rectangle(Color.Red, new Point(2, 2), new Point(2, 5), new Point(5, 2), new Point(5, 5)),
                new Rectangle(Color.Blue, new Point(0, 0), new Point(0, 3), new Point(3, 0), new Point(3, 3))
            };

            var boundingRectangle = RectangleUt.GetBoundingRectangle(rectangles, new List<Color> { Color.Green, Color.Blue });

            Assert.NotNull(boundingRectangle);
            Assert.Equal(0, boundingRectangle.BotLeft.X);
            Assert.Equal(0, boundingRectangle.BotLeft.Y);
            Assert.Equal(4, boundingRectangle.TopRight.X);
            Assert.Equal(4, boundingRectangle.TopRight.Y);
        }

        [Fact]
        public void TestBoundingRectangle_EmptyRectangles()
        {
            var rectangles = new List<Rectangle>();

            var boundingRectangle = RectangleUt.GetBoundingRectangle(rectangles);

            Assert.Null(boundingRectangle);
        }

        [Fact]
        public void TestBoundingRectangle_SingleRectangle()
        {
            var rectangles = new List<Rectangle>
            {
                new Rectangle(Color.Green, new Point(1, 1), new Point(1, 4), new Point(4, 1), new Point(4, 4))
            };

            var boundingRectangle = RectangleUt.GetBoundingRectangle(rectangles);

            Assert.NotNull(boundingRectangle);
            Assert.Equal(1, boundingRectangle.BotLeft.X);
            Assert.Equal(1, boundingRectangle.BotLeft.Y);
            Assert.Equal(4, boundingRectangle.TopRight.X);
            Assert.Equal(4, boundingRectangle.TopRight.Y);
        }

        [Fact]
        public void TestBoundingRectangle_IgnoreOutside()
        {
            var rectangles = new List<Rectangle>
            {
                new Rectangle(Color.Green, new Point(1, 1), new Point(1, 4), new Point(4, 1), new Point(4, 4)),
                new Rectangle(Color.Red, new Point(-2, -2), new Point(-2, 5), new Point(5, -2), new Point(5, 5)),
                 new Rectangle(Color.Blue, new Point(-1, -1), new Point(-1, 6), new Point(6, -1), new Point(6, 6))
            };

            var boundingRectangle = RectangleUt.GetBoundingRectangle(rectangles, ignoreOutside: true);

            Assert.NotNull(boundingRectangle);
            Assert.Equal(1, boundingRectangle.BotLeft.X);
            Assert.Equal(1, boundingRectangle.BotLeft.Y);
            Assert.Equal(5, boundingRectangle.TopRight.X);
            Assert.Equal(5, boundingRectangle.TopRight.Y);
        }
    }
}