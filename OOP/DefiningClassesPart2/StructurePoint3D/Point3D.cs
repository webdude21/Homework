using System.Collections.Generic;

namespace StructurePoint3D
{
    struct Point3D
    {
        private double x;
        private double y;
        private double z;
        private static readonly Point3D O = new Point3D();

        public Point3D(double X, double Y, double Z)
        {
            this.x = X;
            this.y = Y;
            this.z = Z;
        }

        public static Point3D GetPointO
        {
            get { return O; }
        }

        public double X
        {
            get { return this.x; }
            set
            {
                this.x = value;
            }
        }
        public double Y
        {
            get { return this.y; }
            set
            {
                this.y = value;
            }
        }
        public double Z
        {
            get { return this.z; }
            set
            {
                this.z = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2}", x, y, z);
        }
    }
}
