
public class Display
{
    public enum ColorDepth
    {
        _8bit, _16Bit, _32Bit
    }

    private double size;
    private ColorDepth colors;

    public Display() : this(0, 0)
    {

    }
    public Display(double sizeInInches) : this(sizeInInches, 0)
    {

    }
    public Display(double sizeInInches, ColorDepth colorDepth)
    {
        this.size = sizeInInches;
        this.colors = colorDepth;
    }
}