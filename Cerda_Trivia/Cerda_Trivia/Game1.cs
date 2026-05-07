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


        // Trivia question variables
        public string Question;
        public string Possibleanswers;
        public int Correctanswer;
        

        //Main question font and position
        private SpriteFont MainQuestion;
        private SpriteFont answerList;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            GumService.Initialize(this);

            OptionButtons();   

            base.Initialize();

            // Example: load the first question from TriviaManager
            var first = TriviaManager.AllQuestionsInfo[0];
            Question = first.QuestionText;
            Possibleanswers = string.Join("\n", first.Options);
            Correctanswer = first.CorrectIndex;

            Question = 
            Possibleanswers = 
            Correctanswer = 
        }

        private void OptionButtons() {

            var mainPanel = new StackPanel();
            mainPanel.AddToRoot();
            mainPanel.Orientation = Orientation.Horizontal;
            mainPanel.Spacing = 4;
            mainPanel.Anchor(Anchor.Center);

            //Option buttons
            var Option1 = new Button();
            Option1.Text = "Option 1";
            mainPanel.AddChild(Option1);

            var Option2 = new Button();
            Option2.Text = "Option 2";
            mainPanel.AddChild(Option2);

            var Option3 = new Button();
            Option3.Text = "Option 3";
            mainPanel.AddChild(Option3);

            var Option4 = new Button();
            Option4.Text = "Option 4";
            mainPanel.AddChild(Option4);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //load the main question font and set its position
            MainQuestion = Content.Load<SpriteFont>("Question");
            answerList = Content.Load<SpriteFont>("Possible Answers");

            // TODO: use this.Content to load your game content here

            // Load main question font and set its position
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            GumService.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Vector2 mainQuestionPos = new Vector2(100, 100);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.DrawString(MainQuestion, Question, mainQuestionPos, Color.White);

            _spriteBatch.DrawString(answerList, Possibleanswers, new Vector2(100, 200), Color.White);

            // End the sprite batch
            _spriteBatch.End();

           GumService.Draw();

            base.Draw(gameTime);
        }
    }
}
