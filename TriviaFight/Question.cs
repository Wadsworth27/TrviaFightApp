using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight
{
    public class Question
    {
        public String Text { get; set; }= String.Empty;
        public Answer CorrectAnswer { get; set; } = new Answer();

        public override string ToString()
        {
            return this.Text;
        }

    }
}
