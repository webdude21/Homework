using System;
using System.IO;
using System.Linq;

namespace StructurePoint3D
{
    static class PathStorage
    {
        public static Path LoadPath(string filePath)
        {
            Path path = new Path();
            StreamReader SR = new StreamReader(filePath);
            using (SR)
            {
                string line = SR.ReadLine();

                while (line != null)
                {
                    double[] coordinates = line.Split(';').Select(x => Convert.ToDouble(x)).ToArray();
                    path.AddPoint(new Point3D(coordinates[0], coordinates[1], coordinates[2]));
                    line = SR.ReadLine();
                }
            }
            return path;
        }

        public static void SavePath(Path pathToSave, string filePath)
        {
            StreamWriter SW = new StreamWriter(filePath);
            using (SW)
            {
                SW.Write(pathToSave); 
            }
        }
    }
}
