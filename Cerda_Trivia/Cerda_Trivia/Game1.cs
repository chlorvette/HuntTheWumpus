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

namespace Cerda_Trivia
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Input box variables
        GumService GumService => GumService.Default;

        public Color BackgroundColor = Color.CornflowerBlue;

        // Trivia question variables
        public string Question;
        public string Possibleanswers;
        public int Correctanswer;

        //Main question font and position
        private SpriteFont MainQuestion;
        private SpriteFont answerList;

        public Color MainQuestionColor = Color.White;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // Initialize Gum
            GumService.Initialize(this);

            base.Initialize();

            var manager = new TriviaManager();
            var first = manager.AllQuestionsInfo; // (string Question, string[] Answers, int CorrectIndex)
            Question = first.Question;
            Possibleanswers = string.Join("\n", first.Answers ?? new string[0]);
            Correctanswer = first.CorrectIndex;
            OptionButtons(first.Answers);
        }

        private void OptionButtons(string[] options)
        {
            var mainPanel = new StackPanel();
            mainPanel.AddToRoot();
            mainPanel.Orientation = Orientation.Horizontal;
            mainPanel.Spacing = 4;
            mainPanel.Anchor(Anchor.Center);

            // Option buttons
            var Option1 = new Button();
            Option1.Text = options != null && options.Length > 0 ? options[0] : "Option 1";
            mainPanel.AddChild(Option1);

            var Option2 = new Button();
            Option2.Text = options != null && options.Length > 1 ? options[1] : "Option 2";
            mainPanel.AddChild(Option2);

            var Option3 = new Button();
            Option3.Text = options != null && options.Length > 2 ? options[2] : "Option 3";
            mainPanel.AddChild(Option3);

            var Option4 = new Button();
            Option4.Text = options != null && options.Length > 3 ? options[3] : "Option 4";
            mainPanel.AddChild(Option4);

            if (Option1 != null && Option2 != null || Option3 != null || Option4 != null)
            {
                Option1.Click += (s, e) => CheckAnswer(1);
                Option2.Click += (s, e) => CheckAnswer(2);
                Option3.Click += (s, e) => CheckAnswer(3);
                Option4.Click += (s, e) => CheckAnswer(4);
            }
        }

        private void CheckAnswer(int selectedOption)
        {
            if (selectedOption == Correctanswer) // +1 because options are 1-indexed
            {
                // Correct answer logic
                MainQuestionColor = Color.Green;
            }
            else
            {
                // Incorrect answer logic
                MainQuestionColor = Color.Red;
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //load the main question font and set its position
            MainQuestion = Content.Load<SpriteFont>("Question");
            answerList = Content.Load<SpriteFont>("Possible Answers");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            GumService.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Vector2 mainQuestionPos = new Vector2(100, 100);

            _spriteBatch.Begin();

            _spriteBatch.DrawString(MainQuestion, Question, mainQuestionPos, MainQuestionColor);

            _spriteBatch.End();

           GumService.Draw();

            base.Draw(gameTime);
        }
    }
}
