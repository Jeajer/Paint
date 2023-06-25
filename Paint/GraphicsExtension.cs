using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paint.Entities;

namespace Paint
{
    public static class GraphicsExtension
    {
        private static float Height;
        private static float XScroll;
        private static float YScroll;
        private static float ScaleFactor;
        private static Pen extpen = new Pen(Color.Gray, 0);

        public static void SetParameters(this System.Drawing.Graphics g, float xscroll, float yscroll, float scalefactor, float height)
        {
            XScroll = xscroll;
            YScroll = yscroll;
            ScaleFactor = scalefactor;
            Height = height;
            extpen.DashPattern = new float[] { 1.5f / ScaleFactor, 2.0f / ScaleFactor };
        }

        public static void SetTransform(this System.Drawing.Graphics g)
        {
            g.PageUnit = GraphicsUnit.Millimeter;
            g.TranslateTransform(0, Height);
            g.ScaleTransform(ScaleFactor, -ScaleFactor);
            g.TranslateTransform(-XScroll/ScaleFactor, YScroll/ScaleFactor);
        }

        public static void DrawPoint(this System.Drawing.Graphics g, System.Drawing.Pen pen, Entities.Point point)
        {
            g.SetTransform();
            PointF p = point.Position.ToPointF;
            if (!point.IsSelected)
                g.DrawEllipse(pen, p.X - 1, p.Y - 1, 2, 2);
            else
                g.DrawEllipse(extpen, p.X - 1, p.Y - 1, 2, 2);
            g.ResetTransform();
        }

        public static void DrawLine(this System.Drawing.Graphics g, System.Drawing.Pen pen, Entities.Line line)
        {
            g.SetTransform();
            if(!line.IsSelected)
                g.DrawLine(pen, line.StartPoint.ToPointF, line.EndPoint.ToPointF);
            else
                g.DrawLine(extpen, line.StartPoint.ToPointF, line.EndPoint.ToPointF);
            g.ResetTransform();
        }

        public static void DrawCircle(this System.Drawing.Graphics g, System.Drawing.Pen pen, Entities.Circle circle)
        {
            float x = (float)(circle.Center.X - circle.Radius);
            float y = (float)(circle.Center.Y - circle.Radius);
            float d = (float)circle.Diameter;

            g.SetTransform();
            if(!circle.IsSelected)
                g.DrawEllipse(pen, x, y, d, d);
            else
                g.DrawEllipse(extpen, x, y, d, d);
            g.ResetTransform();
        }

        public static void DrawEllipse(this System.Drawing.Graphics g, System.Drawing.Pen pen, Entities.Ellipse ellipse)
        {
            g.SetTransform();
            g.TranslateTransform(ellipse.Center.ToPointF.X, ellipse.Center.ToPointF.Y);
            g.RotateTransform((float)ellipse.Rotation);
            if(!ellipse.IsSelected)
                g.DrawEllipse(pen, -(float)ellipse.MajorAxis, -(float)ellipse.MinorAxis, (float)ellipse.MajorAxis * 2, (float)ellipse.MinorAxis * 2);
            else
                g.DrawEllipse(extpen, -(float)ellipse.MajorAxis, -(float)ellipse.MinorAxis, (float)ellipse.MajorAxis * 2, (float)ellipse.MinorAxis * 2);
            g.ResetTransform();
        }

        public static void DrawEllipticalArc(this Graphics g, Pen pen, Ellipse ellipse)
        {
            g.SetTransform();
            g.TranslateTransform(ellipse.Center.ToPointF.X, ellipse.Center.ToPointF.Y);
            g.RotateTransform((float)ellipse.Rotation);
            RectangleF rect = new RectangleF(-(float)ellipse.MajorAxis, -(float)ellipse.MinorAxis, (float)ellipse.MajorAxis * 2, (float)ellipse.MinorAxis * 2);
            if(!ellipse.IsSelected)
                g.DrawArc(pen, rect, (float)ellipse.StartAngle, (float)ellipse.EndAngle);
            else
                g.DrawArc(extpen, rect, (float)ellipse.StartAngle, (float)ellipse.EndAngle);
            g.ResetTransform();
        }

        public static void DrawArc(this Graphics g, Pen pen, Arc arc)
        {
            float x = (float)(arc.Center.X - arc.Radius);
            float y = (float)(arc.Center.Y - arc.Radius);
            float d = (float)arc.Diameter;
            RectangleF rect = new RectangleF(x, y, d, d);

            g.SetTransform();
            try
            {
                if(!arc.IsSelected)
                    g.DrawArc(pen, rect, (float)arc.StartAngle, (float)arc.EndAngle);
                else
                    g.DrawArc(extpen, rect, (float)arc.StartAngle, (float)arc.EndAngle);
            }
            catch { }
            g.ResetTransform();
        }

        public static void DrawLwPolyline(this System.Drawing.Graphics g, System.Drawing.Pen pen, Entities.LwPolyline polyline)
        {
            foreach(EntityObject entity in polyline.Explode())
            {
                if(!polyline.IsSelected)
                    g.DrawEntity(pen, entity);
                else
                    g.DrawEntity(extpen, entity);
            }
            //PointF[] vertexes = new PointF[polyline.Vertexes.Count];
            //if(polyline.IsClosed)
            //{
            //    vertexes = new PointF[polyline.Vertexes.Count + 1];
            //    vertexes[polyline.Vertexes.Count] = polyline.Vertexes[0].Position.ToPointF;
            //}

            //for(int i=0;i<polyline.Vertexes.Count;i++)
            //{
            //    vertexes[i] = polyline.Vertexes[i].Position.ToPointF;
            //}

            //g.SetTransform();
            //g.DrawLines(pen, vertexes);
            //g.ResetTransform();
        }

        public static void DrawEntity(this System.Drawing.Graphics g, System.Drawing.Pen pen, Entities.EntityObject entity)
        {
            switch(entity.Type)
            {
                case EntityType.Arc:
                    g.DrawArc(pen, entity as Arc);
                    break;
                case EntityType.Ellipse:
                    if((entity as Ellipse).IsFullEllipse)
                    {
                        g.DrawEllipse(pen, entity as Ellipse);
                    }
                    else
                    {
                        g.DrawEllipticalArc(pen, entity as Ellipse);
                    }
                    break;
                case EntityType.Circle:
                    g.DrawCircle(pen, entity as Circle);
                    break;
                case EntityType.Line:
                    g.DrawLine(pen, entity as Line);
                    break;
                case EntityType.LwPolyline:
                    g.DrawLwPolyline(pen, entity as LwPolyline);
                    break;
                case EntityType.Point:
                    g.DrawPoint(pen, entity as Entities.Point);
                    break;
            }
        }

        #region Extended of modify
        public static void ExtendedOfModify(this Graphics g, Pen pen, int modifyIndex, List<EntityObject> entities, Vector3 fromPoint, Vector3 toPoint)
        {
            g.DrawLine(pen, new Line(fromPoint, toPoint));

            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].IsSelected)
                {
                    switch(modifyIndex)
                    {
                        case 0: //Copy
                        case 1: //Move
                            g.DrawEntity(pen, entities[i].CopyOrMove(fromPoint, toPoint) as EntityObject);
                            break;
                        case 2: //Rotate
                            g.DrawEntity(pen, entities[i].Rotate2D(fromPoint, toPoint) as EntityObject);
                            break;
                        case 3: //Mirror
                            g.DrawEntity(pen, entities[i].Mirror2D(fromPoint, toPoint) as EntityObject);
                            break;
                    }    
                }
            }
        }
        #endregion Extended of modify
    }
}
