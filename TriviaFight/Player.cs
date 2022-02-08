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


        public int AnswerQuestion()
        {
            Console.WriteLine("What is you answer?: ");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "1" | answer == "2" | answer == "3" | answer == "4")
            {
                return int.Parse(answer);
            }
            else
                {
                Console.WriteLine("Invalid Input, please try again");
                return AnswerQuestion();
                }


        }
    }
}
