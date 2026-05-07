using System;
using System.Collections.Generic;

namespace Cerda_Trivia
{
    internal class TriviaManager
    {
        private (string Question, string[] Answers, int CorrectIndex) AllQuestionsInfo;

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
            "What is the chemical symbol for sodium?"
        };

        // Each inner string[] contains separate answer choices for the corresponding question
        public List<string[]> possibleAnswers = new List<string[]>
        {
            new[] { "Berlin", "Madrid", "Paris", "Rome" },
            new[] { "Earth", "Jupiter", "Mars", "Saturn" },
            new[] { "William Shakespeare", "Charles Dickens", "Jane Austen", "Mark Twain" },
            new[] { "Au", "Ag", "Fe", "Hg" },
            new[] { "Mount Everest", "K2", "Kangchenjunga", "Lhotse" },
            new[] { "Atlantic Ocean", "Indian Ocean", "Arctic Ocean", "Pacific Ocean" },
            new[] { "Leonardo da Vinci", "Vincent van Gogh", "Pablo Picasso", "Michelangelo" },
            new[] { "Vatican City", "Monaco", "Nauru", "San Marino" },
            new[] { "Yen", "Dollar", "Euro", "Pound" },
            new[] { "Joe Biden", "Donald Trump", "Barack Obama", "George W. Bush" },
            new[] { "Sahara Desert", "Arabian Desert", "Gobi Desert", "Kalahari Desert" },
            new[] { "J.K. Rowling", "Stephen King", "George R.R. Martin", "Suzanne Collins" },
            new[] { "H2O", "CO2", "O2", "NaCl" },
            new[] { "Blue Whale", "Elephant Seal", "Giraffe", "Hippopotamus" },
            new[] { "Bill Gates", "Steve Jobs", "Elon Musk", "Jeff Bezos" },
            new[] { "Canberra", "Sydney", "Melbourne", "Brisbane" },
            new[] { "Asia", "Africa", "Europe", "North America" },
            new[] { "Boris Johnson", "Rishi Sunak", "Theresa May", "David Cameron" },
            new[] { "O2", "CO2", "N2", "H2O" },
            new[] { "Tokyo, Japan", "New York, USA", "London, UK", "Paris, France" },
            new[] { "J.R.R. Tolkien", "C.S. Lewis", "George R.R. Martin", "J.K. Rowling" },
            new[] { "C", "O", "N", "H" },
            new[] { "Greenland", "Iceland", "Madagascar", "New Zealand" },
            new[] { "Angela Merkel", "Olaf Scholz", "Armin Laschet", "Frank-Walter Steinmeier" },
            new[] { "N", "O", "C", "H" },
            new[] { "Amazon River", "Nile River", "Yangtze River", "Mississippi River" },
            new[] { "Harper Lee", "J.K. Rowling", "George R.R. Martin", "Suzanne Collins" },
            new[] { "He", "H", "Na", "N" },
            new[] { "Mauna Loa", "Tamu Massif", "Mauna Kea", "Olympus Mons" },
            new[] { "Emmanuel Macron", "Nicolas Sarkozy", "François Hollande", "Jacques Chirac" },
            new[] { "Na", "S", "N", "K" }
        };

        // Keep using 1-based indices (same as original). Ensure the list aligns with triviaQuestions count.
        public List<int> correctAnswers = new List<int>
        {
            3, 2, 1, 1, 1, 4, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 2, 2, 3,
            1, 1, 3, 2, 3, 2, 1, 1, 2, 1,
            1
        };

        public TriviaManager()
        {
            var rnd = new Random();
            int questionIndex = rnd.Next(triviaQuestions.Count);
            AllQuestionsInfo = (triviaQuestions[questionIndex], possibleAnswers[questionIndex], correctAnswers[questionIndex]);
        }
    }
}
