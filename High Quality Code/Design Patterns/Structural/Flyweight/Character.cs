namespace Flyweight
{
    /// <summary>
    /// The 'Flyweight' abstract class
    /// </summary>
    internal abstract class Character
    {
        protected int Ascent;

        protected int Descent;

        protected int Height;

        protected int PointSize;

        protected char Symbol;

        protected int Width;

        public abstract void Display(int pointSize);
    }
}