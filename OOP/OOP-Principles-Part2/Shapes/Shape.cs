namespace Shapes
{
    public abstract class Shape
    {
        protected Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public abstract double CalculateSurface();

        public override string ToString()
        {
            return string.Format(
                "I'm a {0} and my surface area is {1:0.00}", 
                this.GetType().Name, 
                this.CalculateSurface());
        }
    }
}