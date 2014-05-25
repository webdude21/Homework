namespace Abstraction
{
    public class Rectangle : IFigure
    {
        public Rectangle(double width, double height)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Width { get; private set; }

        public double Height { get; private set; }

        public double CalculatePerimeter()
        {
            var perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public double CalculateSurface()
        {
            var surface = this.Width * this.Height;
            return surface;
        }
    }
}