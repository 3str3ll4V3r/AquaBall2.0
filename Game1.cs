using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using static System.Formats.Asn1.AsnWriter;
using System.Threading;
using System.Threading.Tasks;
using AquaBall2_0;

namespace AquaBall2._0
{
    public class Game1 : Game
    {

        //public SpriteBatch _spriteBatch;
        Vector2 templesPosition;
        Vector2 skyPosition;
        // Texture2D background, L2;
        private float templesSpeed = -0.35f;
        private float skySpeed = 0.2f;
        int width, height;
        //  private GraphicsDeviceManager g;
        private bool isFollowingCaramelo = true;
        private bool isNewCarameloCreated = false;
        public SpriteBatch spriteBatchBackground;
        public SpriteBatch spriteBatchForeground;

        public Game1()
        {
            Global._graphics = new GraphicsDeviceManager(this);
            Global._graphics.IsFullScreen = true;
            width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            int div = 1;
            Global._graphics.PreferredBackBufferWidth = width / div;
            Global._graphics.PreferredBackBufferHeight = height / div;
            Global._graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
             Global.GraphicsDevice = GraphicsDevice;
            Global.Verlets = new VElement(2 * GraphicsDevice.Viewport.Width,
                GraphicsDevice.Viewport.Height);
            Global.cameraMono = new CameraMono(new Vec2(0, 0));
            Global.mousePosition = new Vec2(0, 0);
            Global.worldMousePosition = new Vec2(0, 0);
            Global.map2 = new Map2(new Size(2 * GraphicsDevice.Viewport.Width,
                GraphicsDevice.Viewport.Height),
                ref Global.caramelo, ref Global.Verlets);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Global._spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.galleta = Content.Load<Texture2D>("Ball2");
            Global.background = Content.Load<Texture2D>("Sky");

            Global.L2 = Content.Load<Texture2D>("pngwing.com");
            Global.pin = Content.Load<Texture2D>("pixil-frame-0 (19)");
            Global.avionL = Content.Load<Texture2D>("Galleta reposo izq");
            Global.avionLactive = Content.Load<Texture2D>("Galleta en avion izq");
            Global.avionR = Content.Load<Texture2D>("Avion reposo");
            Global.avionRactive = Content.Load<Texture2D>("Galleta en avion");
            Global.estrella = Content.Load<Texture2D>("pixil-frame-0 (12)");

            Global.unotex = Content.Load<Texture2D>("Uno (1)");
            Global.dostex = Content.Load<Texture2D>("Dos");
            Global.trestex = Content.Load<Texture2D>("tres");
            Global.font = Content.Load<SpriteFont>("MyFont");
            Global.pixelTexture = new Texture2D(GraphicsDevice, 1, 1);
            Global.pixelTexture.SetData(new[] { Color.White });
            Global.spriteCaramelo = new Sprite(Global.galleta, new Rectangle(0, 0, 40, 40));
            Global.spriteEstrella = new Sprite(Global.estrella, new Rectangle(0, 0, 40, 40));
            Global.spritePin = new Sprite(Global.pin, new Rectangle(0, 0, 40, 40));
            Global.spriteBubble = new Sprite(Global.bubbleTexture, new Rectangle(0, 0, 80, 80));
            Global.spriteLBubble = new Sprite(Global.avionL, new Rectangle(0, 0, 80, 80));
            Global.spriteRBubble = new Sprite(Global.avionR, new Rectangle(0, 0, 80, 80));
            Global.spriteLBubbleA = new Sprite(Global.avionLactive, new Rectangle(0, 0, 80, 80));
            Global.spriteRBubbleA = new Sprite(Global.avionRactive, new Rectangle(0, 0, 80, 80));


            spriteBatchBackground = new SpriteBatch(GraphicsDevice);
            spriteBatchForeground = new SpriteBatch(GraphicsDevice);


            spriteBatchBackground.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, Matrix.Identity);
            spriteBatchBackground.End();

            spriteBatchForeground.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, Matrix.Identity);
            spriteBatchForeground.End();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Global.Verlets.Update();


            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {

                isFollowingCaramelo = false;
                Global.cameraMono.Position.X += (Keyboard.GetState().IsKeyDown(Keys.Left) ? -10 : 10);
            }
            else if (!isNewCarameloCreated)
            {

                isFollowingCaramelo = true;
                Global.cameraMono.Follow(Global.caramelo.punto.pos, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            }

            MouseState mouseState = Mouse.GetState();
            Global.mousePosition.X = mouseState.X;
            Global.mousePosition.Y = mouseState.Y;
            Global.worldMousePosition.X = Global.mousePosition.X + Global.cameraMono.Position.X;
            Global.worldMousePosition.Y = Global.mousePosition.Y;

            if (mouseState.LeftButton == ButtonState.Pressed && Global.pelotas > 0 && !Global.clicked)
            {
                Global.clicked = true;
                Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);

                Global.map2.AddBall(mousePosition, new Size(2 * GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height),
                                    ref Global.caramelo, ref Global.Verlets);
                isNewCarameloCreated = true;
                Task.Delay(250).ContinueWith(t => changeClick());
            }
            else
            {
                isNewCarameloCreated = false;
                isFollowingCaramelo = false;
            }

            templesPosition.X += templesSpeed;

            if (templesPosition.X < width)
            {
                templesPosition.X %= width;
            }

            skyPosition.X += skySpeed;
            if (skyPosition.X > width)
            {
                skyPosition.X %= width;
            }

            base.Update(gameTime);
        }
        public void changeClick()
        {
            Global.clicked = false;
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatchBackground.Begin();

            Viewport viewport = GraphicsDevice.Viewport;
            int screenWidth = viewport.Width;
            int screenHeight = viewport.Height;

            spriteBatchBackground.Draw(Global.background, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            float scale = (float)screenWidth / Global.background.Width;

            spriteBatchBackground.Draw(Global.background, skyPosition, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0.9f);
            spriteBatchBackground.Draw(Global.L2, templesPosition, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0.9f);

            Global.Verlets.Render(spriteBatchBackground);

            spriteBatchBackground.End();

            base.Draw(gameTime);
        }
    }
}
