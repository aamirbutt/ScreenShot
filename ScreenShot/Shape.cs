using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Screenshot
{
    abstract class Shape
    {
        public Pen pen { get; set; }
        public Brush brush { get; set; }
        public float LineWidth { get; set; }
        public Color color { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public bool Selected { get; set; }

        public abstract void Draw(Graphics g);

        public Shape()
        {
            LineWidth = 1.0f;
            color = Color.Black;
            pen = new Pen(Color.Black, 1.0f);
            brush = new SolidBrush(Color.Black);
            Selected = false;
        }
        public Shape(float lineWidth, Color drawColor, Point startPt, Point endPt)
        {
            pen = new Pen(drawColor, lineWidth);
            brush = new SolidBrush(drawColor);
            StartPoint = startPt;
            EndPoint = endPt;
            Selected = false;
        }

        public virtual Size GetShapeSize()
        {
            return new Size(this.EndPoint.X - this.StartPoint.X, this.EndPoint.Y - this.StartPoint.Y);
        }

        public virtual Rectangle GetShapeRect()
        {
            return new Rectangle(this.StartPoint, this.GetShapeSize());
        }

        public virtual int DistanceFromLeft(Point pt)
        {
            return pt.X - this.StartPoint.X;
        }

        public virtual int DistanceFromTop(Point pt)
        {
            return pt.Y - this.StartPoint.Y;
        }

        public virtual void AdjustPoints(Point pt, int leftDistance, int topDistance)
        {
            Point startPt = new Point(pt.X - leftDistance, pt.Y - topDistance);
            Point endPt = new Point(pt.X + GetShapeSize().Width - leftDistance, pt.Y + GetShapeSize().Height - topDistance);
            StartPoint = startPt;
            EndPoint = endPt;
        }

        public void DrawBoundingRect(Graphics g)
        {
            if (Selected)
            {
                Rectangle rect = GetShapeRect().NormalizeRect();
                rect.Inflate((int)this.pen.Width, (int)this.pen.Width);
                using (Pen pen = new Pen(Color.Black))
                {
                    pen.Width = pen.Width;
                    pen.DashCap = DashCap.Flat;
                    pen.DashPattern = new float[] { 1.0f, 1.0f };
                    g.DrawRectangle(pen, rect);
                }
            }
        }

        public virtual void RePositionShape(int horizontalShift, int verticalShift)
        {
            Point startPt = new Point(StartPoint.X + horizontalShift, StartPoint.Y + verticalShift);
            Point endPt = new Point(EndPoint.X + horizontalShift, EndPoint.Y + verticalShift);
            StartPoint = startPt;
            EndPoint = endPt;
        }

        public void ApplyRepositioning(System.Windows.Forms.Keys keys)
        {
            switch (keys)
            {
                case Keys.Up:
                    RePositionShape(0, -1);
                    break;
                case Keys.Down:
                    RePositionShape(0, 1);
                    break;
                case Keys.Left:
                    RePositionShape(-1, 0);
                    break;
                case Keys.Right:
                    RePositionShape(1, 0);
                    break;
                default:
                    return;
            }
        }
    }

    class MyPen : Shape
    {
        private List<Point> drawPoints;
        
        public MyPen(float lineWidth, Color drawColor)
        {
            pen.Width = lineWidth;
            pen.Color = drawColor;
            drawPoints = new List<Point>();
        }

        public void SetDrawPoints(List<Point> penPoints)
        {
            this.drawPoints.Clear();
            this.drawPoints.AddRange(penPoints);
        }

        public override void AdjustPoints(Point pt, int leftDistance, int topDistance)
        {
            Rectangle penRect = GetShapeRect();
            Point adjPt = new Point(pt.X - penRect.Left - leftDistance, pt.Y - penRect.Top - topDistance);

            RePositionShape(adjPt.X, adjPt.Y);
        }
        
        public override void Draw(Graphics g)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLines(drawPoints.ToArray());
            g.DrawPath(pen, path);
            DrawBoundingRect(g);
        }

        public override Size GetShapeSize()
        {
            if (drawPoints.Count == 0) return new Size(0, 0);
            
            var xMin = drawPoints.Select(pt => pt.X).Min();
            var yMin = drawPoints.Select(pt => pt.Y).Min();
            var xMax = drawPoints.Select(pt => pt.X).Max();
            var yMax = drawPoints.Select(pt => pt.Y).Max();

            return new Size(xMax - xMin, yMax - yMin);
        }

        public override Rectangle GetShapeRect()
        {
            if (drawPoints.Count == 0) return Rectangle.Empty;

            var xMin = drawPoints.Select(pt => pt.X).Min();
            var yMin = drawPoints.Select(pt => pt.Y).Min();
            var xMax = drawPoints.Select(pt => pt.X).Max();
            var yMax = drawPoints.Select(pt => pt.Y).Max();

            return new Rectangle(xMin, yMin, xMax-xMin, yMax-yMin);

        }

        public override int DistanceFromLeft(Point pt)
        {
            return pt.X - GetShapeRect().Left;
        }

        public override int DistanceFromTop(Point pt)
        {
            return pt.Y - GetShapeRect().Top;
        }

        public override void RePositionShape(int horizontalShift, int verticalShift)
        {
            Point[] ptArray = drawPoints.ToArray();
            for (int i = 0; i < drawPoints.Count; i++)
            {
                ptArray[i].X += horizontalShift;
                ptArray[i].Y += verticalShift;
            }
            drawPoints.Clear();
            drawPoints = ptArray.ToList();
        }
    }

    class MyText : Shape
    {
        private string text;
        private Font txtFont;
        public MyText(Font font, string drawText, Color drawColor, Point startPt, Point endPt)
        {
            text = drawText;
            txtFont = font;
            StartPoint = startPt;
            EndPoint = endPt;
            pen.Color = drawColor;
        }

        public override void Draw(Graphics g)
        {
            g.DrawString(text, txtFont, new SolidBrush(pen.Color), new RectangleF(StartPoint, new SizeF(EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y)));
            DrawBoundingRect(g);
        }
    }

    class Line : Shape
    {
        public Line(float lineWidth, Color drawColor, Point startPt, Point endPt)
        {
            pen.Width = lineWidth;
            pen.Color = drawColor;
            StartPoint = startPt;
            EndPoint = endPt;
        }

        public override void Draw(Graphics g)
        {
            g.DrawLine(pen, StartPoint, EndPoint);
            DrawBoundingRect(g);
        }
    }

    class MyRectangle : Shape
    {
        public MyRectangle(float lineWidth, Color drawColor, Point startPt, Point endPt)
        {
            pen.Width = lineWidth;
            pen.Color = drawColor;
            StartPoint = startPt;
            EndPoint = endPt;
        }
        public override void Draw(Graphics g)
        {
            Point start = StartPoint;
            Point end = EndPoint;
            Utility.NormalizePts(ref start, ref end);
            g.DrawRectangle(pen, new Rectangle(start.X, start.Y, end.X - start.X, end.Y - start.Y));
            DrawBoundingRect(g);
        }
    }

    class Arrow : Shape
    {
        public float ArrowWidth { get; set; }
        public Arrow(Color drawColor, Point startPT, Point endPT)
        {
            pen.Width = 2.0f;
            pen.Color = drawColor;
            StartPoint = startPT;
            EndPoint = endPT;
            ArrowWidth = 1.0f;
        }

        public override void Draw(Graphics g)
        {
            ArrowRenderer arrow = new ArrowRenderer();
            arrow.Width = ArrowWidth;
            arrow.FillArrowhead = false;
            Brush brush = new SolidBrush(pen.Color);
            try
            {
                arrow.DrawArrow(g, pen, brush, StartPoint, EndPoint);
                DrawBoundingRect(g);
            }
            finally
            {
                brush.Dispose();
            }
        }

        public override Rectangle GetShapeRect()
        {
            Rectangle rect = new Rectangle(this.StartPoint, this.GetShapeSize());
            Rectangle normalized = rect.NormalizeRect();
            normalized.Inflate((int)this.ArrowWidth/2, (int)this.ArrowWidth/2);
            return normalized;
        }
    }

    class MyCircle : Shape
    {
        public MyCircle(float lineWidth, Color drawColor, Point startPt, Point endPt)
        {
            pen.Width = lineWidth;
            pen.Color = drawColor;
            StartPoint = startPt;
            EndPoint = endPt;
        }

        public override void Draw(Graphics g)
        {
            Point start = StartPoint;
            Point end = EndPoint;
            Utility.NormalizePts(ref start, ref end);
            g.DrawEllipse(pen, new Rectangle(start.X, start.Y, end.X - start.X, end.Y - start.Y));
            DrawBoundingRect(g);
        }
    }
}
