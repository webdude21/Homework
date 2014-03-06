using System;
using GeometryAPI;

namespace AcademyGeometry
{
    public class Cylinder : Figure, IAreaMeasurable, IVolumeMeasurable
    {

        public Cylinder(Vector3D bottom, Vector3D top, double radius)
            : base(top, bottom)
        {
            this.Radius = radius;
        }

        public Vector3D Top
        {
            get
            {
                return new Vector3D(this.vertices[0].X, this.vertices[0].Y, this.vertices[0].Z);
            }
        }

        public Vector3D Bottom
        {
            get
            {
                return new Vector3D(this.vertices[1].X, this.vertices[1].Y, this.vertices[1].Z);
            }
        }

        public double Radius { get; private set; }

        public override double GetPrimaryMeasure()
        {
            return this.GetVolume();
        }

        public double GetVolume()
        {
            return Math.PI * this.Radius * this.Radius * (this.Top - this.Bottom).Magnitude;
        }

        public double GetArea()
        {
            var baseArea = this.Radius * this.Radius * Math.PI;
            var topAndBottomArea = baseArea * 2;
            var basePerimeter = 2 * Math.PI * this.Radius;
            var sideArea = basePerimeter * (this.Top - this.Bottom).Magnitude;
            return sideArea + topAndBottomArea;
        }
    }
}