using System;
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

        // Gum service
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

        // Keep references to option buttons so we can disable them
        private Button option1;
        private Button option2;
        private Button option3;
        private Button option4;

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

            // Load question from your TriviaManager (assumes it provides an AllQuestionsInfo-like property)
            try
            {
                var manager = new TriviaManager();
                // Expecting a tuple or object with Question, Answers and CorrectIndex
                // Adjust this access if TriviaManager has a different API.
                var first = manager.allQuestionsInfo;
                if (!string.IsNullOrEmpty(first.Question))
                {
                    question = first.Question ?? string.Empty;
                    possibleAnswers = string.Join("\n", first.Answers ?? Array.Empty<string>());
                    correctAnswer = first.CorrectIndex;
                    OptionButtons(first.Answers);
                }
            }
            catch
            {
                // If TriviaManager is not available or fails, keep defaults
                question = "No question loaded";
                possibleAnswers = string.Empty;
                correctAnswer = -1;
                OptionButtons(null);
            }

            base.Initialize();
        }

        private void OptionButtons(string[]? options)
        {
            // Create a panel as container (simple usage)
            var mainPanel = new Gum.Forms.Controls.Panel();
            // If Gum panel supports positioning, you can set properties here. Keep minimal to avoid compile-time assumptions.

            // Create option buttons and set text safely
            option1 = new Button();
            option1.Text = (options != null && options.Length > 0) ? options[0] : "Option 1";
            mainPanel.AddChild(option1);

            option2 = new Button();
            option2.Text = (options != null && options.Length > 1) ? options[1] : "Option 2";
            mainPanel.AddChild(option2);

            option3 = new Button();
            option3.Text = (options != null && options.Length > 2) ? options[2] : "Option 3";
            mainPanel.AddChild(option3);

            option4 = new Button();
            option4.Text = (options != null && options.Length > 3) ? options[3] : "Option 4";
            mainPanel.AddChild(option4);

            // Attach click handlers (buttons are 1-indexed for the UI)
            option1.Click += (s, e) => CheckAnswer(1, option1, option2, option3, option4);
            option2.Click += (s, e) => CheckAnswer(2, option2, option1, option3, option4);
            option3.Click += (s, e) => CheckAnswer(3, option3, option1, option2, option4);
            option4.Click += (s, e) => CheckAnswer(4, option4, option1, option2, option3);

            // Optionally add the main panel to Gum root or show it as appropriate for your project
            // Example (if Gum has a Root):
            // gumService.Root.AddChild(mainPanel);
        }

        private async void CheckAnswer(int selectedOption, Button clicked, Button b1, Button b2, Button b3)
        {
            // selectedOption is 1-based, correctAnswer is expected to be 0-based
            if (correctAnswer >= 0 && selectedOption - 1 == correctAnswer)
            {
                mainQuestionColor = Color.Green;
            }
            else
            {
                mainQuestionColor = Color.Red;

                // Disable all option buttons
                option1.IsEnabled = false;
                option2.IsEnabled = false;
                option3.IsEnabled = false;
                option4.IsEnabled = false;

                // Wait a moment so user sees result, then exit
                await Task.Delay(1000);
                Exit();
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load fonts - asset names should match your Content pipeline items
            // Avoid spaces in asset names; changed "Possible Answers" to "PossibleAnswers"
            mainQuestion = Content.Load<SpriteFont>("Question");
            answerList = Content.Load<SpriteFont>("PossibleAnswers");
        }

        protected override void Update(GameTime gameTime)
        {
            // Exit on Escape / Back
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // Update Gum
            gumService.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);

            // Draw main question centered near top
            if (!string.IsNullOrEmpty(question) && mainQuestion != null)
            {
                Vector2 questionSize = mainQuestion.MeasureString(question);
                Vector2 mainQuestionPos = new Vector2(GraphicsDevice.Viewport.Width / 2f, 100f) - questionSize / 2f;

                _spriteBatch.Begin();
                _spriteBatch.DrawString(mainQuestion, question, mainQuestionPos, mainQuestionColor);
                _spriteBatch.End();
            }

            // Draw Gum UI
            gumService.Draw();

            base.Draw(gameTime);
        }
    }
}
