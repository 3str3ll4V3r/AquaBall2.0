using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaBall2_0
{
    public class Pin
    {
        public VPoint punto;
        public int Id;
        public Pin(float x, float y, int Id, int width, int height)
        {
            punto = new VPoint(x, y, Id, width, height);
            punto.PinPoint();
            //punto.diameter /= Form1.divres;
            //punto.radius /= Form1.divres;
            //punto.image = Resource2.safeimagekit_pixel_art__4___2_;
            punto.isPin = true;
            Color c = Color.Gray;
            //punto.brush = new SolidBrush(c);
        }
    }
}
