using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Entities
{
    public class Circle : EntityObject
    {
        private Vector3 center;
        private double radius;
        private double thickness;

        public Circle() : this(Vector3.Zero, 1.0)
        { }

        public Circle(Vector3 center, double radius) : base(EntityType.Circle)
        {
            Center = center;
            Radius = radius;
            Thickness = 0.0;
        }

        public Vector3 Center
        {
            get { return center; }
            set { center = value; }
        }

        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

        public double Diameter
        {
            get { return Radius * 2.0; }
        }

        public override object CopyOrMove(Vector3 fromPoint, Vector3 toPoint)
        {
            Vector3 c = this.center.CopyOrMove(fromPoint, toPoint);

            return new Circle
            {
                Center = c,
                Radius = this.radius,
                Thickness = this.thickness,
                IsVisible = this.isVisible
            };
        }

        public override object Rotate2D(Vector3 basePoint, Vector3 targetPoint)
        {
            Vector3 c = this.center.Rotate2D(basePoint, targetPoint);

            return new Circle
            {
                Center = c,
                Radius = this.radius,
                Thickness = this.thickness,
                IsVisible = this.isVisible
            };
        }

        public override object Mirror2D(Vector3 basePoint, Vector3 targetPoint)
        {
            Vector3 c = this.center.Mirror2D(basePoint, targetPoint);

            return new Circle
            {
                Center = c,
                Radius = this.radius,
                Thickness = this.thickness,
                IsVisible = this.isVisible
            };
        }

        public override object Clone()
        {
            return new Circle()
            {
                Center = this.center,
                Radius = this.radius,
                Thickness = this.thickness,
                //EntityObject properties
                IsVisible = this.isVisible,
            };
        }
    }
}
