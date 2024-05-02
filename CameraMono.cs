using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AquaBall2_0
{
    public class CameraMono
    {
        public Vec2 Position { get; private set; }

        // Inicializa la cámara centrada en un punto específico
        public CameraMono(Vec2 startPosition)
        {
            Position = startPosition;
        }

        // Actualiza la posición de la cámara para centrarla en un punto
        public void Follow(Vec2 targetPosition, int screenWidth, int screenHeight)
        {
            Position = new Vec2(targetPosition.X - screenWidth / 2, targetPosition.Y - screenHeight / 2);
        }

        public void ClampToArea(int width, int height, int GDW, int GDH)
        {
            Position.X = Math.Clamp(Position.X, 0, width - GDW);
            Position.Y = Math.Clamp(Position.Y, 0, height - GDH);
        }
    }
}
