using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight
{
    public class MultipleChoiceQuestion:Question
    {
        public List<Answer>? Answers { get; set; }
    }
}
