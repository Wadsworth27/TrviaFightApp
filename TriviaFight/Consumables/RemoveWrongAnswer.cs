using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight.Consumables
{
    public class RemoveWrongAnswer:IConsumable
    {
        public int Quantity = 1;

        public void Use(Player player, Enemy enemy, Question question)
        {
            Random random = new Random();
            int choice = random.Next(question.incorrectAnswers.Count);
            question.incorrectAnswers.RemoveAt(choice);
        }
    }
}
