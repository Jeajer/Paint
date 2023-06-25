using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Entities
{
    public class Point : EntityObject
    {
        private Vector3 position;
        private double thickness;

        public Point() : this(Vector3.Zero)
        {
             
        }

        public Point(Vector3 position) : base(EntityType.Point) 
        {
            Position = position;
            Thickness = 0.0;
        }

        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

        public Vector3 Position
        {
            get { return position; }
            set { position = value; }
        }

        public override object CopyOrMove(Vector3 fromPoint, Vector3 toPoint)
        {
            Vector3 p = this.position.CopyOrMove(fromPoint, toPoint);

            return new Entities.Point
            {
                Position = p,
                Thickness = this.thickness,
                IsVisible = this.IsVisible
            };
        }

        public override object Rotate2D(Vector3 basePoint, Vector3 targetPoint)
        {
            Vector3 p = this.position.Rotate2D(basePoint, targetPoint);

            return new Entities.Point
            {
                Position = p,
                Thickness = this.thickness,
                IsVisible = this.IsVisible
            };
        }

        public override object Mirror2D(Vector3 basePoint, Vector3 targetPoint)
        {
            Vector3 p = this.position.Mirror2D(basePoint, targetPoint);

            return new Entities.Point
            {
                Position = p,
                Thickness = this.thickness,
                IsVisible = this.IsVisible
            };
        }

        public override object Clone()
        {
            return new Point()
            {
                Position = this.position,
                Thickness = this.thickness,
                //EntityObject properties
                IsVisible = this.isVisible,
            };
        }
    }
}
