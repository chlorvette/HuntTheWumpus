using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using MonoGameGum;
using Gum.Forms.Controls;
using System.Runtime.InteropServices;
using Gum.Wireframe;
using System.Threading.Tasks;

namespace Cerda_Trivia
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Input box variables
        GumService gumService => GumService.Default;

        public Color backgroundColor = Color.CornflowerBlue;

        // Trivia question variables
        public string question;
        public string possibleAnswers;
        public int correctAnswer;

        //Main question font and position
        private SpriteFont mainQuestion;
        private SpriteFont answerList;

        public Color mainQuestionColor = Color.White;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        public void showTrviaQuestion()
        { 
        
            Initialize();
            LoadContent();
            Update(new GameTime());
            Draw(new GameTime());

        }
        protected override void Initialize()
        {
            // Initialize Gum
            gumService.Initialize(this);
            base.Initialize();

            var manager = new TriviaManager();
            var first = manager.allQuestionsInfo; // (string Question, string[] Answers, int CorrectIndex)
            question = first.Question;
            possibleAnswers = string.Join("\n", first.Answers ?? new string[0]);
            correctAnswer = first.CorrectIndex;
            OptionButtons(first.Answers);
        }

        private void OptionButtons(string[] options)
        {
            var mainPanel = new StackPanel();
            mainPanel.AddToRoot();
            mainPanel.Orientation = Orientation.Horizontal;
            mainPanel.Spacing = 4;
            mainPanel.Anchor(Anchor.Center);

            // Option buttons\
            var option1 = new Button();
            option1.Text = options != null && options.Length > 0 ? options[0] : "Option 1";
            mainPanel.AddChild(option1);

            var option2 = new Button();
            option2.Text = options != null && options.Length > 1 ? options[1] : "Option 2";
            mainPanel.AddChild(option2);    
            var option3 = new Button();
            option3.Text = options != null && options.Length > 2 ? options[2] : "Option 3";
            mainPanel.AddChild(option3);

            var option4 = new Button();
            option4.Text = options != null && options.Length > 3 ? options[3] : "Option 4";
            mainPanel.AddChild(option4);
            if (option1 != null && option2 != null || option3 != null || option4 != null)
            {
                option1.Click += (s, e) => CheckAnswer(1, option1, option2, option3, option4);
                option2.Click += (s, e) => CheckAnswer(2, option2, option1, option3, option4);
                option3.Click += (s, e) => CheckAnswer(3, option3, option1, option2, option4);
                option4.Click += (s, e) => CheckAnswer(4, option4, option1, option2, option3);
            }
        }

        private async void CheckAnswer(int selectedOption, Button option1, Button option2, Button option3, Button option4)
        {
            if (selectedOption == correctAnswer) // +1 because options are 1-indexed
            {
                // Correct answer logic
                mainQuestionColor = Color.Green;
                option1.IsEnabled = false;
                option2.IsEnabled = false;
                option3.IsEnabled = false;
                option4.IsEnabled = false;
                await Task.Delay(1000); // Wait for 1 second before closin the program
                base.Exit();
            }
            else
            {
                // Incorrect answer logic
                mainQuestionColor = Color.Red;
                option1.IsEnabled = false;
                option2.IsEnabled = false;
                option3.IsEnabled = false;
                option4.IsEnabled = false;
                await Task.Delay(1000); // Wait for 1 second before closin the program
                base.Exit();

            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //load the main question font and set its position
            mainQuestion = Content.Load<SpriteFont>("Question");

            answerList = Content.Load<SpriteFont>("Possible Answers");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gumService.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);

            Vector2 questionSize = mainQuestion.MeasureString(question);

            Vector2 mainQuestionPos = new Vector2(GraphicsDevice.Viewport.Width / 2, 100) - questionSize / 2;

            _spriteBatch.Begin();

            _spriteBatch.DrawString(mainQuestion, question, mainQuestionPos, mainQuestionColor);

            _spriteBatch.End();

            gumService.Draw();

            base.Draw(gameTime);
        }
    }
}
