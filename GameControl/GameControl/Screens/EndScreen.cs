using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;

using RenderingLibrary.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameControlUI.Screens
{
    partial class EndScreen
    {
        public List<(string, int)> highScoreList { get; set; }
        partial void CustomInitialize()
        {
        
        }

        private string _highScoreFileName;

        public void UpdateHighScores(string name, int score, string reason)
        {
            if (string.IsNullOrWhiteSpace(_highScoreFileName)) throw new InvalidOperationException("LoadHighScores(highScoreFileName) must be called before UpdateHighScores.");
            if (highScoreList == null) highScoreList = new List<(string, int)>();
            highScoreList.Add((name.Trim(), score));
            highScoreList = highScoreList.OrderByDescending(x => x.Item2).ThenBy(x => x.Item1).Take(10).ToList();
            File.WriteAllLines(_highScoreFileName, highScoreList.Select(x => $"{x.Item1},{x.Item2}"));

            this.ReasonLabel.Text = string.IsNullOrEmpty(reason) ? "":("Reason: " + reason);

            UpdateHighScoreLabels(highScoreList);
        }

        public List<(string, int)> LoadHighScores(string highScoreFileName)
        {
            _highScoreFileName = highScoreFileName;
            List<(string, int)> highScoreLines = new List<(string, int)>();

            using (StreamReader sr = new StreamReader(highScoreFileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] splitString = line.Split(',');
                    if (splitString.Length != 2) continue;

                    var playerName = splitString[0].Trim();
                    if (!int.TryParse(splitString[1].Trim(), out int parsedScore)) continue;

                    highScoreLines.Add((playerName, parsedScore));
                }
            }

            highScoreLines = highScoreLines.OrderByDescending(x => x.Item2).ThenBy(x => x.Item1).Take(10).ToList();

            highScoreList = highScoreLines;
            UpdateHighScoreLabels(highScoreLines);

            return highScoreLines;
        }
        private void UpdateHighScoreLabels(List<(string, int)> scores)
        {
            var padded = scores.Concat(Enumerable.Repeat(("", 0), 10)).Take(10).ToList();

            this.Top1.Text = FormatScore(padded[0]);
            this.Top2.Text = FormatScore(padded[1]);
            this.Top3.Text = FormatScore(padded[2]);
            this.Top4.Text = FormatScore(padded[3]);
            this.Top5.Text = FormatScore(padded[4]);
            this.Top6.Text = FormatScore(padded[5]);
            this.Top7.Text = FormatScore(padded[6]);
            this.Top8.Text = FormatScore(padded[7]);
            this.Top9.Text = FormatScore(padded[8]);
            this.Top10.Text = FormatScore(padded[9]);
        }
        private string FormatScore((string name, int score) entry)
        {
            if (string.IsNullOrWhiteSpace(entry.name)) return "";
            return $"{entry.name} - {entry.score}";
        }
    }
}
