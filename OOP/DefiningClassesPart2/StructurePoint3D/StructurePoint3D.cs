using System;

namespace StructurePoint3D
{
    class StructurePoint3D
    {
        static void Main()
        {
            Path myPath = PathStorage.LoadPath(@"..\..\path.txt");
            Console.WriteLine(myPath);
            Point3D zero = Point3D.GetPointO;
            Point3D testPoint = new Point3D(6, 2, 1);
            Console.WriteLine("The distance between {0} and {1} is {2:0.00}", zero, testPoint, DistanceIn3DSpace.CalculateDistanceBetween(zero, testPoint)); 
            PathStorage.SavePath(myPath, @"..\..\output.txt");
        }
    }
}
