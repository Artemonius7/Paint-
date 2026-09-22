using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paint
{
    internal class ArrayPoints
    {
        private Point[] points;
        private int i;
        public static bool flag = false;
        public ArrayPoints()
        {
            points = new Point[2];
            i = 0;
        }
        public void SetPoints(int x,int y)
        {
            if (i >= points.Length) i = 0;
            points[i] = new Point(x, y);
            ++i;
        }
        public void ResetPoints()
        {
            i = 0;
        }
        public int I
        {
            get { return i; }
        }
        public Point[] Points
        {
            get { return points; }
        }
    }
}
