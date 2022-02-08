using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight
{
    public class Player
    {

        public string Name { get; set; } = "Player";


        public string AnswerQuestion()
        {
            Console.WriteLine("What is you answer?: ");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "A" | answer == "B" | answer == "C")
            {
                return answer;
            }
            else
                {
                Console.WriteLine("Invalid Input, please try again");
                return AnswerQuestion();
                }


        }
    }
}
