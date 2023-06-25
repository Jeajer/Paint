using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Entities
{
    public class Ellipse : EntityObject
    {
        private Vector3 center;
        private double majorAxis;
        private double minorAxis;
        private double rotation;
        private double startAngle;
        private double endAngle;
        private double thickness;

        public Ellipse() : this(Vector3.Zero, 1.0, 0.5)
        {

        }

        public Ellipse(Vector3 center, double majoraxis, double minoraxis) : base(EntityType.Ellipse)
        {
            this.Center = center;
            this.MajorAxis = majoraxis;
            this.MinorAxis = minoraxis;
            this.StartAngle = 0.0;
            this.EndAngle = 360.0;
            this.Rotation = 0.0;
            this.Thickness = 0.0;
        }

        public Vector3 Center
        {
            get { return center; }
            set { center = value; }
        }

        public double MajorAxis
        {
            get { return majorAxis; }
            set { majorAxis = value; }
        }

        public double MinorAxis
        {
            get { return minorAxis; }
            set { minorAxis = value; }
        }

        public double Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public double StartAngle
        {
            get { return startAngle; }
            set { startAngle = value; }
        }

        public double EndAngle
        {
            get { return endAngle; }
            set { endAngle = value; }
        }

        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

        public bool IsFullEllipse
        {
            get { return Methods.Method.IsEqual(this.startAngle, this.endAngle, Methods.Method.Epsilon); }
        }

        public Vector3 MajorPoint
        {
            get
            {
                double x = this.majorAxis * Math.Cos(this.rotation * Math.PI / 180.0) + this.Center.X;
                double y = this.majorAxis * Math.Sin(this.rotation * Math.PI / 180.0) + this.Center.Y;

                return new Vector3(x, y);
            } 
        }

        public Vector3 MinorPoint
        {
            get
            {
                double x = this.minorAxis * Math.Cos((this.rotation + 90.0) * Math.PI / 180.0) + this.Center.X;
                double y = this.minorAxis * Math.Sin((this.rotation + 90.0) * Math.PI / 180.0) + this.Center.X;

                return new Vector3(x, y);
            }
        }

        public Vector3 StartPoint
        {
            get
            {
                double a = this.majorAxis;
                double b = this.minorAxis;
                double cos = Math.Cos(this.startAngle * Math.PI / 180.0);
                double sin = Math.Sin(this.startAngle * Math.PI / 180.0);
                double radius = a * a / Math.Sqrt(b * b * cos * cos + a * a * sin * sin);
                Vector3 c = this.center.Trancfer2D(radius, this.startAngle);

                return c.Rotate2D(this.center, this.rotation);
            }
        }

        public Vector3 EndPoint
        {
            get
            {
                double a = this.majorAxis;
                double b = this.minorAxis;
                double cos = Math.Cos((this.startAngle + this.endAngle) * Math.PI / 180.0);
                double sin = Math.Sin((this.startAngle + this.endAngle) * Math.PI / 180.0);
                double radius = a * a / Math.Sqrt(b * b * cos * cos + a * a * sin * sin);
                Vector3 c = this.center.Trancfer2D(radius, this.startAngle + this.endAngle);

                return c.Rotate2D(this.center, this.rotation);
            }
        }

        public override object CopyOrMove(Vector3 fromPoint, Vector3 toPoint)
        {
            Vector3 c = this.center.CopyOrMove(fromPoint, toPoint);

            return new Ellipse
            {
                Center = c,
                MajorAxis = this.majorAxis,
                MinorAxis = this.minorAxis,
                Rotation = this.rotation,
                StartAngle = this.startAngle,
                EndAngle = this.endAngle,
                Thickness = this.thickness,
                IsVisible = this.isVisible
            };
        }

        public override object Rotate2D(Vector3 basePoint, Vector3 targetPoint)
        {
            Vector3 c = this.center.Rotate2D(basePoint, targetPoint);
            double angle = basePoint.AngleWith(targetPoint) + this.Rotation;

            return new Ellipse
            {
                Center = c,
                MajorAxis = this.majorAxis,
                MinorAxis = this.minorAxis,
                Rotation = angle,
                StartAngle = this.startAngle,
                EndAngle = this.endAngle,
                Thickness = this.thickness,
                IsVisible = this.isVisible
            };
        }

        public override object Mirror2D(Vector3 basePoint, Vector3 targetPoint)
        {
            Vector3 c = this.center.Mirror2D(basePoint, targetPoint);
            Vector3 minorpoint = this.MinorPoint.Mirror2D(basePoint, targetPoint);
            Vector3 startpoint = this.StartPoint.Mirror2D(basePoint, targetPoint);
            Vector3 endpoint = this.EndPoint.Mirror2D(basePoint, targetPoint);
            double angle = c.AngleWith(minorpoint) + 90.0;

            double start = c.AngleWith(endpoint);
            double end = c.AngleWith(startpoint);

            end = (end > start) ? end - start : end - start + 360.0;
            start -= angle;

            return new Ellipse
            {
                Center = c,
                MajorAxis = this.majorAxis,
                MinorAxis = this.minorAxis,
                Rotation = angle,
                StartAngle = start,
                EndAngle = end,
                Thickness = this.thickness,
                IsVisible = this.isVisible
            };
        }

        public override object Clone()
        {
            return new Ellipse()
            {
                Center = this.center,
                MajorAxis = this.majorAxis,
                MinorAxis = this.minorAxis,
                Rotation = this.rotation,
                StartAngle= this.startAngle,
                EndAngle= this.endAngle,
                Thickness = this.thickness,
                //EntityObject properties
                IsVisible = this.isVisible,
            };
        }
    }
}
