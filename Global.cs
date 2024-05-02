using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;


namespace AquaBall2_0
{
    public class Global
    {
        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static float ElapsedSeconds { get; set; }

        public static void Update(GameTime gameTime)
        {
            ElapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }



        public static GraphicsDevice GraphicsDevice;
        public static bool lost = false;
        public static bool won = false;
        public static int puntaje = 0;
        public static int currentLevel = 0;
        public static int pelotas = 10;
        public static bool clicked = false;

        public static Caramelo caramelo;
        public static Map2 map2;
        public static CameraMono cameraMono;
        public static GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        public static Texture2D galleta, pixelTexture, background, bubbleTexture, monstruoTexture,
            monstruoTextureAbre, L1, L2, pin, felicidades, avionLactive, estrella, avionL,
            avionR, avionRactive, puntajetex, unotex, dostex, trestex;
        public static Sprite spriteCaramelo, spriteEstrella, spritePin, spriteBubble, spriteLBubble,
            spriteRBubble, spriteLBubbleA, spriteRBubbleA;
        public static SpriteFont font;
        public static VElement Verlets;
        public static Vec2 mousePosition;
        public static Vec2 worldMousePosition;
        public static int thickness = 5;
        public static Color color = Color.Brown;
        public static bool start;


    }
}
