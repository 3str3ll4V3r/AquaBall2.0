using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AquaBall2_0
{
    public class Sprite
    {
        public Texture2D texture;
        public Vector2 position;
        public Microsoft.Xna.Framework.Rectangle rectangle;

        public Sprite(Texture2D texture, Microsoft.Xna.Framework.Rectangle rectangle)
        {
            this.texture = texture;
            this.rectangle = rectangle;
            this.position = new Vector2(rectangle.X, rectangle.Y);
        }


        public void UpdateSprite(float posX, float posY)
        {
            this.rectangle.X = (int)posX;
            this.rectangle.Y = (int)posY;
        }
    }
}
