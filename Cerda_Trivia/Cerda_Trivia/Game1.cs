using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gum.Forms.Controls;
using Gum.Wireframe;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameGum;

namespace Cerda_Trivia
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Gum service (kept for other UI)
        private GumService gumService => GumService.Default;

        // Configuration / visuals
        public Color backgroundColor = Color.CornflowerBlue;
        public Color mainQuestionColor = Color.White;

        // Trivia data
        public string question = string.Empty;
        public string possibleAnswers = string.Empty;
        // correctAnswer is zero-based index (0..n-1)
        public int correctAnswer = -1;

        // Fonts
        private SpriteFont mainQuestion;
        private SpriteFont answerList;

        // Dialog visuals
        private Rectangle dialogRect;
        private Texture2D _pixel;

        private bool _showTriviaPopup = true;

        // Option buttons (custom, not Gum Buttons)
        private readonly List<OptionButton> _optionButtons = new();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Initialize Gum and other systems
            gumService.Initialize(this);

            // Load question from your TriviaManager
            try
            {
                var manager = new TriviaManager();
                var first = manager.allQuestionsInfo;
                if (!string.IsNullOrEmpty(first.Question))
                {
                    question = first.Question ?? string.Empty;
                    possibleAnswers = string.Join("\n", first.Answers ?? Array.Empty<string>());
                    // If TriviaManager.CorrectIndex is 1-based, keep the -1; if it's already zero-based, adjust accordingly.
                    correctAnswer = first.CorrectIndex - 1;
                    CreateDialogAndOptions(first.Answers);
                }
            }
            catch
            {
                // If question can't load use default
                question = "No question loaded";
                possibleAnswers = string.Empty;
                correctAnswer = -1;
                CreateDialogAndOptions(null);
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create a single white pixel texture once (avoid recreating each frame)
            _pixel = new Texture2D(GraphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });

            // Load fonts - asset names should match your Content pipeline items.
            // Try both common possibilities in case of naming with/without spaces.
            try
            {
                mainQuestion = Content.Load<SpriteFont>("Question");
            }
            catch
            {
                mainQuestion = null!;
            }

            try
            {
                // Preferred asset name without spaces; keep a fallback to the original if necessary.
                answerList = Content.Load<SpriteFont>("PossibleAnswers");
            }
            catch
            {
                try
                {
                    answerList = Content.Load<SpriteFont>("Possible Answers");
                }
                catch
                {
                    answerList = null!;
                }
            }
        }

        private void CreateDialogAndOptions(string[]? options)
        {

            _showTriviaPopup = true;

            // Define dialog size and position centered on screen
            int dialogWidth = 700;
            int dialogHeight = 260;
            int centerX = GraphicsDevice?.Viewport.Width ?? 800;
            int centerY = GraphicsDevice?.Viewport.Height ?? 480;
            dialogRect = new Rectangle((centerX - dialogWidth) / 2, (centerY - dialogHeight) / 2, dialogWidth, dialogHeight);

            // Clear existing buttons
            _optionButtons.Clear();

            // Create option texts 
            string[] fallback = new[] { "Option 1", "Option 2", "Option 3", "Option 4" };
            var texts = new string[4];
            for (int i = 0; i < 4; i++)
            {
                texts[i] = (options != null && options.Length > i && !string.IsNullOrEmpty(options[i])) ? options[i] : fallback[i];
            }

            // Layout: vertical list inside dialog, leaving padding
            int padding = 16;
            int questionAreaHeight = 72;
            int availableHeight = dialogRect.Height - questionAreaHeight - padding * 2;
            int buttonSpacing = 10;
            int buttonHeight = (availableHeight - buttonSpacing * 3) / 4;
            int buttonWidth = dialogRect.Width - padding * 2;
            int startX = dialogRect.X + padding;
            int startY = dialogRect.Y + padding + questionAreaHeight;

            for (int i = 0; i < 4; i++)
            {
                var rect = new Rectangle(startX, startY + i * (buttonHeight + buttonSpacing), buttonWidth, buttonHeight);
                int index = i; // capture
                var btn = new OptionButton(rect, texts[i], () => CheckAnswer(index));
                _optionButtons.Add(btn);
            }
        }

        public void RunTriviaPopup()
        {
            if (_showTriviaPopup != true)
                return;

            UpdateButtons();

            DrawTriviaPopup();

            // gumService.Update is called from Update(gameTime) so avoid creating a default GameTime here.
        }

        private void DrawTriviaPopup()
        {

            if (_showTriviaPopup != true)
                return;

            _spriteBatch.Begin();

            // Dialog background
            _spriteBatch.Draw(_pixel, dialogRect, Color.Black * 0.85f);

            // Question text
            if (!string.IsNullOrEmpty(question) && mainQuestion != null)
            {
                Vector2 questionPos =
                    new Vector2(dialogRect.X + 16, dialogRect.Y + 12);

                _spriteBatch.DrawString(
                    mainQuestion,
                    question,
                    questionPos,
                    mainQuestionColor);
            }

            // Draw buttons
            foreach (var b in _optionButtons)
            {
                b.Draw(_spriteBatch, _pixel, answerList);
            }

            _spriteBatch.End();

            gumService.Draw();
        }

        private async void CheckAnswer(int selectedIndex)
        {
            // selectedIndex is zero-based to match correctAnswer
            if (correctAnswer >= 0 && selectedIndex == correctAnswer)
            {
                mainQuestionColor = Color.Green;
            }
            else
            {
                mainQuestionColor = Color.Red;

                // Disable all option buttons
                foreach (var b in _optionButtons)
                {
                    b.IsEnabled = false;
                }

                // Wait a moment so user sees result, then exit
                await Task.Delay(1000);
                _optionButtons.Clear();
                _showTriviaPopup = false;
                question = string.Empty;
            }
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // Update Gum for other UI
            gumService.Update(gameTime);

            base.Update(gameTime);
        }

        private void UpdateButtons()
        {

            if (!_showTriviaPopup) return;

            foreach (var b in _optionButtons)
            {
                b.Update();
            }
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);

            RunTriviaPopup();

            base.Draw(gameTime);
        }

        // Simple option button class for in-game dialog buttons
        private class OptionButton
        {
            public Rectangle Rect;
            public string Text;
            public bool IsEnabled = true;
            private readonly Action _onClick;
            private bool _wasPressed;

            public OptionButton(Rectangle rect, string text, Action onClick)
            {
                Rect = rect;
                Text = text ?? string.Empty;
                _onClick = onClick ?? (() => { });
            }

            public void Update()
            {
                if (!IsEnabled)
                {
                    _wasPressed = false;
                    return;
                }

                var mouse = Mouse.GetState();
                bool inside = Rect.Contains(mouse.Position);

                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    if (inside)
                        _wasPressed = true;
                }
                else
                {
                    if (_wasPressed && inside)
                    {
                        // Click detected on release
                        _onClick();
                    }
                    _wasPressed = false;
                }
            }

            public void Draw(SpriteBatch sb, Texture2D pixel, SpriteFont font)
            {
                // Background
                Color bg = IsEnabled ? Color.DimGray * 0.95f : Color.Gray * 0.7f;
                sb.Draw(pixel, Rect, bg);

                // Text (centered)
                if (font != null && !string.IsNullOrEmpty(Text))
                {
                    Vector2 size = font.MeasureString(Text);
                    Vector2 pos = new Vector2(Rect.X + Rect.Width / 2f - size.X / 2f, Rect.Y + Rect.Height / 2f - size.Y / 2f);
                    Color textColor = IsEnabled ? Color.White : Color.LightGray;
                    sb.DrawString(font, Text, pos, textColor);
                }
            }
        }
    }
}
