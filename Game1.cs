using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Topic_7___keyboard_input
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Random generator = new Random();

        Texture2D pacTexture;
        Rectangle pacLocation;

        KeyboardState keyboardState;
        KeyboardState oldState;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            pacLocation = new Rectangle(10, 10, 75, 75);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            pacTexture = Content.Load<Texture2D>("PacSleep");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            keyboardState = Keyboard.GetState();

            if(oldState.IsKeyUp(Keys.Space) && keyboardState.IsKeyDown(Keys.Space))
            {
                pacLocation.X = generator.Next(0, 726);
                pacLocation.Y = generator.Next(0, 426);
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                pacLocation.Y -= 5;
                pacTexture = Content.Load<Texture2D>("PacUp");
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                pacLocation.Y += 5;
                pacTexture = Content.Load<Texture2D>("PacDown");
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                pacLocation.X += 5;
                pacTexture = Content.Load<Texture2D>("PacRight");
            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                pacLocation.X -= 5;
                pacTexture = Content.Load<Texture2D>("PacLeft");
            }
            else
            {
                pacTexture = Content.Load<Texture2D>("PacSleep");
            }

            oldState = keyboardState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(pacTexture, pacLocation, Color.White);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}