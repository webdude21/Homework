namespace Shapes
{
    public abstract class Shape
    {
        private double width;
        private double height;

        protected Shape(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        
        public double Height
        {
            get { return height; }
            set { height = value; }
        }


        public abstract double CalculateSurface();

        public override string ToString()
        {
            return string.Format("I'm a {0} and my surface area is {1:0.00}", this.GetType().Name, this.CalculateSurface());
        }
    }
}
