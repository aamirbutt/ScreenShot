using System;
using System.Drawing;
using System.Xml.Serialization;

namespace Screenshot
{
    public class ArrowRenderer
    {
        #region Properties

        private float width = 15;
        /// <summary>
        /// Gets or sets width (in pixels) of the full base of the arrowhead
        /// </summary>
        /// <value>The width.</value>
        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        private float theta = 0.5f;
        /// <summary>
        /// Gets or sets angle (in radians) at the arrow tip between the two sides of the arrowhead
        /// </summary>
        /// <value>The theta.</value>
        public float Theta
        {
            get { return theta; }
            set { theta = value; }
        }

        public void SetThetaInDegrees(float degrees)
        {
            if (degrees <= 0) degrees = 1;
            if (degrees >= 180) degrees = 179;
            theta = (float)Math.PI / 180 * degrees;
        }

        private bool fillArrowhead = true;
        /// <summary>
        /// Gets or sets flag indicating whether or not the arrowhead should be filled
        /// </summary>
        /// <value><c>true</c> if arrow head should be filled; otherwise, <c>false</c>.</value>
        public bool FillArrowhead
        {
            get { return fillArrowhead; }
            set { fillArrowhead = value; }
        }

        private int numberOfBezierCurveNodes = 100;
        /// <summary>
        /// Gets or sets the number of nodes used to calculate bezier curve.
        /// </summary>
        /// <value>The number of bezier curve nodes.</value>
        public int NumberOfBezierCurveNodes
        {
            get { return numberOfBezierCurveNodes; }
            set
            {
                if (value > 4) numberOfBezierCurveNodes = value;
            }
        }

        #endregion

        #region Constructors

        public ArrowRenderer() { }

        public ArrowRenderer(float width)
        {
            this.width = width;
        }

        public ArrowRenderer(float width, float theta)
        {
            this.width = width;
            this.theta = theta;
        }

        public ArrowRenderer(float width, float theta, bool fillArrowhead)
        {
            this.width = width;
            this.theta = theta;
            this.fillArrowhead = fillArrowhead;
        }

        public ArrowRenderer(float width, float theta, bool fillArrowhead, int numberOfBezierCurveNodes)
        {
            this.width = width;
            this.theta = theta;
            this.fillArrowhead = fillArrowhead;
            this.numberOfBezierCurveNodes = numberOfBezierCurveNodes;
        }

        #endregion

        #region DrawArrow
        /// <summary>
        /// Renders the arrow on given graphics using desired paramethers.
        /// </summary>
        /// <param name="graphics">The grahpics object.</param>
        /// <param name="pen">The pen of the stroke.</param>
        /// <param name="brush">The brush of the fill.</param>
        /// <param name="first">Initial point.</param>
        /// <param name="second">Terminal point.</param>
        public void DrawArrow(Graphics graphics, Pen pen, Brush brush, PointF first, PointF second)
        {
            if (graphics == null)
                throw new ArgumentException("Please provide a valid Graphics object");
            PointF[] ptArr = new PointF[6];

            Vector vecLine = new Vector(second.X - first.X, second.Y - first.Y);// build the line vector
            Vector vecLeft = new Vector(-vecLine[1], vecLine[0]);// build the arrow base vector - normal to the line

            //float midPointWidth = arrowWidth / 5.0f;
            Vector vecLeftFirst = new Vector(-vecLine[1] * 0.2f, vecLine[0] * 0.2f);

            // setup remaining arrow head points
            float lineLength = vecLine.Length;
            float th = Width / (2.0f * lineLength);
            float ta = Width / (2.0f* ((float)Math.Tan(Theta / 2.0f)) * lineLength);

            // find the base of the arrow
            PointF pBase = new PointF(second.X + -ta * vecLine[0], second.Y + -ta * vecLine[1]); //base of the arrow

            //get intermediate points
            ptArr[1] = new PointF(pBase.X + th * vecLeftFirst[0], pBase.Y + th * vecLeftFirst[1]);
            ptArr[5] = new PointF(pBase.X + -th * vecLeftFirst[0], pBase.Y + -th * vecLeftFirst[1]);
            
            // build the points on the sides of the arrow
            ptArr[2] = new PointF(pBase.X + th * vecLeft[0], pBase.Y + th * vecLeft[1]);
            ptArr[4] = new PointF(pBase.X + -th * vecLeft[0], pBase.Y + -th * vecLeft[1]);
            ptArr[0] = first;
            ptArr[3] = second;

            //g.FillPolygon(new SolidBrush(pen.Color), ptArr);
            graphics.FillPolygon(brush, ptArr);
            graphics.DrawPolygon(pen, ptArr); //draw outline
        }
        #endregion
    }
}