namespace StructurePoint3D
{
    using System;

    internal static class DistanceIn3DSpace
    {
        public static double CalculateDistanceBetween(Point3D a, Point3D b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y) + (a.Z - b.Z) * (a.Z - b.Z));
        }
    }
}