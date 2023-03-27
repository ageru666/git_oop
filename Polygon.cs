using System.Drawing;

namespace Lab1_Voloshin.Geometry
{
    class Polygon
    {
        private PointF[] points; 
        private Triangle[] triangles; 
        private bool[] taken; 

        public Polygon(float[] points) 
        {
            if (points.Length % 2 == 1 || points.Length < 6)
                throw new Exception(); 

            this.points = new PointF[points.Length / 2]; 
            for (int i = 0; i < points.Length; i += 2)
                this.points[i / 2] = new PointF(points[i], points[i + 1]);

            triangles = new Triangle[this.points.Length - 2];

            taken = new bool[this.points.Length];

            Triangulate();
        }

        private void Triangulate() 
        {
            int trainPos = 0;
            int leftPoints = points.Length; 

            int ai = FindNextNotTaken(0);
            int bi = FindNextNotTaken(ai + 1);
            int ci = FindNextNotTaken(bi + 1);

            int count = 0; 

            while (leftPoints > 3)
            {
                if (IsLeft(points[ai], points[bi], points[ci]) && CanBuildTriangle(ai, bi, ci)) 
                {
                    triangles[trainPos++] = new Triangle(points[ai], points[bi], points[ci]); 
                    taken[bi] = true; 
                    leftPoints--;
                    bi = ci;
                    ci = FindNextNotTaken(ci + 1); 
                }
                else
                { 
                    ai = FindNextNotTaken(ai + 1);
                    bi = FindNextNotTaken(ai + 1);
                    ci = FindNextNotTaken(bi + 1);
                }

                if (count > points.Length * points.Length)
                {  
                    triangles = null;
                    break;
                }

                count++;
            }

            if (triangles != null) 
                triangles[trainPos] = new Triangle(points[ai], points[bi], points[ci]);
        }

        private int FindNextNotTaken(int startPos) /// take angle that wasn't processed
        {
            startPos %= points.Length;
            if (!taken[startPos])
                return startPos;

            int i = (startPos + 1) % points.Length;
            while (i != startPos)
            {
                if (!taken[i])
                    return i;
                i = (i + 1) % points.Length;
            }

            return -1;
        }

        private bool IsLeft(PointF a, PointF b, PointF c) ///
        {
            float abX = b.X - a.X;
            float abY = b.Y - a.Y;
            float acX = c.X - a.X;
            float acY = c.Y - a.Y;

            return abX * acY - acX * abY < 0;
        }

        private bool IsPointInside(PointF a, PointF b, PointF c, PointF p) 
        {
            float ab = (a.X - p.X) * (b.Y - a.Y) - (b.X - a.X) * (a.Y - p.Y);
            float bc = (b.X - p.X) * (c.Y - b.Y) - (c.X - b.X) * (b.Y - p.Y);
            float ca = (c.X - p.X) * (a.Y - c.Y) - (a.X - c.X) * (c.Y - p.Y);

            return (ab >= 0 && bc >= 0 && ca >= 0) || (ab <= 0 && bc <= 0 && ca <= 0);
        }

        private bool CanBuildTriangle(int ai, int bi, int ci) 
        {
            for (int i = 0; i < points.Length; i++) 
                if (i != ai && i != bi && i != ci) 
                    if (IsPointInside(points[ai], points[bi], points[ci], points[i]))
                        return false;
            return true;
        }

        public PointF[] GetPoints() 
        {
            return points;
        }

        public Triangle[] GetTriangles()
        {
            return triangles;
        }

        public double GetArea() 
        {
            if (triangles == null)
                return 0; 

            double s = 0;
            for (int i = 0; i < triangles.Length; i++) 
                s += triangles[i].GetArea();

            return s;
        }

    }
}
