namespace CohesionAndCoupling
{
    using System;

    internal class UtilsExamples
    {
        private static void Main()
        {
            Console.WriteLine(FileOperations.GetFileExtension("example"));
            Console.WriteLine(FileOperations.GetFileExtension("example.pdf"));
            Console.WriteLine(FileOperations.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileOperations.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileOperations.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileOperations.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", MeasurementsOperations.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", MeasurementsOperations.CalcDistance3D(5, 2, -1, 3, -6, 4));

            var parallelepiped = new Parallelepiped(3, 4, 5);
            Console.WriteLine("Volume = {0:f2}", MeasurementsOperations.CalcVolume(
                parallelepiped.Width, parallelepiped.Height, parallelepiped.Depth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", MeasurementsOperations.CalcDiagonalXYZ(
                parallelepiped.Width, parallelepiped.Height, parallelepiped.Depth));
            Console.WriteLine("Diagonal XY = {0:f2}", MeasurementsOperations.CalcDiagonalXY(
                parallelepiped.Width, parallelepiped.Height));
            Console.WriteLine("Diagonal XZ = {0:f2}", MeasurementsOperations.CalcDiagonalXZ(
                parallelepiped.Width, parallelepiped.Depth));
            Console.WriteLine("Diagonal YZ = {0:f2}", MeasurementsOperations.CalcDiagonalYZ(
                parallelepiped.Height, parallelepiped.Depth));
        }
    }
}