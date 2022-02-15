using TriviaFight.Consumables;
using TriviaFight.Equipment;

namespace TriviaFight
{
    public class Player
    {

        public string Name { get; set; } = "Steve";
        public int MaxHitpoints { get; set; } = 1;
        public int Hitpoints { get; set; } = 25;
        public int Level { get; set; } = 1;
        public Weapon Weapon { get; set; }
        public List<Weapon> WeaponList = new List<Weapon>();
        public bool Blocking { get; set; } = false;
        public List<IConsumable> Consumables= new List<IConsumable>();
        public int Speed { get; set; } = 50;
        public int Stamina { get; set; } = 0;

        public Player(string name)
        {
            Name = name;
            RustySpoon spoon = new();
            WeaponList.Add(spoon);
            Weapon = spoon;
            RemoveWrongAnswer rw = new();
            AddConsumable(rw);
            AddConsumable(rw);

        }

        public string SetMode()
        {
            while (true)
            {
                bool specialAvalible = false;
                if (this.Weapon.SpecialMeter == 100)
                {
                    specialAvalible = true;

                }
                Console.WriteLine($"Please set strategy for this round:\n1. Attack - Attempt to damage enemy.\n2. Defense - Block Enemy atatck and charge special meter. " +
                    $"Currently {this.Weapon.SpecialMeter}/100");
                if (specialAvalible)
                {
                    Console.WriteLine($"3. Special Attack - {Weapon.SpecialAttackDescription}\n\n");
                }
                Console.WriteLine("9. Quit");
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
                    case "9":
                        Console.Clear();
                        return "Quit";
                    default:
                        break;
                }
                Console.Clear();
                Console.WriteLine("Invalid Input");
            }

        }
        public void EquipWeapon(Weapon w)
        {

            this.Weapon = w;
        }
        public void AddWeapon(Weapon w)
        {
            WeaponList.Add(w);
        }
        public void ChooseWeapon()
        {
            Console.WriteLine("Choose your Weapon!\n\n");
            for (int i = 0; i < WeaponList.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {this.WeaponList[i]}\n");
            }
            int choice;
            if (Int32.TryParse(Console.ReadLine(), out choice))
            {
                if (choice <= WeaponList.Count)
                {
                    this.EquipWeapon(WeaponList[choice - 1]);
                }
                else
                {
                    ChooseWeapon();
                }
            }
            else
            {
                ChooseWeapon();
            }
            Console.WriteLine($"{ this.Weapon} Equiped!\n\nPress any Key to continue.");
            string? _ = Console.ReadLine();
            Console.Clear();
        }
        public void AddConsumable(IConsumable consumable)
        {
            bool existing = false;
            foreach (IConsumable c in Consumables)
            {
                if (c.ToString() == consumable.ToString())
                {
                    c.SetQuanity(consumable.GetQuanity() + c.GetQuanity());
                    existing = true;
                }
            }
            if (!existing)
            {
                Consumables.Add(consumable);

            }
        }
        public void DisplayConsumables()
        {
            if (Consumables.Count == 0)
            {
                Console.WriteLine("No items to display. Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                int counter = 1;
                foreach (IConsumable c in Consumables)
                {
                    Console.WriteLine($"{counter}: {c} Quantity {c.GetQuanity()}\n");
                    counter++;
                }
            }
            
        }
        public void DisplayConsumables(List<IConsumable> consumables)
        {
            if (consumables.Count == 0)
            {
                Console.WriteLine("No items to display. Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                int counter = 1;
                foreach (IConsumable c in consumables)
                {
                    Console.WriteLine($"{counter}: {c} Quantity {c.GetQuanity()}\n");
                    counter++;
                }
            }

        }
        public override string ToString()
        {
            return this.Name;
        }
        public int GetSpeed()
        {
            return Speed + Weapon.SpeedModifier;
        }

        public void Reset()
        {
            Hitpoints = MaxHitpoints;
            Stamina = 0;
            Weapon.Reset();
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Player Name : {Name}\n\nLevel : {Level}\nHitpoints : {MaxHitpoints}\nWeapon : {Weapon}\n\n\n");
        }
        public List<IConsumable> GetListOfConsumablesByTargetType(string target)
        {
            List<IConsumable> targetList = new();
            foreach (var consumable in Consumables)
            {
                if (consumable.GetTarget() == target)
                {
                    targetList.Add(consumable);
                }
            }
            return targetList;
        }

    }
}
