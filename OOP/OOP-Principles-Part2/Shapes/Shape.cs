namespace Shapes
{
    public abstract class Shape
    {
        protected double width;
        protected double height;

        protected Shape(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public abstract double CalculateSurface();

        public override string ToString()
        {
            return string.Format("I'm a {0} and my surface area is {1:0.00}", this.GetType().Name, this.CalculateSurface());
        }
    }
}
