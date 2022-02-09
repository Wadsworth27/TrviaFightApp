namespace TriviaFight
{
    public class Player
    {

        public string Name { get; set; } = "Player";
        public int Hitpoints { get; set; } = 1;
        public int DamagePotential { get; set; } = 5;

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

        public int DoDamage()
            {
                Random random = new();
                return random.Next(this.DamagePotential);
            }
        }
    }
