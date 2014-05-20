namespace RotatedSize
{
    using System;

    public struct Figure
    {
        public Figure(double height, double widht)
            : this()
        {
            this.Height = height;
            this.Width = widht;
        }

        public double Height { get; private set; }

        public double Width { get; private set; }

        public static Figure GetRotatedSize(Figure figure, double angleOfRotation)
        {
            var sinOfAngle = Math.Abs(Math.Sin(angleOfRotation));
            var cosOfAngle = Math.Abs(Math.Cos(angleOfRotation));

            return new Figure(
              (Math.Abs(cosOfAngle) * figure.Height) + (Math.Abs(sinOfAngle) * figure.Height),
              (Math.Abs(sinOfAngle) * figure.Width) + (Math.Abs(cosOfAngle) * figure.Height));
        }
    }
}