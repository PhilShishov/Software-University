namespace P02
{
    public class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }

        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            bool insideByX = point.CoordinateX >= TopLeft.CoordinateX
                && point.CoordinateX <= BottomRight.CoordinateX;

            bool insideByY = point.CoordinateY >= TopLeft.CoordinateY
                && point.CoordinateY <= BottomRight.CoordinateY;

            return insideByX && insideByY;
        }
    }
}
