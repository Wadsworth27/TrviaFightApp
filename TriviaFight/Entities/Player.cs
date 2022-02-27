using TriviaFight.Consumables;
using TriviaFight.Equipment;
using TriviaFight.Equipment.Weapons;

namespace TriviaFight
{
    public class Player
    {

        public string Name { get; set; } = "Steve";
        public int MaxHitpoints { get; set; } = 50;
        public int Hitpoints { get; set; } = 50;
        public Weapon Weapon { get; set; }
        public List<Weapon> WeaponList = new List<Weapon>();
        public bool Blocking { get; set; } = false;
        public List<Consumable> Consumables = new List<Consumable>();
        public ConsumableInventory ConsumableInventory = new ConsumableInventory();
        private int speed = 50;
        public int Gold { get; set; } = 1500;
        public int Experience {get;set;} = 0;
        public int Speed
        {
            get
            {
                return speed + TemporaryStatModifiers.TemporarySpeed + Weapon.SpeedModifier;
            }
            set
            {
                speed = value;
            }
        }
        public int Stamina { get; set; } = 0;
        public int Level { get; set; } = 1;
        private Dictionary<int, int> LevelExperienceRequired = new Dictionary<int, int>
        {
            { 1, 0 },
            { 2, 100 },
            {3,300},
            { 4,1000000}
        };
        public TemporaryStatModifiers TemporaryStatModifiers { get; set; } = new();

        public Player(string name)
        {
            Name = name;
            RustySpoon spoon = new();
            WeaponList.Add(spoon);
            Weapon = spoon;
            ClarityPotion rw = new(5);
            CupOfCoffee coffee = new(5);
            PocketSand ps = new(5);
            ConsumableInventory.AddConsumable(ps);
            ConsumableInventory.AddConsumable(rw);
            ConsumableInventory.AddConsumable(coffee);

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
            Console.WriteLine($"Player Name : {Name}\n\nLevel : {Level}     Gold: {Gold}    Experience:{Experience}\nHitpoints : {MaxHitpoints}     Speed:{Speed}\nWeapon : {Weapon}\n\n\n");
        }
        public void CheckForLevelUp()
        {
            while (Experience >= LevelExperienceRequired[Level + 1])
            {
                Level++;
                MaxHitpoints += 5;
                Hitpoints += 5;
                Speed += 5;
                Console.WriteLine($"You have leveled up to level {Level}");
            }
        }


    }
}
