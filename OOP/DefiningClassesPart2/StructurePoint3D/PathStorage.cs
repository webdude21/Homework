namespace StructurePoint3D
{
    using System;
    using System.IO;
    using System.Linq;

    internal static class PathStorage
    {
        public static Path LoadPath(string filePath)
        {
            var path = new Path();
            var SR = new StreamReader(filePath);
            using (SR)
            {
                var line = SR.ReadLine();

                while (line != null)
                {
                    var coordinates = line.Split(';').Select(Convert.ToDouble).ToArray();
                    path.AddPoint(new Point3D(coordinates[0], coordinates[1], coordinates[2]));
                    line = SR.ReadLine();
                }
            }
            return path;
        }

        public static void SavePath(Path pathToSave, string filePath)
        {
            var SW = new StreamWriter(filePath);
            using (SW)
            {
                SW.Write(pathToSave);
            }
        }
    }
}