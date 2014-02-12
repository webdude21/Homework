using System.Collections.Generic;
using System.Text;
using System;

namespace StructurePoint3D
{
    class Path
    {
        private List<Point3D> pointList = new List<Point3D>();

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

        public int Count { get { return this.pointList.Count; } }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.pointList);
        }
    }
}
