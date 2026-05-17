using GameControlUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;

namespace _2006827_Tian_GameControlUI
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private AnimatedTexture playerTexture;
        private Tilemap tilemapLayerZero;
        private Tilemap tilemapLayerOne;
        private const float rotation = 0;
        private Vector2 scale = new Vector2(1f, 1f);
        private const float depth = 0.5f;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            playerTexture = new AnimatedTexture(Vector2.Zero, rotation, scale, depth);
            tilemapLayerZero = new Tilemap(Content, "map/Dungeon_Tileset", @"..\..\..\Content\map\tilemapLayer0Template.txt", 16, (15, 25), new Vector2(2f, 2f), @"..\..\..\Content\map\tilesetKey.txt", 12, 7);
            tilemapLayerOne = new Tilemap(Content, "map/Dungeon_Tileset", @"..\..\..\Content\map\tilemapLayer1Template.txt", 16, (15, 25), new Vector2(2f, 2f), @"..\..\..\Content\map\tilesetKey.txt", 12, 7);

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        private Viewport viewport;
        private Vector2 characterPos;
        private SpriteEffects playerSpriteEffect;
        private int moveSpeed = 5;
        private const int frames = 5;
        private const int columns = 11;
        private const int rows = 5;
        private const int framesPerSec = 10;
        private bool isMoving = false;
        private bool movingLeft = false;

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            playerTexture.Load(Content, "ArcherSheet", frames, columns, rows, framesPerSec);
            playerTexture.Row = 0; // play first row
            tilemapLayerZero.Load(Content, "map/Dungeon_Tileset");
            tilemapLayerOne.Load(Content, "map/Dungeon_Tileset");
            viewport = _graphics.GraphicsDevice.Viewport;
            characterPos = new Vector2(viewport.Width / 2, viewport.Height / 2);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Back))
            {
                Exit();
            }
            isMoving = false;
            if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
            {
                if (characterPos.Y > -15)
                {
                    characterPos.Y -= moveSpeed;
                }
                isMoving = true;
            }
            if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            {
                if (characterPos.X > -10)
                {
                    characterPos.X -= moveSpeed;
                }
                isMoving = true;
                movingLeft = true;
            }
            if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
            {
                if ((characterPos.Y + playerTexture.FrameHeight + moveSpeed) < viewport.Height)
                {
                    characterPos.Y += moveSpeed;
                }
                isMoving = true;
            }
            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                if ((characterPos.X + playerTexture.FrameWidth + moveSpeed - 20) < viewport.Width)
                {
                    characterPos.X += moveSpeed;
                }
                isMoving = true;
                movingLeft = false;
            }

            if (isMoving)
            {
                playerTexture.Row = 2; // walk animation
            } else
            {
                playerTexture.Row = 0; // idle animation
            }

            if (movingLeft)
            {
                playerSpriteEffect = SpriteEffects.FlipHorizontally;
            } else
            {
                playerSpriteEffect = SpriteEffects.None;
            }

            // TODO: Add your update logic here
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            playerTexture.UpdateFrame(elapsed);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            tilemapLayerZero.Draw(_spriteBatch);
            tilemapLayerOne.Draw(_spriteBatch);
            playerTexture.DrawFrame(_spriteBatch, characterPos, playerSpriteEffect);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
