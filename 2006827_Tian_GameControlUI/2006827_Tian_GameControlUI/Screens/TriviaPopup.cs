using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;

using RenderingLibrary.Graphics;

using System.Linq;
using System.Windows.Forms;

namespace GameControlUI.Screens
{
    partial class TriviaPopup
    {
        public string lastClickedAnswerChoice { get; set; }
        partial void CustomInitialize()
        {
            lastClickedAnswerChoice = "";
            this.AnswerChoiceA.Click += (_, _) => RecordClick("A");
            this.AnswerChoiceB.Click += (_, _) => RecordClick("B");
            this.AnswerChoiceC.Click += (_, _) => RecordClick("C");
            this.AnswerChoiceD.Click += (_, _) => RecordClick("D");
        }

        public void RecordClick(string choice)
        {
            lastClickedAnswerChoice = choice;
        }
        public void ResetClicked()
        {
            lastClickedAnswerChoice = "";
        }

        public void UpdatePopup(string question, string a, string b, string c, string d, int questionNumber, int totalQuestions)
        {
            this.QuestionText.Text = question;
            this.AnswerChoiceA.Text = a;
            this.AnswerChoiceB.Text = b;
            this.AnswerChoiceC.Text = c;
            this.AnswerChoiceD.Text = d;
            if (totalQuestions != 0) this.PercentBarInstance.BarPercent = (questionNumber - 1) / totalQuestions;
        }

        public string GetRecentClicked()
        {
            return lastClickedAnswerChoice;
        }
    }
}
