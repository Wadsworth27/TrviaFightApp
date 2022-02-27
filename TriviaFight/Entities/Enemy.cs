using TriviaFight.Equipment.Weapons;

namespace TriviaFight
{
    public class Enemy
    {
        readonly Random random = new();
        public virtual string Name { get; set; } = "Enemy";
        public virtual int Hitpoints { get; set; } = 1;
        public virtual int MaxHitpoints { get; set; } = 25;
        private int _hitPercentage = 100;
        public virtual int HitPercentage
        {
            get
            {
                return _hitPercentage + TemporaryStatModifiers.TemporaryHitPercentage;
            }
            set
            {
                _hitPercentage = value;
            }
        }
        public virtual int DefendPercentage { get; set; } = 20;
        public virtual int Stamina { get; set; } = 0;
        public virtual int ExperienceReward { get; set; } = 100;
        public virtual Weapon Weapon { get; set; }
        private int _speed;
        public virtual int Speed
        {
            get
            {
                return _speed + TemporaryStatModifiers.TemporarySpeed;
            }
            set
            {
                _speed = value;
            }
        }

        public TemporaryStatModifiers TemporaryStatModifiers { get; set; } = new();

        public Enemy(int hitpoints, int speed, Weapon weapon)
        {
            this.Hitpoints = hitpoints;
            this.MaxHitpoints = hitpoints;
            _speed = speed;
            Weapon = weapon;
        }
        public Enemy()
        {
        }
        public virtual void TakeTurn(Player player)
        {
            if (player.Blocking == true)
            {
                Console.WriteLine("Enemy Attack Blocked!!\n");
                player.Blocking = false;
            }
            else
            {
                int randomint = random.Next(100);
                if (randomint <= this.DefendPercentage & Weapon.SpecialMeter < 100)
                {
                    Weapon.Defend(this);
                }
                else if (randomint <= this.HitPercentage)
                {
                    if (Weapon.SpecialMeter == 100)
                    {
                        Weapon.UseSpecial();
                        Weapon.SpecialAttack(this, player);
                    }
                    else
                        Weapon.Attack(player);
                }
                else
                {
                    Console.WriteLine("Enemy Missed!");
                    if (Weapon.SpecialMeter == 100)
                    {
                        Console.WriteLine("Looks like they tried to take a big shot...");
                        Weapon.UseSpecial();
                    }
                }
            }
        }
        public virtual void DefeatDrops(Player player)
        {
            Nunchaku nc = new();
            Console.WriteLine("Weapon found!");
            bool existing = false;
            foreach (Weapon weapon in player.WeaponList)
            {
                if (weapon.Name == nc.Name)
                {
                    existing = true;
                }
            }
            if (existing)
            {
                Console.WriteLine($"You already have {nc}");
            }
            else
            {
                player.AddWeapon(nc);
            }
            player.Experience += ExperienceReward;
            player.CheckForLevelUp();
            Console.WriteLine($"Player gained {ExperienceReward} Exp");
        }
    }
}
