using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Jay_Craft
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public BasicEffect basicEffect;
        public Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 3), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        public Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 1, 0.01f, 100f);
        float aspectRatio;
        Block block;
        public Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //graphics.PreferredBackBufferWidth = 1280;
            //graphics.PreferredBackBufferHeight = 720;
            //graphics.ApplyChanges();

            this.Window.AllowUserResizing = true;

            player = new Player(0, 0, 3);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            basicEffect = new BasicEffect(GraphicsDevice);

            block = new Block(0, 0, 0, this);
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            float deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;

            view = Matrix.CreateLookAt(player.position, Vector3.Zero, Vector3.Up);
            aspectRatio = graphics.GraphicsDevice.Viewport.Width / graphics.GraphicsDevice.Viewport.Height;
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), graphics.GraphicsDevice.Viewport.AspectRatio, 0.01f, 100f);

            block.Update(this);
            player.Update(this, deltaTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            block.Draw(this);

            base.Draw(gameTime);
        }
    }

    public enum State
    {
        Game
    }
}
