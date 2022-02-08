using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APiHandler
{
    public class QuestionModel
    {
        Random random = new Random();
        public string Category { get; set; }=string.Empty;
        public string Difficulty { get; set; } = string.Empty;
        public string Question { get; set; } =string.Empty;
        public string Correct_Answer { get; set; } = string.Empty;
        public List<string>? Incorrect_Answers { get; set; }

        public List<string> GeneratePossibleAnswers() {
            List<string> possibleAnswers = new List<string>(this.Incorrect_Answers);
            int index = random.Next(0, this.Incorrect_Answers.Count + 1);
            possibleAnswers.Insert(index, this.Correct_Answer);
            return possibleAnswers;
        }
        public override string ToString()
        {
            return this.Question.ToString();
        }
    }
    
}
