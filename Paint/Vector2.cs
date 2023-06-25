using Paint.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public class Vector2
    {
        private double x;
        private double y;

        public Vector2(double x, double y) 
        { 
            this.x = x;
            this.y = y;
        }

        public static Vector2 Zero
        {
            get { return new Vector2(0, 0); }
        }

        public double X 
        { 
            get { return x; } 
            set { x = value; } 
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public static Vector2 UnitX
        {
            get { return new Vector2(1.0, 0.0); }
        }

        public static Vector2 UnitY
        {
            get { return new Vector2(0.0, 1.0); }
        }

        public static Vector2 NaN
        {
            get { return new Vector2(double.NaN, double.NaN); }
        }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.x;
                    case 1:
                        return this.y;
                    default:
                        throw (new ArgumentOutOfRangeException(nameof(index)));
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this.x = value;
                        break;
                    case 1:
                        this.y = value;
                        break;
                    default:
                        throw (new ArgumentOutOfRangeException(nameof(index)));
                }
            }
        }

        public static double DotProduct(Vector2 v1, Vector2 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }

        public static double CrossProduct(Vector2 v1, Vector2 v2)
        {
            return v1.X * v2.Y - v1.Y * v2.X;
        }

        public static double Angle(Vector2 v)
        {
            double angle = Math.Atan2(v.Y, v.X);
            if (angle < 0)
                return 2 * Math.PI + angle;
            return angle;
        }

        public double AngleWith(Vector2 v)
        {
            double angle = Math.Atan2(v.Y - this.y, v.X - this.x) * 180.0 / Math.PI;
            if (angle < 0)
                angle += 360.0;
            return angle;
        }

        public double Modulus()
        {
            return Math.Sqrt(DotProduct(this, this));
        }

        public void Normalize()
        {
            double m = Modulus();
            if (Method.IsZero(m, Method.Epsilon))
                throw new ArithmeticException("Can normalize a zero vector.");
            double m_inv = 1 / m;
            this.x *= m_inv;
            this.y *= m_inv;
        }

        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return Equals(v1, v2);
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return !Equals(v1, v2);
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.X, -v.Y);
        }

        public static Vector2 operator *(Vector2 v, double d)
        {
            return new Vector2(v.X * d, v.Y * d);
        }

        public static Vector2 operator *(double d, Vector2 v)
        {
            return new Vector2(v.X * d, v.Y * d);
        }

        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X * v2.X, v1.Y * v2.Y);
        }

        public static Vector2 operator /(Vector2 v, double d)
        {
            double inv = 1 / d;
            return v * inv;
        }

        public static Vector2 operator /(double d, Vector2 v)
        {
            return new Vector2(d / v.X, d / v.Y);
        }

        public static Vector2 operator /(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X / v2.X, v1.Y / v2.Y);
        }

        public double DistanceFrom(Vector2 v)
        {
            double dx = v.X - X;
            double dy = v.Y - Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public System.Drawing.PointF ToPointF
        {
            get { return new System.Drawing.PointF((float)X, (float)Y); }
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2)
                return this.Equals((Vector2)obj);
            return false;
        }

        public bool Equals(Vector2 v, double threshold)
        {
            return (Method.IsEqual(v.X, threshold) && Method.IsEqual(v.Y, threshold));
        }

        public bool Equals(Vector2 v)
        {
            return this.Equals(v, Method.Epsilon);
        }

        public static bool Equals(Vector2 v1, Vector2 v2, double threshold)
        {
            return v1.Equals(v2, threshold);
        }

        public static bool Equals(Vector2 v1, Vector2 v2)
        {
            return v1.Equals(v2, Method.Epsilon);
        }

        public Vector3 ToVector3
        {
            get { return new Vector3(this.x, this.y); }
        }

        public Vector2 Trancfer2D(double length, double angle)
        {
            double x = length * Math.Cos(angle * Math.PI / 180.0) + this.x;
            double y = length * Math.Sin(angle * Math.PI / 180.0) + this.y;

            return new Vector2(x, y);
        }

        public Vector2 CopyOrMove(Vector2 fromPoint, Vector2 toPoint)
        {
            double dx = toPoint.X - fromPoint.X;
            double dy = toPoint.Y - fromPoint.Y;

            return new Vector2(this.x + dx, this.y + dy);
        }

        public Vector2 Rotate2D(Vector2 basePoint, Vector2 targetPoint)
        {
            double angle = basePoint.AngleWith(targetPoint);
            double length = basePoint.DistanceFrom(this);
            angle += basePoint.AngleWith(this);

            double sin = Math.Sin(angle * Math.PI / 180.0);
            double cos = Math.Cos(angle * Math.PI / 180.0);

            double x = length * cos + basePoint.X;
            double y = length * sin + basePoint.Y;

            return new Vector2(x, y);
        }

        public Vector2 Mirror2D(Vector3 basePoint, Vector3 targetPoint)
        {
            double angle = basePoint.AngleWith(targetPoint);
            angle = 2 * angle - basePoint.AngleWith(this.ToVector3);
            double length = basePoint.DistanceFrom(this.ToVector3);

            double sin = Math.Sin(angle * Math.PI / 180.0);
            double cos = Math.Cos(angle * Math.PI / 180.0);

            double x = length * cos + basePoint.X;
            double y = length * sin + basePoint.Y;

            return new Vector2(x, y);
        }

        public override string ToString()
        {
            return string.Format("{0,0:F3}, {1,0:F3}", this.x, this.y);
        }
    }
}
