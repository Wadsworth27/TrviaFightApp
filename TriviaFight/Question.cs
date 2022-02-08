using APiHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight
{
    public class Question
    {
        public Random random = new Random();
        public string category;
        public string difficulty;
        public string questionText;
        public string correctAnswer;
        public List<string>? incorrectAnswers;
        public Question(QuestionModel q)
        {
            category = q.Category;
            difficulty = q.Difficulty;
            questionText = q.Question.Replace("&quot;", "\"").Replace("&#039;", "'").Replace("&amp;", "&");
            correctAnswer = q.Correct_Answer;
            incorrectAnswers = q.Incorrect_Answers;

        }
        public List<string> GeneratePossibleAnswers()
        {
            List<string> possibleAnswers = new List<string>(this.incorrectAnswers);
            int index = random.Next(0, this.incorrectAnswers.Count + 1);
            possibleAnswers.Insert(index, this.correctAnswer);
            for (int i = 0; i < possibleAnswers.Count; i++)
            {
                possibleAnswers[i] = $"{i + 1}: {possibleAnswers[i]}";
            }
            return possibleAnswers;
        }
        private bool CorrectAnswer(string answer)
        {
            return answer.Contains(correctAnswer);
        }
        public bool CheckAnswer(List<string> answers,int answer)
        {
            int v = answers.FindIndex(CorrectAnswer);
            return v == answer - 1;
        }
        public override string ToString()
        {
            return this.questionText.ToString();
        }
    }
}
