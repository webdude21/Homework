namespace DefiningClasses
{
    public class Display
    {
        public Display()
            : this(0, 0)
        {
        }

        public Display(double sizeInInches)
            : this(sizeInInches, 0)
        {
        }

        public Display(double sizeInInches, ColorDepth colorDepth)
        {
            this.Size = sizeInInches;
            this.Colors = colorDepth;
        }

        public double Size { get; private set; }

        public ColorDepth Colors { get; private set; }
    }
}