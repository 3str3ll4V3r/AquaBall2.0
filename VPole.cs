using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaBall2_0
{
    public class VPole
    {
        public VPoint startPoint, endPoint;
        public Vec2 middlepoint;
        //Pen thickPen;
        public float stiffness, length;
        Color c;

        public VPole(VPoint p1, VPoint p2, float length = 0)
        {
            Init(p1, p2, length);
        }
        public void Init(VPoint p1, VPoint p2, float length = 0)
        {
            //thickPen = new Pen(Color.Brown, 5);
            startPoint = p1;
            endPoint = p2;
            middlepoint = new Vec2((startPoint.pos.X + endPoint.pos.X) / 2, (startPoint.pos.Y + endPoint.pos.Y) / 2);
            stiffness = 10f;
            c = Color.Green;

            // Si no se proporciona la longitud, calcularla basándose en la posición
            if (length == 0)
            {
                this.length = startPoint.pos.Distance(endPoint.pos);
            }
            else
            {
                this.length = length;
            }
        }
        public void Update()
        {
            middlepoint = new Vec2((startPoint.pos.X + endPoint.pos.X) / 2, (startPoint.pos.Y + endPoint.pos.Y) / 2);
            float dx = endPoint.pos.X - startPoint.pos.X;
            float dy = endPoint.pos.Y - startPoint.pos.Y;

            float distance = startPoint.pos.Distance(endPoint.pos);

            float diff = (length - distance) / distance * stiffness;
            float offsetx = dx * diff * 0.1f;
            float offsety = dy * diff * 0.1f;

            float m1 = startPoint.Mass + endPoint.Mass;
            float m2 = startPoint.Mass / m1;
            m1 = endPoint.Mass / m1;

            if (!startPoint.IsPinned)
            {
                startPoint.pos.X -= offsetx * m1;
                startPoint.pos.Y -= offsety * m1;
            }
            if (!endPoint.IsPinned || !endPoint.IsCaramelo)
            {
                endPoint.pos.X += offsetx * m2;
                endPoint.pos.Y += offsety * m2;
            }

        }

    }
}
