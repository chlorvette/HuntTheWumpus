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
        public List<string> triviaQuestions = new List<string>
        {
            "What is the capital of France?",
            "What is the largest planet in our solar system?",
            "Who wrote the play 'Romeo and Juliet'?",
            "What is the chemical symbol for gold?",
            "What is the tallest mountain in the world?",
            "What is the largest ocean on Earth?",
            "Who painted the Mona Lisa?",
            "What is the smallest country in the world?",
            "What is the currency of Japan?",
            "Who is the current President of the United States?",
            "What is the largest desert in the world?",
            "Who is the author of the Harry Potter series?",
            "What is the chemical symbol for water?",
            "What is the largest mammal in the world?",
            "Who is the founder of Microsoft?",
            "What is the capital of Australia?",
            "What is the largest continent on Earth?",
            "Who is the current Prime Minister of the United Kingdom?",
            "What is the chemical symbol for oxygen?",
            "What is the largest city in the world by population?",
            "Who is the author of 'The Lord of the Rings'?",
            "What is the chemical symbol for carbon?",
            "What is the largest island in the world?",
            "Who is the current Chancellor of Germany?",
            "What is the chemical symbol for nitrogen?",
            "What is the largest river in the world?",
            "Who is the author of 'To Kill a Mockingbird'?",
            "What is the chemical symbol for helium?",
            "What is the largest volcano in the world?",
            "Who is the current President of France?",
            "What is the chemical symbol for sodium?",
        };
        public List<string> possibleAnswers = new List<string>
        {
            "1) Berlin 2) Madrid 3) Paris 4) Rome",
            "1) Earth 2) Jupiter 3) Mars 4) Saturn",
            "1) William Shakespeare 2) Charles Dickens 3) Jane Austen 4) Mark Twain",
            "1) Au 2) Ag 3) Fe 4) Hg",
            "1) Mount Everest 2) K2 3) Kangchenjunga 4) Lhotse",
            "1) Atlantic Ocean 2) Indian Ocean 3) Arctic Ocean 4) Pacific Ocean",
            "1) Leonardo da Vinci 2) Vincent van Gogh 3) Pablo Picasso 4) Michelangelo",
            "1) Vatican City 2) Monaco 3) Nauru 4) San Marino",
            "1) Yen 2) Dollar 3) Euro 4) Pound",
            "1) Joe Biden 2) Donald Trump 3) Barack Obama 4) George W. Bush",
            "1) Sahara Desert 2) Arabian Desert 3) Gobi Desert 4) Kalahari Desert",
            "1) J.K. Rowling 2) Stephen King 3) George R.R. Martin 4) Suzanne Collins",
            "1) H2O 2) CO2 3) O2 4) NaCl",
            "1) Blue Whale 2) Elephant Seal 3) Giraffe 4) Hippopotamus",
            "1) Bill Gates 2) Steve Jobs 3) Elon Musk 4) Jeff Bezos",
            "1) Canberra 2) Sydney 3) Melbourne 4) Brisbane",
            "1) Asia 2) Africa 3) Europe 4) North America",
            "1) Boris Johnson, 2) Jk Simmons 3) Arnold Swartzinegger 4) Ed Sheeren",
            "1) O2 2) CO2 3) N2 4) H2O",
            "1) Tokyo, Japan 2) New York, USA 3) London, UK 4) Paris, France",
            "1) J.R.R. Tolkien 2) C.S. Lewis 3) George R.R. Martin 4) J.K. Rowling",
            "1) C 2) O 3) N 4) H",
            "1) Greenland, 2) Iceland 3) Madagascar 4) New Zealand",
            "1) Angela Merkel, 2) Olaf Scholz, 3) Armin Laschet, 4) Frank-Walter Steinmeier",
            "1) N 2) O 3) C 4) H",
            "1) Amazon River 2) Nile River 3) Yangtze River 4) Mississippi River",
            "1) Harper Lee 2) J.K. Rowling 3) George R.R. Martin 4) Suzanne Collins",
            "1) He 2) H 3) Na 4) N"
        };
        public List<int> correctAnswers = new List<int>
        {
            3, 2, 1, 1, 1, 4, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 2, 2, 3,
            1, 1, 3, 1, 2, 2, 1, 1
        };

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

            Random rnd = new Random();
            int QuestionIndex = rnd.Next(triviaQuestions.Count);
            int AnswerIndex = QuestionIndex;
            int CorrectAnswerIndex = QuestionIndex;

            Question = triviaQuestions[QuestionIndex];
            Possibleanswers = possibleAnswers[AnswerIndex];
            Correctanswer = correctAnswers[CorrectAnswerIndex];
        }

        private void OptionButtons() {

            var mainPanel = new StackPanel();
            mainPanel.AddToRoot();

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
