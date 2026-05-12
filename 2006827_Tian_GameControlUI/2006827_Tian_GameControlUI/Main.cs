using GameControlUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;

namespace _2006827_Tian_GameControlUI
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private AnimatedTexture spriteTexture;
        private const float rotation = 0;
        private const float scale = 1f;
        private const float depth = 0.5f;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            spriteTexture = new AnimatedTexture(Vector2.Zero, rotation, scale, depth);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        private Viewport viewport;
        private Vector2 characterPos;
        private const int frames = 5;
        private const int columns = 11;
        private const int rows = 5;
        private const int framesPerSec = 10;

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            spriteTexture.Load(Content, "ArcherSheet", frames, columns, rows, framesPerSec);
            spriteTexture.Row = 0; // play first row
            viewport = _graphics.GraphicsDevice.Viewport;
            characterPos = new Vector2(viewport.Width / 2, viewport.Height / 2);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            // TODO: Add your update logic here
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            spriteTexture.UpdateFrame(elapsed);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            spriteTexture.DrawFrame(_spriteBatch, characterPos);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
