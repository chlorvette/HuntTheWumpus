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

        // player configuration
        private const float playerRotation = 0;
        private Vector2 playerScale = new Vector2(1f, 1f);
        private const float playerDepth = 0.5f;

        // tilemap configuration
        private Vector2 tileScale = new Vector2(2f, 2f);
        private int tilesetChoicesPerType = 12;
        private int tilesetTotalTypes = 13;
        private int tilesetTileDimensions = 16;
        private int tilemapWidthTiles = 25;
        private int tilemapHeightTiles = 15;
        private string tilesetKeyPath = @"..\..\..\Content\map\tilesetKey.txt";
        private string tilesetImageName = "map/Dungeon_Tileset";
        private string tilemapsLocation = @"..\..\..\Content\map\";

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            playerTexture = new AnimatedTexture(Vector2.Zero, playerRotation, playerScale, playerDepth);
            tilemapLayerZero = new Tilemap(Content, tilesetImageName, tilemapsLocation+ "tilemapLayer0Template.txt", tilesetTileDimensions, (tilemapHeightTiles, tilemapWidthTiles), tileScale, tilesetKeyPath, tilesetChoicesPerType, tilesetTotalTypes);
            tilemapLayerOne = new Tilemap(Content, tilesetImageName, tilemapsLocation + "tilemapLayer1Template.txt", tilesetTileDimensions, (tilemapHeightTiles, tilemapWidthTiles), tileScale, tilesetKeyPath, tilesetChoicesPerType, tilesetTotalTypes);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        private Viewport viewport;

        // player configuration
        private Vector2 characterPos;
        private SpriteEffects playerSpriteEffect;
        private int moveSpeed = 5;
        private const int frames = 5;
        private const int columns = 11;
        private const int rows = 5;
        private const int framesPerSec = 10;

        // setting initial values
        private bool isMoving = false;
        private bool movingLeft = false;

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            playerTexture.Load(Content, "ArcherSheet", frames, columns, rows, framesPerSec);
            playerTexture.Row = 0; // play first row (idling animation)

            tilemapLayerZero.Load(Content);
            tilemapLayerOne.Load(Content);

            viewport = _graphics.GraphicsDevice.Viewport;
            characterPos = new Vector2((viewport.Width / 2) - (playerTexture.FrameWidth / 2), (viewport.Height / 2) - (playerTexture.FrameHeight / 2));
        }

        protected override void Update(GameTime gameTime)
        {
            // keyboard input => player movement
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

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            playerTexture.UpdateFrame(elapsed);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White); // clear

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            tilemapLayerZero.Draw(_spriteBatch);
            tilemapLayerOne.Draw(_spriteBatch);
            playerTexture.DrawFrame(_spriteBatch, characterPos, playerSpriteEffect);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
