using Paint.Entities;
using Paint.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class GraphicsForm : Form
    {
        public GraphicsForm()
        {
            InitializeComponent();
        }

        #region Variables   
        private List<EntityObject> entities = new List<EntityObject>();
        private List<Ellipse> tempEllipse = new List<Ellipse>();
        private LwPolyline tempPolyline = new LwPolyline();
        // Vector
        private Vector3 currentPosition;
        private Vector3 firstPoint;
        private Vector3 secondPoint;
        private Vector3 thirdPoint;
        private Vector3 fourthPoint;
        private Vector3 panPoint;
        // System point
        private System.Drawing.Point firstCorner;
        private System.Drawing.Point startLocation;
        // int
        private int DrawIndex = -1;
        private int Modify1Index = -1;
        private int segmentIndex = -1;
        private int ClickNum = 1;
        private int ZoomClick = 1;
        private int cursorIndex = 0;
        private int direction;
        private int sidesQty = 5;
        private int inscribed = 1;
        // float
        private float XScroll;
        private float YScroll;
        private float ScaleFactor = 1.0f;
        private float cursorSize = 0;
        private float x1, x2, y1, y2;
        private float edit_cursorSize = 2.50f;
        private float draw_cursorSize = 15.0f;
        // bool
        private bool active_drawing = false;
        private bool active_zoom = false;
        private bool active_pan = false;
        private bool active_modify = false;
        private bool active_selection = true;
        // base size of drawing
        private SizeF drawingSize = new SizeF(1067, 346);
        #endregion Variables

        #region Mouse move
        private void drawing_MouseMove(object sender, MouseEventArgs e)
        {
            currentPosition = PointToCartesian(e.Location);
            coordinate.Text = string.Format("{0,0:F3}, {1,0:F3}, {1,0:F3}", currentPosition.X, currentPosition.Y, currentPosition.Z);

            if(active_pan)
            {
                float dx = (float)(currentPosition.X - panPoint.X);
                float dy = (float)(currentPosition.Y - panPoint.Y);

                XScroll -= dx * ScaleFactor;
                YScroll += dy * ScaleFactor;

                SetScrollBarValues();
            }

            x1 = e.Location.X;
            x2 = drawing.ClientSize.Width - x1;
            y1 = e.Location.Y;
            y2 = drawing.ClientSize.Height - y1;

            drawing.Refresh();
        }
        #endregion Mouse move

        #region Mouse up
        private void drawing_MouseUp(object sender, MouseEventArgs e)
        {
            if (active_pan)
            {
                active_pan = false;
                ActiveCursor(cursorIndex, cursorSize);
                int dx = e.Location.X - startLocation.X;
                int dy = e.Location.Y - startLocation.Y;

                firstCorner = new System.Drawing.Point(firstCorner.X + dx, firstCorner.Y + dy);
            }
        }
        #endregion Mouse up

        #region Mouse wheel
        private void drawing_MouseWheel(object sender, MouseEventArgs e)
        {
            float cx = drawing.ClientSize.Width / 2.0f;
            float cy = drawing.ClientSize.Height / 2.0f;

            float w = (x1 < cx) ? Math.Min(x1, x2) * 2.0f : Math.Max(x1, x2) * 2.0f;
            float h = (y1 < cy) ? Math.Max(y1, y2) * 2.0f : Math.Min(y1, y2) * 2.0f;

            float scale = (e.Delta < 0) ? 1 / 1.25f : 1.25f;

            ScaleFactor *= scale;

            float width = w * scale;
            float height = h * scale;

            float w1 = (w - width) / 2;
            float h1 = (h - height) / 2;

            XScroll = XScroll * scale - Pixel_to_Mn(w1);
            YScroll = YScroll * scale - Pixel_to_Mn(h1);

            SetScrollBarValues();
        }
        #endregion Mouse wheel

        #region Get DPI
        private float DPI
        {
            get
            {
                using (var g = CreateGraphics())
                    return g.DpiX;
            }
        }
        #endregion Get DPI

        #region Set active cursor
        private void ActiveCursor(int index, float size)
        {
            Cursor cursor = Cursors.Default;
            if (index > 0)
                cursor = new Cursor(Method.SetCursor(index, Mn_to_Pixel(size), Color.Red).GetHicon());
            drawing.Cursor = cursor;
        }
        #endregion Set active cursor

        #region Get cursor rectangle
        private PointF[] CursorRect(Vector3 mousePosition)
        {
            float l = edit_cursorSize * 0.5f;
            float x = mousePosition.ToPointF.X;
            float y = mousePosition.ToPointF.Y;

            return new PointF[]
            {
                new PointF(x - 1, y -1),
                new PointF(x + 1, y -1),
                new PointF(x + 1, y +1),
                new PointF(x - 1, y +1)
            };
        }
        #endregion Get cursor rectangle

        #region Zoom window
        private void SetZoomWin(System.Drawing.Point firstCorner, System.Drawing.Point secondCorner)
        {
            Vector3 p1 = PointToCartesian(firstCorner);
            Vector3 p2 = PointToCartesian(secondCorner);

            float minX = Math.Min(p1.ToPointF.X, p2.ToPointF.X);
            float minY = Math.Min(p1.ToPointF.Y, p2.ToPointF.Y);

            float w = Math.Abs(firstCorner.X - secondCorner.X);
            float h = Math.Abs(firstCorner.Y - secondCorner.Y);

            float width = drawing.ClientSize.Width / w;
            float height = drawing.ClientSize.Height / h;

            float min = Math.Min(width, height);

            ScaleFactor *= min;

            float w1 = (drawing.ClientSize.Width - w * min) / 2;
            float h1 = (drawing.ClientSize.Height - h * min) / 2;

            XScroll = ScaleFactor * minX - Pixel_to_Mn(w1);
            YScroll = -ScaleFactor * minY - Pixel_to_Mn(h1);

            SetScrollBarValues();
        }
        #endregion Zoom window

        #region Zoom in & out
        private void SetZoomInOut(int index)
        {
            float scale = (index == 1) ? 1 / 1.25f : 1.25f;

            ScaleFactor *= scale;

            float width = drawing.ClientSize.Width * scale;
            float height = drawing.ClientSize.Height * scale;

            float w1 = (drawing.ClientSize.Width - width) / 2;
            float h1 = (drawing.ClientSize.Height - height) / 2;

            XScroll = XScroll * scale - Pixel_to_Mn(w1);
            YScroll = YScroll * scale + Pixel_to_Mn(h1);

            SetScrollBarValues();
        }
        #endregion Zoom in & out

        #region Set zoom events
        private void ZoomEvents(int index)
        {
            switch(index)
            {
                case 0: // zoom in
                case 1: // zoom out
                    SetZoomInOut(index);
                    break;
                case 2: // zoom window
                    active_zoom = true;
                    if(active_drawing)
                    {
                        cursorIndex = 1;
                        cursorSize = 15;
                    }
                    else
                    {
                        cursorIndex = 0;
                        cursorSize = 0;
                    }
                    ActiveCursor(1, draw_cursorSize);
                    break;
            }
        }
        #endregion Set zoom events

        #region Set scroll bar values
        private void SetScrollBarValues()
        {
            float width = Math.Max(0, drawingSize.Width * ScaleFactor - Pixel_to_Mn(drawing.ClientSize.Width)) + 50 * ScaleFactor;
            float height = Math.Max(0, drawingSize.Height * ScaleFactor - Pixel_to_Mn(drawing.ClientSize.Height)) + 59 * ScaleFactor;

            hScrollBar.Maximum = (int)width;
            hScrollBar.Minimum = -(int)(50 * ScaleFactor);

            vScrollBar.Maximum = (int)(59 * ScaleFactor);
            vScrollBar.Minimum = -(int)height;

            try
            {
                hScrollBar.Minimum = (int)Math.Min(XScroll, hScrollBar.Minimum);
                hScrollBar.Maximum = (int)Math.Max(XScroll, hScrollBar.Maximum);
                vScrollBar.Minimum = (int)Math.Min(YScroll, vScrollBar.Minimum);
                vScrollBar.Maximum = (int)Math.Max(YScroll, vScrollBar.Maximum);

                hScrollBar.Value = (int)XScroll;
                vScrollBar.Value = (int)YScroll;
            }
            catch { }
            drawing.Refresh();
        }
        #endregion Set scroll bar values

        #region DeSelect all
        private void DeSelectAll()
        {
            foreach (EntityObject entity in entities)
            {
                entity.DeSelect();
            }
            drawing.Refresh();
        }
        #endregion DeSelect all

        #region Convert system point to wordl point
        private Vector3 PointToCartesian(System.Drawing.Point point)
        {
            return new Vector3((Pixel_to_Mn(point.X) + XScroll) / ScaleFactor, (Pixel_to_Mn(drawing.Height - point.Y) - YScroll) / ScaleFactor);
        }
        #endregion Convert system point to wordl point

        #region Convert pixels to milimeters
        private float Pixel_to_Mn(float pixel)
        {
            return pixel * 25.4f / DPI;
        }
        #endregion Convert pixels to milimeters 

        #region Convert milimeters to pixels
        private float Mn_to_Pixel(float pixel)
        {
            return pixel / 25.4f * DPI;
        }
        #endregion Convert milimeters to pixels

        #region Mouse down
        private void drawing_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle)
            {
                if (!active_pan)
                    startLocation = e.Location;
                active_pan = true;
                panPoint = currentPosition;
                drawing.Cursor = Cursors.Hand;
                if(active_drawing || active_zoom)
                {
                    cursorIndex = 1;
                    cursorSize = 15;
                }
                else
                {
                    cursorIndex = 0;
                    cursorSize = 0;
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                if (active_zoom)
                {
                    switch(ZoomClick)
                    {
                        case 1:
                            firstCorner = e.Location;
                            ZoomClick++;
                            break;
                        case 2:
                            SetZoomWin(firstCorner, e.Location);
                            ActiveCursor(cursorIndex, cursorSize);
                            active_zoom = false;
                            ZoomClick = 1;
                            break;
                    }
                }
                if (active_drawing)
                {
                    switch (DrawIndex)
                    {
                        case 0: //point
                            entities.Add(new Entities.Point(currentPosition));
                            break;
                        case 1: //line
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    //entity.Add(new Entities.Point(currentPosition));
                                    ClickNum++;
                                    break;
                                case 2:
                                    entities.Add(new Line(firstPoint, currentPosition));
                                    //entity.Add(new Entities.Point(currentPosition));
                                    firstPoint = currentPosition;
                                    //ClickNum = 1;
                                    break;
                            }
                            break;
                        case 21: //circle (Center, Radius)
                        case 22: //circle (Center, Diameter)
                        case 23: //Circle with 3 point
                        case 24: //Circle with 2 point
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 2:
                                    switch(DrawIndex)
                                    {
                                        case 21:
                                            double r = firstPoint.DistanceFrom(currentPosition);
                                            entities.Add(new Circle(firstPoint, r));
                                            CancelAll();
                                            break;
                                        case 22:
                                            r = firstPoint.DistanceFrom(currentPosition) / 2;
                                            entities.Add(new Circle(firstPoint, r));
                                            CancelAll();
                                            break;
                                        case 23:
                                            secondPoint = currentPosition;
                                            ClickNum++;
                                            break;
                                        case 24:
                                            entities.Add(Method.GetCircleWithTwoPoints(firstPoint, currentPosition));
                                            CancelAll();
                                            break;
                                    } 
                                    break;
                                case 3:
                                    entities.Add(Methods.Method.GetCircleWith3Points(firstPoint, secondPoint, currentPosition));
                                    CancelAll();
                                    break;
                            }
                            break;
                        case 31: //ellipse
                        case 32: //elliptical arc
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 2:
                                    secondPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 3:
                                    switch(DrawIndex)
                                    {
                                        case 31:
                                            Entities.Ellipse ellipse = Methods.Method.GetEllipse(firstPoint, secondPoint, currentPosition);
                                            entities.Add(ellipse);
                                            CancelAll();
                                            break;
                                        case 32:
                                            thirdPoint = currentPosition;
                                            tempEllipse.Add(Method.GetEllipse(firstPoint, secondPoint, thirdPoint));
                                            ClickNum++;
                                            break;
                                    }
                                    break;
                                case 4:
                                    fourthPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 5:
                                    entities.Add(Method.GetEllipticalArc(firstPoint, secondPoint, thirdPoint, fourthPoint, currentPosition));
                                    CancelAll();
                                    break;
                            }
                            break;
                        case 11: //Arc (3-point)
                        case 12: //Arc (Start, Center, End)
                        case 13: //Arc (Center, Start, End)
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 2:
                                    secondPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 3:
                                    Arc a = new Arc();
                                    switch(DrawIndex)
                                    {
                                        case 11: //3-point
                                            a = Methods.Method.GetArcWith3Points(firstPoint, secondPoint, currentPosition);
                                            break;
                                        case 12: //Start, Center, End
                                            a = Methods.Method.GetArcWithCenterStartEnd(secondPoint, firstPoint, currentPosition);
                                            break;
                                        case 13: //Center, Start, End
                                            a = Methods.Method.GetArcWithCenterStartEnd(firstPoint, secondPoint, currentPosition);
                                            break;
                                    }
                                    entities.Add(a);
                                    CancelAll();
                                    break;
                            }
                            break;
                        case 14: //Arc (Center, Start, Angle)
                        case 15: //Arc (Center, Start, Length)
                        case 16: //Arc (Start, End, Angle)
                        case 17: //Arc (Start, Center, Length)
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    entities.Add(new Entities.Point(firstPoint));
                                    ClickNum++;
                                    break;
                                case 2:
                                    secondPoint = currentPosition;
                                    entities.Add(new Entities.Point(secondPoint));
                                    using(var getValue = new EntryForms.GetDoubleValue())
                                    {
                                        switch(DrawIndex)
                                        {
                                            case 14:
                                            case 16:
                                                getValue.Title = "Angle";
                                                break;
                                            case 15:
                                            case 17:
                                                getValue.Title = "Length";
                                                break;
                                        }

                                        var result = getValue.ShowDialog();
                                        if(result == DialogResult.OK)
                                        {
                                            switch(DrawIndex)
                                            {
                                                case 14: // Center, Start, Angle
                                                    entities.Add(Method.GetArcWithCenterStartAngle(firstPoint, currentPosition, getValue.ResultValue));
                                                    break;
                                                case 15: // Center, Start, Length
                                                    entities.Add(Method.GetArcWithCenterStartLength(firstPoint, currentPosition, getValue.ResultValue));
                                                    break;
                                                case 16: // Start, End, Angle
                                                    entities.Add(Method.GetArcWithStartEndAngle(firstPoint, currentPosition, getValue.ResultValue));
                                                    break;
                                                case 17: // Start, Center, Length
                                                    entities.Add(Method.GetArcWithCenterStartLength(currentPosition, firstPoint, getValue.ResultValue));
                                                    break;
                                            }
                                        }
                                        CancelAll();
                                    }
                                    break;
                            }
                            break;
                        case 5: //LwPolyline
                            firstPoint = currentPosition;
                            tempPolyline.Vertexes.Add(new LwPolylineVertex(firstPoint.ToVector2));
                            ClickNum = 2;
                            break;
                        case 6: //Rectangle
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 2:
                                    entities.Add(Method.PointToRect(firstPoint, currentPosition, out direction));
                                    CancelAll();
                                    break;
                            }
                            break;
                        case 7: //Polygon
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    using (var setpolygon = new EntryForms.SetPolygonValuesForm())
                                    {
                                        var result = setpolygon.ShowDialog();
                                        if (result == DialogResult.OK)
                                        {
                                            sidesQty = setpolygon.SidesQty;
                                            inscribed = setpolygon.Inscribed;
                                        }
                                        else
                                            CancelAll();
                                    }
                                    break;
                                case 2:
                                    entities.Add(Method.GetPolygon(firstPoint, currentPosition, sidesQty, inscribed));
                                    CancelAll();
                                    break;
                            }
                            break;
                    }
                }

                if (active_modify)
                {
                    if(active_selection)
                        segmentIndex = Method.GetSegmentIndex(entities, currentPosition, CursorRect(currentPosition), out Vector3 clickPoint);
                    if(!active_selection)
                    {
                        switch (ClickNum)
                        {
                            case 1:
                                firstPoint = currentPosition;
                                ClickNum++;
                                break;
                            case 2:
                                switch (Modify1Index)
                                {
                                    case 0: //Copy object
                                        Method.Modify1Selection(Modify1Index, entities, firstPoint, currentPosition);
                                        break;
                                    case 1: //Move object
                                    case 2: //Rotate object
                                        Method.Modify1Selection(Modify1Index, entities, firstPoint, currentPosition);
                                        CancelAll();
                                        break;
                                    case 3: //Mirror
                                        if(MessageBox.Show("Erese source objects", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                            Method.Modify1Selection(Modify1Index, entities, firstPoint, currentPosition, true);
                                        else
                                            Method.Modify1Selection(Modify1Index, entities, firstPoint, currentPosition);
                                        CancelAll();
                                        break;
                                }
                                break;
                        }
                    }    
                }
                drawing.Refresh();
            }
        }
        #endregion Mouse down

        #region Paint
        Entities.Line extline = new Entities.Line();

        private void drawing_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetParameters(XScroll, YScroll, ScaleFactor, Pixel_to_Mn(drawing.Height));
            Pen pen = new Pen(Color.Blue, 0.1f);
            Pen extpen = new Pen(Color.Gray, 0.1f);
            extpen.DashPattern = new float[] { 1.0f / ScaleFactor, 2.0f / ScaleFactor};

            //Test distance from line
            //if(entity.Count > 0)
            //{
            //    foreach(EntityObject ent in entity)
            //    {
            //        if(ent is Line)
            //        {
            //            double d = Method.DistanceFromLine(ent as Line, currentPosition, out Vector3 v, true);
            //            e.Graphics.DrawPoint(new Pen(Color.Red, 1), new Entities.Point(v));
            //            Text = d.ToString(); 
            //        }    
            //    }    
            //}

            //foreach(EntityObject entity in entities)
            //{
            //    switch(entity.Type)
            //    {
            //        case EntityType.Line:
            //            Vector3 p;
            //            foreach(EntityObject entity1 in entities)
            //            {
            //                switch(entity1.Type)
            //                {
            //                    case EntityType.Ellipse:
            //                        List<Vector3> intersection = Method.LineEllipseIntersection(entity as Line, entity1 as Ellipse);
            //                        foreach(Vector3 v in intersection)
            //                        {
            //                            e.Graphics.DrawPoint(new Pen(Color.Red), new Entities.Point(v));
            //                        }
            //                        break;
            //                    case EntityType.Circle:
            //                        intersection = Method.LineCircleIntersection(entity as Line, entity1 as Circle);
            //                        foreach (Vector3 v in intersection)
            //                        {
            //                            e.Graphics.DrawPoint(new Pen(Color.Red), new Entities.Point(v));
            //                        }
            //                        break;
            //                    case EntityType.Arc:
            //                        intersection = Method.LineArcIntersection(entity as Line, entity1 as Arc);
            //                        foreach (Vector3 v in intersection)
            //                        {
            //                            e.Graphics.DrawPoint(new Pen(Color.Red), new Entities.Point(v));
            //                        }
            //                        break;
            //                }
            //            }
            //            break;
            //        case EntityType.Ellipse:
            //            double d = Method.DistancePointToEllipse(entity as Ellipse, currentPosition, out p);
            //            e.Graphics.DrawPoint(new Pen(Color.Red), new Entities.Point(p));
            //            e.Graphics.DrawLine(new Pen(Color.Gray, 0), new Line(p, currentPosition));
            //            Text = d.ToString();
            //            break;
            //        case EntityType.Circle:
            //            d = Method.DistancePointToCircle(entity as Circle, currentPosition, out p);
            //            e.Graphics.DrawPoint(new Pen(Color.Red), new Entities.Point(p));
            //            e.Graphics.DrawLine(new Pen(Color.Gray, 0), new Line(p, currentPosition));
            //            Text = d.ToString();
            //            break;
            //        case EntityType.Arc:
            //            d = Method.DistancePointToArc(entity as Arc, currentPosition, out p);
            //            e.Graphics.DrawPoint(new Pen(Color.Red), new Entities.Point(p));
            //            e.Graphics.DrawLine(new Pen(Color.Gray, 0), new Line(p, currentPosition));
            //            Text = d.ToString();
            //            break;
            //        case EntityType.LwPolyline:
            //            d = Method.DistancePointToLwPolyline(entity as LwPolyline, currentPosition, out p);
            //            e.Graphics.DrawPoint(new Pen(Color.Red), new Entities.Point(p));
            //            e.Graphics.DrawLine(new Pen(Color.Gray, 0), new Line(p, currentPosition));
            //            Text = d.ToString();
            //            break;
            //    }
            //}

            #region Drawing
            //Draw all entities
            if(entities.Count > 0)
            {
                foreach(EntityObject entities in entities)
                {
                    e.Graphics.DrawEntity(pen, entities);
                }    
            } 

            //Draw tempPolyline
            if (tempPolyline.Vertexes.Count > 1)
            {
                e.Graphics.DrawLwPolyline(pen, tempPolyline);
            }
            #endregion Drawing

            #region Extended
            //Draw line extended
            extline = new Entities.Line(firstPoint, currentPosition);

            //Draw tempEllipse
            if(tempEllipse.Count > 0)
            {
                foreach(Ellipse elp in tempEllipse)
                {
                    e.Graphics.DrawEllipse(extpen, elp);
                }    
            }
            switch (DrawIndex)
            {
                case 1: //Point
                    if (ClickNum == 2)
                    {
                        e.Graphics.DrawLine(extpen, extline);
                    }
                    break;
                case 21: //Circle (Center, Radius)
                case 22: //Circle (Center, Diameter)
                    if (ClickNum == 2)
                    {
                        e.Graphics.DrawLine(extpen, extline);
                        double r = firstPoint.DistanceFrom(currentPosition);
                        Circle circle = new Circle(firstPoint, r);
                        if(DrawIndex == 22)
                        {
                            circle = new Circle(firstPoint, r / 2);
                        }    
                        e.Graphics.DrawCircle(extpen, circle);
                    }
                    break;
                case 23: //Circle with 3 point
                    switch (ClickNum)
                    {
                        case 2:
                            e.Graphics.DrawLine(extpen, extline);
                            break;
                        case 3:
                            Entities.Circle circle = Methods.Method.GetCircleWith3Points(firstPoint, secondPoint, currentPosition);
                            e.Graphics.DrawCircle(extpen, circle);
                            break;
                    }
                    break;
                case 24: //Circle with 2 point
                    if (ClickNum == 2)
                    {
                        Circle c = Method.GetCircleWithTwoPoints(firstPoint, currentPosition);
                        e.Graphics.DrawCircle(extpen, c);
                    }
                    break;
                case 31: //Full Ellipse
                case 32: //Elliptical arc
                    switch(ClickNum)
                    {
                        case 2:
                        case 4:
                            e.Graphics.DrawLine(pen, extline);
                            break;
                        case 3:
                            e.Graphics.DrawLine(extpen, extline);
                            Ellipse ellipse = Method.GetEllipse(firstPoint, secondPoint, currentPosition);
                            e.Graphics.DrawEllipse(extpen, ellipse);
                            break;
                        case 5:
                            e.Graphics.DrawLine(extpen, extline);
                            Ellipse elp = Method.GetEllipticalArc(firstPoint, secondPoint, thirdPoint, fourthPoint, currentPosition);
                            e.Graphics.DrawEllipticalArc(pen, elp);
                            break;
                    }    
                    break;
                case 11: //Arc 3-point
                case 12: //Start, Center, End
                case 13: //Center, Start, End
                    switch (ClickNum)
                    {
                        case 2:
                            e.Graphics.DrawLine(extpen, extline);
                            break;
                        case 3:
                            Arc a = new Arc();
                            switch(DrawIndex)
                            {
                                case 11:
                                    a = Methods.Method.GetArcWith3Points(firstPoint, secondPoint, currentPosition);
                                    break;
                                case 12:
                                    extline = new Line(secondPoint, currentPosition);
                                    e.Graphics.DrawLine(extpen, extline);
                                    a = Methods.Method.GetArcWithCenterStartEnd(secondPoint, firstPoint, currentPosition);
                                    break;
                                case 13:
                                    e.Graphics.DrawLine(extpen, extline);
                                    a = Methods.Method.GetArcWithCenterStartEnd(firstPoint, secondPoint, currentPosition);
                                    break;
                            }    
                            e.Graphics.DrawArc(extpen, a);
                            break;
                    }
                    break;
                case 14: //Arc (Center, Start, Angle)
                case 15: //Arc (Center, Start, Length)
                case 16: //Arc (Start, End, Angle)
                case 17: //Arc (Start, Center, Length)
                    if (ClickNum == 2)
                    {
                        e.Graphics.DrawLine(extpen, extline);
                    }
                    break;
                case 5: //Polyline
                    if (ClickNum == 2)
                    {
                        e.Graphics.DrawLine(extpen, extline);
                    }
                    break;
                case 6: //Rectangle
                    if (ClickNum == 2)
                    {
                        LwPolyline lw = Method.PointToRect(firstPoint, currentPosition, out direction);
                        e.Graphics.DrawLwPolyline(extpen, lw);
                    }
                    break;
                case 7: //Polygon
                    if (ClickNum == 2)
                    {
                        e.Graphics.DrawLine(extpen, extline);
                        LwPolyline lw = Method.GetPolygon(firstPoint, currentPosition, sidesQty, inscribed);
                        e.Graphics.DrawLwPolyline(extpen, lw);
                    }
                    break;
            }
            #endregion Extended   

            #region Extended of modify
            if (active_modify)
            {
                switch (ClickNum)
                {
                    case 2:
                        e.Graphics.ExtendedOfModify(extpen, Modify1Index, entities, firstPoint, currentPosition);
                        break;
                }
            }
            #endregion Extended of modify

            #region draw zoom rect
            if (active_zoom && !active_pan)
            {
                switch(ZoomClick)
                {
                    case 2:
                        LwPolyline rect = Method.PointToRect(PointToCartesian(firstCorner), currentPosition, out direction);
                        e.Graphics.DrawLwPolyline(new Pen(Color.Red), rect);
                        break;
                }
            }    
            #endregion draw zoom rect
        }
        #endregion Paint

        #region Cancel all command
        private void CancelAll(int index = 1)
        {
            DrawIndex = -1;
            active_drawing = false;
            active_selection = true;
            active_modify = false;
            ActiveCursor(0, 0);
            ClickNum = 1;
            LwPolylineCloseStatus(index);
            tempEllipse.Clear();
            DeSelectAll();
        }
        #endregion Cancel all command

        #region Cancel button
        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelAll();
        }
        #endregion Cancel button

        #region Draw buttons
        private void DrawBtn_Click(object sender, EventArgs e)
        {
            var item = sender as RibbonButton;
            DrawIndex = drawPanel.Items.IndexOf(item);
            active_drawing = true;
            ActiveCursor(1, draw_cursorSize);
        }
        #endregion Draw buttons

        #region Circle button
        private void CircleBtn_Click(object sender, EventArgs e)
        {
            var item = sender as RibbonButton;
            DrawIndex = circleBtn.DropDownItems.IndexOf(item) + 21;
            active_drawing = true;
            ActiveCursor(1, draw_cursorSize);
        }
        #endregion Circle button

        #region Arc button
        private void ArcBtn_Click(object sender, EventArgs e)
        {
            var item = sender as RibbonButton;
            DrawIndex = arcBtn.DropDownItems.IndexOf(item) + 11;
            active_drawing = true;
            ActiveCursor(1, draw_cursorSize);
        }
        #endregion Arc 

        #region Ellipse button
        private void EllipseBtn_Click(object sender, EventArgs e)
        {
            var item = sender as RibbonButton;
            DrawIndex = ellipseBtn.DropDownItems.IndexOf(item) + 31;
            active_drawing = true;
            ActiveCursor(1, draw_cursorSize);
        }
        #endregion Arc button

        #region Horizontal scroll bar
        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            XScroll = (sender as HScrollBar).Value;
            drawing.Refresh();
        }
        #endregion Horizontal scroll bar

        #region Vertical scroll bar
        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            YScroll = (sender as VScrollBar).Value;
            drawing.Refresh();
        }
        #endregion Vertical scroll bar

        #region zoom buttons click
        private void ZoomBtn_Click(Object sender, EventArgs e)
        {
            var item = sender as RibbonButton;
            int index = zoomPanel.Items.IndexOf(item);
            ZoomEvents(index);
        }
        #endregion zoom buttons click

        #region Modify button event
        private void ModifyBtn_Click(object sender, EventArgs e)
        {
            var item = sender as RibbonButton;
            Modify1Index = editPanel.Items.IndexOf(item);
            active_modify = true;
            ActiveCursor(2, edit_cursorSize);
            SetModifyPopup();
        }
        #endregion Modify button event

        #region Custom popup menu
        private ToolStripMenuItem toolitem;

        #region Set Modify popup
        private void SetModifyPopup()
        {
            popup.Items.Clear();

            toolitem = new ToolStripMenuItem("Enter");
            toolitem.Click += new EventHandler(EnterBtn_Click);
            popup.Items.Add(toolitem);

            toolitem = new ToolStripMenuItem("Cancel");
            toolitem.Click += new EventHandler(cancelToolStripMenuItem_Click);
            popup.Items.Add(toolitem);
        }

        private void EnterBtn_Click(object sender, EventArgs e)
        {
            active_selection = false;
            ActiveCursor(1, draw_cursorSize);
        }
        #endregion Set Modify popup
        #endregion Custom popup menu

        private void closeBoundary_Click(object sender, EventArgs e)
        {
            switch (DrawIndex)
            {
                case 3: //Line
                    break;
                case 4: //Polyline
                    CancelAll(2);
                    break;
            }
        }

        private void LwPolylineCloseStatus(int index)
        {
            List<LwPolylineVertex> vertexes = new List<LwPolylineVertex>();
            foreach (LwPolylineVertex lw in tempPolyline.Vertexes)
            {
                vertexes.Add(lw);
            }
            if (vertexes.Count > 1)
            {
                switch (index)
                {
                    case 1:
                        if (vertexes.Count > 2)
                        {
                            entities.Add(new LwPolyline(vertexes, true));
                        }
                        else
                        {
                            entities.Add(new LwPolyline(vertexes, false));
                        }
                        break;
                    case 2:
                        entities.Add(new LwPolyline(vertexes, false));
                        break;
                }
            }
            tempPolyline.Vertexes.Clear();
        }
    }
}
