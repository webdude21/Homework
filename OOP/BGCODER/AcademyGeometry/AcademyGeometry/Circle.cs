using GeometryAPI;
using System;

namespace AcademyGeometry
{
    public class Circle : Figure, IAreaMeasurable, IFlat
    {
        public Circle(Vector3D center, double r)
            : base(center)
        {
            this.R = r;
        }

        public double R { get; private set; }


        public override double GetPrimaryMeasure()
        {
            return GetArea();
        }

        public double GetArea()
        {
            return this.R * this.R * Math.PI;
        }

        public Vector3D GetNormal()
        {
            // Жоре, не всички сме любители на геометрията :)

            Vector3D center = this.GetCenter();
            Vector3D A = new Vector3D(center.X + this.R, center.Y, center.Z),
                B = new Vector3D(center.X, center.Y + this.R, center.Z);

            Vector3D normal = Vector3D.CrossProduct(center - A, center - B);
            normal.Normalize();
            return normal;
        }
    }
}
