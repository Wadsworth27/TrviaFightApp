using TriviaFight.Equipment;

namespace TriviaFight
{
    public class Player
    {

        public string Name { get; set; } = "Player";
        public int MaxHitpoints { get; set; } = 25;
        public int Hitpoints { get; set; } = 25;
        public IWeapon Weapon { get; set; } = null;
        public bool Blocking { get; set; } = false; 
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
        public string SetMode()
        {
            while (true)
            {
                bool specialAvalible = false;
                if (this.Weapon.GetSpecialCharge() == 100)
                {
                    specialAvalible = true;

                }
                Console.WriteLine($"Please set strategy for this round:\n1. Attack - Attempt to damage enemy.\n2. Defense - Block Enemy atatck and charge special meter. " +
                    $"Currently {this.Weapon.GetSpecialCharge()}/100");
                if (specialAvalible)
                {
                    Console.WriteLine($"3. Special Attack - {Weapon.GetSpecialAttackDescription()}\n\n");
                }
                Console.Write("Please enter seletion: ");
                string? response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        return "Attack";
                    case "2":
                        return "Defense";
                    case "3":
                        if (specialAvalible)
                        {
                            return "Special";
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Invalid Input");
            }

            }
            public void EquipWeapon(IWeapon w)
            {
                this.Weapon = w;
            }

        }
    }
