using TriviaFight.Equipment;
using TriviaFight.Equipment.Weapons;

namespace TriviaFight
{
    public class Player
    {

        public string Name { get; set; } = "Steve";
        public int MaxHitpoints { get; set; } = 25;
        public int Hitpoints { get; set; } = 25;
        public IWeapon Weapon { get; set; } = null;
        public List<IWeapon> WeaponList = new List<IWeapon>();
        public bool Blocking { get; set; } = false; 
        
        public Player(string name)
        {
            Name = name;
            RustySpoon spoon = new();
            Nunchaku nc = new();
            WeaponList.Add(spoon);
            WeaponList.Add(nc);
            Weapon=spoon;

        }
        
        public int AnswerQuestion()
        {
            Console.WriteLine("What is you answer?: ");
            string? answer = Console.ReadLine().ToUpper();
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
                        Console.Clear();
                        return "Attack";
                    case "2":
                        Console.Clear();
                        return "Defense";
                    case "3":
                        if (specialAvalible)
                        {
                            Console.Clear();
                            return "Special";
                        }
                        break;
                    default:
                        break;
                }
                Console.Clear();
                Console.WriteLine("Invalid Input");
            }

            }
            public void EquipWeapon(IWeapon w)
            {
                this.Weapon = w;
            }
        public void AddWeapon(IWeapon w)
        {
            WeaponList.Add(w);
        }
        public void ChooseWeapon()
        {
            for (int i = 0; i < WeaponList.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {this.WeaponList[i]}\n");
            }
            int choice;
            if (Int32.TryParse(Console.ReadLine(), out choice))
            {
                if (choice <= WeaponList.Count)
                {
                    this.EquipWeapon(WeaponList[choice-1]);
                }
                else
                {
                    ChooseWeapon();
                }
            } else
            {
                ChooseWeapon();
            }
            Console.WriteLine($"{ this.Weapon} Equiped!\n\nPress any Key to continue.");
            string? _ = Console.ReadLine();
            Console.Clear();
        }
        public override string ToString()
        {
            return this.Name;
        }
        public void Heal()
        {
            Hitpoints = MaxHitpoints;
        }

    }
    }
