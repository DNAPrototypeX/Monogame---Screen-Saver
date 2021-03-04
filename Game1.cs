using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Pong
{
    public class Game1 : Game
    {
        Texture2D ballTexture;
        Vector2 ballPosition;
        Vector2 ballSpeed;
        Random rng = new Random();
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight / 2);
            ballSpeed = new Vector2(100, 100);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = Content.Load<Texture2D>("ball");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kState = Keyboard.GetState();

            ballPosition += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (ballPosition.X > _graphics.PreferredBackBufferWidth - ballTexture.Width / 2)
                ballSpeed.X = (float)((ballSpeed.X * -1) + (rng.Next(-10, 11) * rng.NextDouble()));
            else if (ballPosition.X < ballTexture.Width / 2)
                ballSpeed.X = (float)((ballSpeed.X * -1) + (rng.Next(-10, 11) * rng.NextDouble()));
            if (ballPosition.Y < ballTexture.Height / 2)
                ballSpeed.Y = (float)((ballSpeed.Y * -1) + (rng.Next(-10, 11) * rng.NextDouble()));
            else if (ballPosition.Y > _graphics.PreferredBackBufferHeight - ballTexture.Height / 2)
                ballSpeed.Y = (float)((ballSpeed.Y * -1) + (rng.Next(-10, 11) * rng.NextDouble()));
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(ballTexture, ballPosition, null,
                Color.White, 0f, new Vector2(ballTexture.Width / 2,
                ballTexture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
