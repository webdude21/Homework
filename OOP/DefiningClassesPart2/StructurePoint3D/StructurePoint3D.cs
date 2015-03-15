namespace StructurePoint3D
{
    using System;

    internal class StructurePoint3D
    {
        private static void Main()
        {
            var myPath = PathStorage.LoadPath(@"..\..\path.txt");
            Console.WriteLine(myPath);
            var zero = Point3D.GetPointO;
            var testPoint = new Point3D(6, 2, 1);
            Console.WriteLine("The distance between {0} and {1} is {2:0.00}", zero, testPoint, DistanceIn3DSpace.CalculateDistanceBetween(zero, testPoint));
            PathStorage.SavePath(myPath, @"..\..\output.txt");
        }
    }
}