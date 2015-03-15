namespace StructurePoint3D
{
    using System;
    using System.Collections.Generic;

    internal class Path
    {
        private readonly List<Point3D> pointList = new List<Point3D>();

        public int Count
        {
            get
            {
                return this.pointList.Count;
            }
        }

        public void AddPoint(Point3D point)
        {
            this.pointList.Add(point);
        }

        public void RemovePoint(Point3D point)
        {
            this.pointList.Remove(point);
        }

        public void ClearPath()
        {
            this.pointList.Clear();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.pointList);
        }
    }
}