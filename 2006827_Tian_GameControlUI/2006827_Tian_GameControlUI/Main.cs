using GameControlUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameGum;
using Gum.Forms.Controls;
using Gum.Wireframe;
using System.Linq;
using Cave = CaveGeneration.Cave;
using Room = CaveGeneration.Room;
using GameLocation = GameLocations.GameLocations;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Color = Microsoft.Xna.Framework.Color;
using Gum.DataTypes.Variables;
using GameControlUI.Screens;
using System.IO;
using System;

namespace _2006827_Tian_GameControlUI
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private bool gameStarted = true;

        private AnimatedTexture playerTexture;
        private Tilemap tilemapLayerZero;
        private Tilemap tilemapLayerOne;
        private Texture2D doorLock;
        private Texture2D wumpusTexture;
        private Texture2D pitTexture;
        private Texture2D wumpusWarningIconTexture;
        private Texture2D pitWarningIconTexture;
        private Texture2D batWarningIconTexture;
        private string doorLockAssetName = "lock";
        private int? lockedDoorIndex = null;

        // player configuration
        private const float playerRotation = 0;
        private Vector2 playerScale = new Vector2(1f, 1f);
        private const float playerDepth = 0.5f;
        private const string playerAsset = "ArcherSheet";
        private int[] framesPerRow = { 5, 10, 8, 5, 6 };
        private Player player;

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

        // hazards configuration
        private const string wumpusAssetName = "hazards/tripleT";
        private const string wumpusWarningIconName = "warningIcons/wumpusWarning";
        private Vector2 wumpusWarningPos;
        private bool showWumpus = false;
        private bool wumpusWarningActive = false;
        private const string pitAssetName = "hazards/pit";
        private const string pitWarningIconName = "warningIcons/pitWarning";
        private Vector2 pitWarningPos;
        private bool showPit = false;
        private bool pitWarningActive = false;
        private const string batWarningIconName = "warningIcons/batWarning";
        private Vector2 batWarningPos;
        private bool batWarningActive = false;

        private Rectangle[] doorRectangles;
        private string[] doorDirections;

        private int caveHeight = 5;
        private int tunnelsPerRoom = 3;
        private int caveWidth = 6;
        private Cave cave;
        private Room currentRoom;
        private bool movingToNextRoom = false;
        private GameLocation gameLocation;

        GumService GumUI => GumService.Default;
        GameScreen gameScreen;
        BuyArrowConfirmation buyArrowConfirmationScreen;
        private bool buyArrowConfShown = false;
        ErrorDialog errorDialog;
        TriviaCorrect correctDialog;
        TriviaIncorrect incorrectDialog;

        // trivia configuration
        TriviaPopup triviaPopup;
        private const string triviaFilePath = @"..\..\..\Content\trivia.txt";
        private int answerChoicesPerQuestion = 4;
        private string[] triviaQuestions;
        private string[,] triviaAnswerChoices;
        private string[] triviaCorrectAnswers;
        private int currentQuestionIndex = -1;
        private bool answerAwaitingResponse = false;
        private int questionNumber = 0;
        private int totalQuestionsThisRound = 0;
        private int correctAnswersThisRound = 0;
        private bool triviaFinishedAwaitingResponse = false;

        private (string[] questions, string[,] answerChoices, string[] correctAnswer) parseTriviaFile( string triviaFilePath)
        {
            string[] questions = new string[File.ReadLines(triviaFilePath).Count()];
            string[,] answerChoices = new string[questions.Length, answerChoicesPerQuestion];
            string[] correctAnswer = new string[questions.Length];
            int currentRow = 0;
            using (StreamReader sr = new StreamReader(triviaFilePath))
            {
                string line;
                for (currentRow = 0; (line = sr.ReadLine()) != null; currentRow++)
                {
                    string[] splitString = line.Split('|');
                    questions[currentRow] = splitString[0];
                    for (int index = 0; index < answerChoicesPerQuestion; index++)
                    {
                        answerChoices[currentRow, index] = splitString[index + 1];
                    }
                    correctAnswer[currentRow] = splitString[1 + answerChoicesPerQuestion];
                }
            }
            return (questions, answerChoices, correctAnswer);
        }

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            player = new Player();
            playerTexture = new AnimatedTexture(Vector2.Zero, playerRotation, playerScale, playerDepth, framesPerRow);

            float warningY = tilesetTileDimensions * tileScale.Y; // top row, plus some padding
            wumpusWarningPos = new Vector2((tilemapWidthTiles - 2) * tilesetTileDimensions * tileScale.X, warningY);
            pitWarningPos = new Vector2((tilemapWidthTiles - 3) * tilesetTileDimensions * tileScale.X, warningY);
            batWarningPos = new Vector2((tilemapWidthTiles - 4) * tilesetTileDimensions * tileScale.X, warningY);

            tilemapLayerZero = new Tilemap(Content, tilesetImageName, tilemapsLocation+ "tilemapLayer0Template.txt", tilesetTileDimensions, (tilemapHeightTiles, tilemapWidthTiles), tileScale, tilesetKeyPath, tilesetChoicesPerType, tilesetTotalTypes);
            tilemapLayerOne = new Tilemap(Content, tilesetImageName, tilemapsLocation + "tilemapLayer1Template.txt", tilesetTileDimensions, (tilemapHeightTiles, tilemapWidthTiles), tileScale, tilesetKeyPath, tilesetChoicesPerType, tilesetTotalTypes);
            
            (doorRectangles, doorDirections) = tilemapLayerOne.getDoorCollisionRect();

            cave = new Cave(tunnelsPerRoom, caveHeight, caveWidth);
            gameLocation = new GameLocation(cave.roomList.Count);
            gameLocation.PlayerLocation = gameLocation.PitLocations[0];
            currentRoom = cave.GetRoom(gameLocation.PlayerLocation);
            string warning = gameLocation.GetHazardWarning(cave.GetAdjacentRoomsForRoomNumber(gameLocation.PlayerLocation).roomNumbers).message;
        }

        protected override void Initialize()
        {
            (triviaQuestions, triviaAnswerChoices, triviaCorrectAnswers) = parseTriviaFile(triviaFilePath);

            var gumProject = GumUI.Initialize(this, "GumUI/GumProject.gumx");

            var titleScreen = new TitleScreen();
            //titleScreen.AddToRoot();

            gameScreen = new GameScreen();
            gameScreen.AddToRoot();

            buyArrowConfirmationScreen = new BuyArrowConfirmation();
            buyArrowConfirmationScreen.ConfirmBuy.Click += (_, _) => BuyArrow();
            buyArrowConfirmationScreen.CancelBuy.Click += (_, _) => ClearDialogs();

            errorDialog = new ErrorDialog();
            errorDialog.ButtonCloseInstance.Click += (_, _) => ClearDialogs();

            triviaPopup = new TriviaPopup();

            correctDialog = new TriviaCorrect();
            correctDialog.ButtonOK.Click += (_, _) =>
            {
                ClearDialogs();
                if (questionNumber <= totalQuestionsThisRound && totalQuestionsThisRound != 0)
                {
                    PromptTriviaQuestion(questionNumber, totalQuestionsThisRound);
                } else if (totalQuestionsThisRound == 0)
                {
                    if (gameLocation.PlayerLocation == gameLocation.PitLocations[0] || gameLocation.PlayerLocation == gameLocation.PitLocations[1])
                    {
                        if (correctAnswersThisRound >= 2) gameLocation.ClimbOutOfPit();
                        else { gameStarted = false; }
                    } else if (gameLocation.PlayerLocation == gameLocation.WumpusLocation) {
                        if (correctAnswersThisRound >= 3) { } // umm win against wumpus idk what procedure is for that
                    }
                }
                else
                {
                    totalQuestionsThisRound = 0;
                    questionNumber = 0;
                }
            };

            incorrectDialog = new TriviaIncorrect();
            incorrectDialog.ButtonOK.Click += (_, _) =>
            {
                ClearDialogs();
                if (questionNumber <= totalQuestionsThisRound && totalQuestionsThisRound != 0)
                {
                    PromptTriviaQuestion(questionNumber, totalQuestionsThisRound);
                }
                else
                {
                    totalQuestionsThisRound = 0;
                    questionNumber = 0;
                }
            };

            base.Initialize();
        }

        private Viewport viewport;

        // player configuration
        private Vector2 characterPos;
        private SpriteEffects playerSpriteEffect;
        private int moveSpeed = 5;
        private const int columns = 11;
        private const int rows = 5;
        private const int framesPerSec = 10;

        // setting initial values
        private bool isMoving = false;
        private bool movingLeft = false;
        private bool drawingArrow = false;

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            playerTexture.Load(Content, playerAsset, columns, rows, framesPerSec);
            playerTexture.Row = 0; // play first row (idling animation)

            wumpusTexture = Content.Load<Texture2D>(wumpusAssetName);
            wumpusWarningIconTexture = Content.Load<Texture2D>(wumpusWarningIconName);

            pitTexture = Content.Load<Texture2D>(pitAssetName);
            pitWarningIconTexture = Content.Load<Texture2D>(pitWarningIconName);

            batWarningIconTexture = Content.Load<Texture2D>(batWarningIconName);

            doorLock = Content.Load<Texture2D>(doorLockAssetName);

            tilemapLayerZero.Load(Content);
            tilemapLayerOne.Load(Content);

            viewport = _graphics.GraphicsDevice.Viewport;
            characterPos = new Vector2((viewport.Width / 2) - (playerTexture.FrameWidth / 2), (viewport.Height / 2) - (playerTexture.FrameHeight / 2));
        }

        private void PromptTriviaQuestion(int questionNumber, int totalQuestions)
        {
            if (!answerAwaitingResponse)
            {
                Random r = new Random();
                currentQuestionIndex = r.Next(0, triviaQuestions.Length);

                string question = triviaQuestions[currentQuestionIndex];
                string correctAnswer = triviaCorrectAnswers[currentQuestionIndex];
                string answerA = triviaAnswerChoices[currentQuestionIndex, 0];
                string answerB = triviaAnswerChoices[currentQuestionIndex, 1];
                string answerC = triviaAnswerChoices[currentQuestionIndex, 2];
                string answerD = triviaAnswerChoices[currentQuestionIndex, 3];

                triviaPopup.UpdatePopup(question, answerA, answerB, answerC, answerD, questionNumber, totalQuestions);

                triviaPopup.AddToRoot();

                answerAwaitingResponse = true;
            }
        }

        private (bool answered, bool correct) CheckTriviaAnswer() {
            bool answered = false;
            bool correct = false;
            string lastClicked = triviaPopup.GetRecentClicked();
            if (lastClicked != "")
            {
                answered = true;
                if (lastClicked == triviaCorrectAnswers[currentQuestionIndex])
                {
                    correct = true;
                } else
                {
                    correct = false;
                }
            } else
            {
                answered = false;
            }
            if (answered)
            {
                currentQuestionIndex = -1;
                triviaPopup.ResetClicked();
                answerAwaitingResponse = false;
            }
            return (answered, correct);
        }

        private (bool collided, Rectangle rect, int index) CheckForRectangleCollision(Vector2 newCharacterPos, AnimatedTexture playerTexture, Rectangle[] collisionRectangles)
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

        private (int offsetRow, int offsetCol) DirectionOffset(string direction)
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

        private string ReverseDirection(string direction)
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

        private (bool successful, bool shotWumpus) ShootArrow(string direction)
        {
            var offset = DirectionOffset(direction);
            int newRow = currentRoom.Row + offset.offsetRow;
            int newCol = currentRoom.Col + offset.offsetCol;

            Room nextRoom = cave.roomList.FirstOrDefault(r => r.Row == newRow && r.Col == newCol);
            if (nextRoom != null && currentRoom.RoomTunnels.Contains(nextRoom) && player.arrows >= 1)
            {
                bool shotWumpus = gameLocation.ShootArrow(nextRoom.RoomNumber);
                if (!shotWumpus)
                {
                    gameLocation.MoveWumpusAfterArrowMiss(cave.GetRoom(gameLocation.WumpusLocation).RoomTunnels);
                }
                player.arrows--;
                return (true, shotWumpus);
            } else
            {
                return (false, false);
            }
        }

        private Vector2 GetDoorEntrySpawn(string entranceDirection)
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

        private void BuyArrow()
        {
            if (player.UseCoin(3))
            {
                player.arrows++;
                player.TakeTurn();
                ClearDialogs();
            } else
            {
                errorDialog.MessageLabel.Text = "Not enough coins to buy an arrow!";
                errorDialog.AddToRoot();
            }
        }

        private void ClearDialogs()
        {
            buyArrowConfShown = false;
            GumService.Default.Root.Children.Clear();
            gameScreen.AddToRoot();
        }

        protected override void Update(GameTime gameTime)
        {
            if (gameStarted)
            {
                // keyboard input => player movement
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.Back))
                {
                    Exit();
                }

                isMoving = false;
                drawingArrow = false;
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

                if (keyboardState.IsKeyDown(Keys.Space))
                {
                    drawingArrow = true;
                }

                if (keyboardState.IsKeyDown(Keys.B) && !buyArrowConfShown)
                {
                    buyArrowConfShown = true;
                    buyArrowConfirmationScreen.AddToRoot();
                }

                if (drawingArrow && (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up)))
                {
                    playerTexture.arrowReleased = true;
                    ShootArrow("B");
                }
                if (drawingArrow && (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down)))
                {
                    playerTexture.arrowReleased = true;
                    ShootArrow("F");
                }
                if (drawingArrow && (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left)))
                {
                    playerTexture.arrowReleased = true;
                    ShootArrow("L");
                }
                if (drawingArrow && (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right)))
                {
                    playerTexture.arrowReleased = true;
                    ShootArrow("R");
                }

                string tunnelDirection = "";
                var doorCheck = CheckForRectangleCollision(newCharacterPosition, playerTexture, doorRectangles);
                if (doorCheck.collided && doorCheck.index >= 0)
                {
                    if (!movingToNextRoom)
                    {
                        movingToNextRoom = true;
                        tunnelDirection = doorDirections[doorCheck.index];

                        var offset = DirectionOffset(tunnelDirection);
                        int newRow = currentRoom.Row + offset.offsetRow;
                        int newCol = currentRoom.Col + offset.offsetCol;

                        Room nextRoom = cave.roomList.FirstOrDefault(r => r.Row == newRow && r.Col == newCol);
                        if (nextRoom != null && currentRoom.RoomTunnels.Contains(nextRoom))
                        {
                            currentRoom = nextRoom;
                            gameLocation.PlayerLocation = currentRoom.RoomNumber;
                            gameLocation.MovePlayer(currentRoom.RoomNumber);

                            player.TakeTurn();
                            gameLocation.OneTurnPasses();
                            System.Diagnostics.Debug.WriteLine("one turn passes");

                            showWumpus = false;
                            showPit = false;

                            (string warningMessages, bool[] warnings) = gameLocation.GetHazardWarning(cave.GetAdjacentRoomsForRoomNumber(gameLocation.PlayerLocation).roomNumbers);
                            if (warningMessages != "") System.Diagnostics.Debug.WriteLine(warningMessages);
                            pitWarningActive = warnings[0];
                            batWarningActive = warnings[1];
                            wumpusWarningActive = warnings[2];

                            (bool[] hazardsInRoom, string[] hazardNames) = gameLocation.CheckHazards();
                            for (int hazardIndex = 0; hazardIndex < hazardsInRoom.Length; hazardIndex++)
                            {
                                if (hazardsInRoom[hazardIndex])
                                {
                                    System.Diagnostics.Debug.WriteLine(hazardNames[hazardIndex]);
                                    if (hazardNames[hazardIndex] == "Pit")
                                    {
                                        questionNumber = 1;
                                        totalQuestionsThisRound = 3;

                                        PromptTriviaQuestion(questionNumber, totalQuestionsThisRound);

                                        showPit = true;
                                    }
                                    if (hazardNames[hazardIndex] == "Wumpus")
                                    {
                                        showWumpus = true;
                                        // um idk whatever u do when encounter the wumpus ??
                                        // must answer 3 out of 5 trivia questions correctly to avoid being eaten
                                        // if answered 3 out of 5 wumpus will run as many as 4 rooms away and if you win the fight you lose the game
                                    }
                                    if (hazardNames[hazardIndex] == "Bat")
                                    {
                                        gameLocation.MovePlayerToRandomLocation();
                                        errorDialog.MessageLabel.Text = $"A bat moved you to room {gameLocation.PlayerLocation}";
                                    }
                                }
                            }
                            System.Diagnostics.Debug.WriteLine("entered room #" + gameLocation.PlayerLocation.ToString());
                            string entranceDirection = ReverseDirection(tunnelDirection);
                            characterPos = GetDoorEntrySpawn(entranceDirection);
                            lockedDoorIndex = null;
                        }
                        else if (nextRoom == null)
                        {
                            System.Diagnostics.Debug.WriteLine("no room in that direction");
                            lockedDoorIndex = doorCheck.index;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("you try the door, but it doesn't budge.");
                            lockedDoorIndex = doorCheck.index;
                        }
                    }
                }
                else
                {
                    movingToNextRoom = false;
                    lockedDoorIndex = null;
                }

                if (!CheckForRectangleCollision(newCharacterPosition, playerTexture, tilemapLayerOne.getWallCollisionRect()).collided && !movingToNextRoom && !drawingArrow && !answerAwaitingResponse)
                {
                    characterPos = newCharacterPosition;
                }

                if (isMoving)
                {
                    drawingArrow = false;
                    playerTexture.Row = 2; // walk animation
                }
                else if (drawingArrow)
                {
                    playerTexture.Row = 1;
                }
                else
                {
                    playerTexture.Row = 0; // idle animation
                }

                if (movingLeft)
                {
                    playerSpriteEffect = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    playerSpriteEffect = SpriteEffects.None;
                }

                float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                playerTexture.UpdateFrame(elapsed);
            }

            (bool questionAnswered, bool questionCorrect) = CheckTriviaAnswer();
            if (questionAnswered)
            {
                if (questionCorrect)
                {
                    correctDialog.AddToRoot();
                    correctAnswersThisRound++;
                    System.Diagnostics.Debug.WriteLine($"questionCorrect is true, {correctAnswersThisRound} correct answers this round, question number {questionNumber}, total questions this round {totalQuestionsThisRound}");
                }
                else
                {
                    incorrectDialog.AddToRoot();
                    System.Diagnostics.Debug.WriteLine($"questionCorrect is false, {correctAnswersThisRound} correct answers this round, question number {questionNumber}, total questions this round {totalQuestionsThisRound}");
                }
                questionNumber++;
                if (questionNumber <= totalQuestionsThisRound)
                {
                    //PromptTriviaQuestion(questionNumber, totalQuestionsThisRound);
                } else
                {
                    totalQuestionsThisRound = 0;
                    questionNumber = 0;
                }
            }

            GumUI.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White); // clear

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            tilemapLayerZero.Draw(_spriteBatch);
            tilemapLayerOne.Draw(_spriteBatch);
            if (lockedDoorIndex != null && lockedDoorIndex.Value >= 0 && lockedDoorIndex.Value < doorRectangles.Length)
            {
                Rectangle lockedDoorRect = doorRectangles[lockedDoorIndex.Value];
                int lockWidth = doorLock.Width;
                int lockHeight = doorLock.Height;

                string direction = doorDirections[lockedDoorIndex.Value];

                float lockX = lockedDoorRect.X + (doorLock.Width) / 2f;
                float lockY = lockedDoorRect.Y + (doorLock.Height) / 2f;

                if (direction == "L" || direction == "R")
                {
                    lockX = lockedDoorRect.X;
                    lockY = lockedDoorRect.Y + (lockedDoorRect.Height) / 2f;
                }
                else if (direction == "B" || direction == "F")
                {
                    lockX = lockedDoorRect.X + (lockedDoorRect.Width - doorLock.Width) / 2f;
                    lockY = lockedDoorRect.Y + (lockedDoorRect.Height - doorLock.Height) / 2f;
                }
                _spriteBatch.Draw(doorLock, new Vector2(lockX, lockY), Color.White);
            }

            gameScreen.UpdateStatistics(gameLocation.PlayerLocation, player.turns, player.coins, player.arrows);

            if (wumpusWarningActive)
            {
                _spriteBatch.Draw(wumpusWarningIconTexture, wumpusWarningPos, Color.White);
            }
            else
            {
                 _spriteBatch.Draw(wumpusWarningIconTexture, wumpusWarningPos, Color.White * 0.25f);
            }
            if (pitWarningActive)
            {
                _spriteBatch.Draw(pitWarningIconTexture, pitWarningPos, Color.White);
            } else
            {
                _spriteBatch.Draw(pitWarningIconTexture, pitWarningPos, Color.White * 0.25f);
            }
            if (batWarningActive)
            {
                _spriteBatch.Draw(batWarningIconTexture, batWarningPos, Color.White);
            } else
            {
                _spriteBatch.Draw(batWarningIconTexture, batWarningPos, Color.White * 0.25f);
            }
            
            if (showWumpus) _spriteBatch.Draw(wumpusTexture, new Vector2((viewport.Width / 2) - (wumpusTexture.Width / 2), (viewport.Height / 2) - (wumpusTexture.Height / 2)), Color.White);
            if (showPit) _spriteBatch.Draw(pitTexture, new Vector2((viewport.Width / 2) - (pitTexture.Width / 2), (viewport.Height / 2) - (pitTexture.Height / 2)), Color.White);

            playerTexture.DrawFrame(_spriteBatch, characterPos, playerSpriteEffect);
            _spriteBatch.End();

            GumUI.Draw();

            base.Draw(gameTime);
        }
    }
}
