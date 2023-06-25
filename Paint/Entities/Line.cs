using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Entities
{
    public class Line : EntityObject
    {
        private Vector3 startPoint;
        private Vector3 endPoint;
        private double thickness;

        public Line() : this(Vector3.Zero, Vector3.Zero)
        {

        }

        public Line(Vector3 startPoint, Vector3 endPoint) : base(EntityType.Line) 
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Thickness = 0.0;
        }

        public Vector3 StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }

        public Vector3 EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

        public double Length
        {
            get
            {
                double dx = endPoint.X - startPoint.X;
                double dy = endPoint.Y - startPoint.Y;
                double dz = endPoint.Z - startPoint.Z;

                return Math.Sqrt(dx * dx + dy * dy + dz * dz);
            }
        }

        public double Angle
        {
            get 
            { 
                double angle = Math.Atan2((endPoint.Y - startPoint.Y), (endPoint.X - startPoint.X)) * 180.0 / Math.PI;
                if(angle < 0) 
                    angle += 360.0;
                return angle;
            }
        }

        public override object CopyOrMove(Vector3 fromPoint, Vector3 toPoint)
        {
            Vector3 startpoint = this.startPoint.CopyOrMove(fromPoint, toPoint);
            Vector3 endpoint = this.endPoint.CopyOrMove(fromPoint, toPoint);

            return new Line
            {
                StartPoint = startpoint,
                EndPoint = endpoint,
                Thickness = this.thickness,
                IsVisible = this.isVisible
            };
        }

        public override object Rotate2D(Vector3 basePoint, Vector3 targetPoint)
        {
            Vector3 startpoint = this.startPoint.Rotate2D(basePoint, targetPoint);
            Vector3 endpoint = this.endPoint.Rotate2D(basePoint, targetPoint);

            return new Line
            {
                StartPoint = startpoint,
                EndPoint = endpoint,
                Thickness = this.thickness,
                IsVisible = this.isVisible
            };
        }

        public override object Mirror2D(Vector3 basePoint, Vector3 targetPoint)
        {
            Vector3 startpoint = this.startPoint.Mirror2D(basePoint, targetPoint);
            Vector3 endpoint = this.endPoint.Mirror2D(basePoint, targetPoint);

            return new Line
            {
                StartPoint = startpoint,
                EndPoint = endpoint,
                Thickness = this.thickness,
                IsVisible = this.isVisible
            };
        }

        public override object Clone()
        {
            return new Line()
            {
                StartPoint = this.startPoint,
                EndPoint = this.endPoint,
                Thickness = this.thickness,
                //EntityObject properties
                IsVisible = this.isVisible,
            };
        }
    }
}
