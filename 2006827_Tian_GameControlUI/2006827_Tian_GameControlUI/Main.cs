using GameControlUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Cave = CaveGeneration.Cave;
using Room = CaveGeneration.Room;
using GameLocation = GameLocations.GameLocations;
using System.Collections.Generic;

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
        private const string playerAsset = "ArcherSheet";

        // tilemap configuration
        private Vector2 tileScale = new Vector2(2f, 2f);
        private int tilesetChoicesPerType = 12;
        private int tilesetTotalTypes = 15;
        private int tilesetTileDimensions = 16;
        private int tilemapWidthTiles = 25;
        private int tilemapHeightTiles = 15;
        private string tilesetKeyPath = @"..\..\..\Content\map\tilesetKey.txt";
        private string tilesetImageName = "map/Dungeon_Tileset";
        private string tilemapsLocation = @"..\..\..\Content\map\";

        private Rectangle[] doorRectangles;
        private string[] doorDirections;

        private int caveHeight = 5;
        private int tunnelsPerRoom = 3;
        private int caveWidth = 6;
        private Cave cave;
        private Room currentRoom;
        private bool movingToNextRoom = false;
        private GameLocation gameLocation;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            playerTexture = new AnimatedTexture(Vector2.Zero, playerRotation, playerScale, playerDepth);
            tilemapLayerZero = new Tilemap(Content, tilesetImageName, tilemapsLocation+ "tilemapLayer0Template.txt", tilesetTileDimensions, (tilemapHeightTiles, tilemapWidthTiles), tileScale, tilesetKeyPath, tilesetChoicesPerType, tilesetTotalTypes);
            tilemapLayerOne = new Tilemap(Content, tilesetImageName, tilemapsLocation + "tilemapLayer1Template.txt", tilesetTileDimensions, (tilemapHeightTiles, tilemapWidthTiles), tileScale, tilesetKeyPath, tilesetChoicesPerType, tilesetTotalTypes);
            (doorRectangles, doorDirections) = tilemapLayerOne.getDoorCollisionRect();
            cave = new Cave(tunnelsPerRoom, caveHeight, caveWidth);
            gameLocation = new GameLocation(cave.roomList.Count);
            currentRoom = cave.GetRoom(gameLocation.PlayerLocation);
            string warning = gameLocation.GetHazardWarning(cave.GetAdjacentRoomsForRoomNumber(gameLocation.PlayerLocation).roomNumbers);
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

            playerTexture.Load(Content, playerAsset, frames, columns, rows, framesPerSec);
            playerTexture.Row = 0; // play first row (idling animation)

            tilemapLayerZero.Load(Content);
            tilemapLayerOne.Load(Content);

            viewport = _graphics.GraphicsDevice.Viewport;
            characterPos = new Vector2((viewport.Width / 2) - (playerTexture.FrameWidth / 2), (viewport.Height / 2) - (playerTexture.FrameHeight / 2));
        }

        private (bool collided, Rectangle rect, int index) checkForRectangleCollision(Vector2 newCharacterPos, AnimatedTexture playerTexture, Rectangle[] collisionRectangles)
        {
            Rectangle playerRectangle = new Rectangle((int)newCharacterPos.X, (int)newCharacterPos.Y, playerTexture.FrameWidth, playerTexture.FrameHeight);
            for (int i = 0; i < collisionRectangles.Length; i++)
            {
                if (playerRectangle.Intersects(collisionRectangles[i]))
                {
                    return (true, collisionRectangles[i], i);
                }
            }
            return (false, new Rectangle(0, 0, 0, 0), -1);
        }

        private (int offsetRow, int offsetCol) directionOffset(string direction)
        {
            switch (direction)
            {
                case "B": return (-1, 0);
                case "F": return (1, 0);
                case "R": return (0, 1);
                case "L": return (0, -1);
                default: return (0, 0);
            }
        }

        private string reverseDirection(string direction)
        {
            switch (direction)
            {
                case "B": return "F";
                case "F": return "B";
                case "R": return "L";
                case "L": return "R";
                default: return direction;
            }
        }

        private (string, string) getRelativeDoorPositions(string entranceDirection)
        {
            switch (entranceDirection)
            {
                case "B":
                case "F":
                    return ("L", "R");
                case "L":
                case "R":
                    return ("T", "B");
                default:
                    return ("", "");
            }
        }

        private Vector2 getDoorEntrySpawn(string entranceDirection)
        {
            int tilesAway = 2;
            for (int i = 0; i < doorDirections.Length; i++)
            {
                if (doorDirections[i] == entranceDirection)
                {
                    Rectangle doorRect = doorRectangles[i];
                    float spawnX = doorRect.X;
                    float spawnY = doorRect.Y;

                    switch (entranceDirection)
                    {
                        case "B": // back/top entrance: move player down away from wall
                            spawnY += tilesAway * tilesetTileDimensions * tileScale.Y;
                            break;
                        case "F": // front/bottom entrance: move player up into room
                            spawnY -= tilesAway * tilesetTileDimensions * tileScale.Y;
                            break;
                        case "L": // left entrance: move player right into room
                            spawnX += tilesAway * tilesetTileDimensions * tileScale.X;
                            break;
                        case "R": // right entrance: move player left into room
                            spawnX -= tilesAway * tilesetTileDimensions * tileScale.X;
                            break;
                    }
                    return new Vector2(spawnX + (doorRect.Width - playerTexture.FrameWidth) / 2, spawnY + (doorRect.Height - playerTexture.FrameHeight) / 2);
                }
            }
            return new Vector2(
                (viewport.Width / 2) - (playerTexture.FrameWidth / 2),
                (viewport.Height / 2) - (playerTexture.FrameHeight / 2)
            );
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
            Vector2 newCharacterPosition = characterPos;
            if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
            {
                newCharacterPosition.Y -= moveSpeed;
                isMoving = true;
            }

            if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            {
                newCharacterPosition.X -= moveSpeed;
                isMoving = true;
                movingLeft = true;
            }

            if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
            {
                newCharacterPosition.Y += moveSpeed;
                isMoving = true;
            }

            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                newCharacterPosition.X += moveSpeed;
                isMoving = true;
                movingLeft = false;
            }

            string tunnelDirection = "";
            var doorCheck = checkForRectangleCollision(newCharacterPosition, playerTexture, doorRectangles);
            if (doorCheck.collided && doorCheck.index >= 0)
            {
                if (!movingToNextRoom)
                {
                    movingToNextRoom = true;
                    tunnelDirection = doorDirections[doorCheck.index];

                    var offset = directionOffset(tunnelDirection);
                    int newRow = currentRoom.Row + offset.offsetRow;
                    int newCol = currentRoom.Col + offset.offsetCol;

                    Room nextRoom = cave.roomList.FirstOrDefault(r => r.Row == newRow && r.Col == newCol);
                    if (nextRoom != null && currentRoom.RoomTunnels.Contains(nextRoom))
                    {
                        currentRoom = nextRoom;
                        gameLocation.PlayerLocation = currentRoom.RoomNumber;
                        gameLocation.MovePlayer(currentRoom.RoomNumber);
                        gameLocation.OneTurnPasses();
                        string warnings = gameLocation.GetHazardWarning(cave.GetAdjacentRoomsForRoomNumber(gameLocation.PlayerLocation).roomNumbers);
                        if (warnings != "") System.Diagnostics.Debug.WriteLine(warnings);
                        (bool[] hazardsInRoom, string[] hazardNames) = gameLocation.CheckHazards();
                        for (int hazardIndex = 0; hazardIndex < hazardsInRoom.Length; hazardIndex++)
                        {
                            if (hazardsInRoom[hazardIndex])
                            {
                                System.Diagnostics.Debug.WriteLine(hazardNames[hazardIndex]);
                                if (hazardNames[hazardIndex] == "Pit")
                                {
                                    // trigger trivia, if correct, ClimbOutOfPit() else game over
                                }
                                if (hazardNames[hazardIndex] == "Wumpus")
                                {
                                    // um idk whatever u do when encounter the wumpus ??
                                }
                                if (hazardNames[hazardIndex] == "Bat")
                                {
                                    gameLocation.MovePlayerToRandomLocation();
                                } 
                            }
                        }
                        System.Diagnostics.Debug.WriteLine("entered room #" + gameLocation.PlayerLocation.ToString());
                        string entranceDirection = reverseDirection(tunnelDirection);
                        characterPos = getDoorEntrySpawn(entranceDirection);
                    }
                    else if (nextRoom == null)
                    {
                        System.Diagnostics.Debug.WriteLine("no room in that direction");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("you try the door, but it doesn't budge.");
                    }
                }
            }
            else
            {
                movingToNextRoom = false;
            }

            if (!checkForRectangleCollision(newCharacterPosition, playerTexture, tilemapLayerOne.getWallCollisionRect()).collided && !movingToNextRoom)
            {
                characterPos = newCharacterPosition;
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
