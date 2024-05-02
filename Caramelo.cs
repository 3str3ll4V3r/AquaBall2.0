using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaBall2_0
{
    public class Caramelo
    {
        public VPoint punto;
        public int Id;
        public Caramelo(float x, float y, int Id, int width, int height)
        {
            punto = new VPoint(x, y, Id, width, height);
            Color c = Color.Red;
            //punto.brush = new SolidBrush(c);
            //punto.image = Resource2.pixil_frame_0__9_;
            punto.IsCaramelo = true;
            punto.isActive = true;
            //punto.diameter /= Form1.divres;
            //punto.radius /= Form1.divres;
        }
    }
}
