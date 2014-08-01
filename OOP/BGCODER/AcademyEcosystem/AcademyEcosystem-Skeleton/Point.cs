using System;

namespace AcademyEcosystem
{
    public struct Point : IEquatable<Point>
    {
        public bool Equals(Point other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is Point && Equals((Point)obj);
        }

        public readonly int X;

        public readonly int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(string xString, string yString)
        {
            this.X = int.Parse(xString);
            this.Y = int.Parse(yString);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.X * 397) ^ this.Y;
            }
        }

        public static bool operator ==(Point a, Point b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", this.X, this.Y);
        }

        public static Point Parse(string pointString)
        {
            string coordinatesPairString = pointString.Substring(1, pointString.Length - 2);
            string[] coordinates = coordinatesPairString.Split(',');
            return new Point(coordinates[0], coordinates[1]);
        }

        public static int GetManhattanDistance(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }
    }
}
