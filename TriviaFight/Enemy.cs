using TriviaFight.Equipment;
using TriviaFight.Equipment.Weapons;

namespace TriviaFight
{
    public class Enemy : ITargetable
    {
        Random random = new();
        public string Name { get; set; } = "Enemy";
        public int HitPoints { get; set; }
        public int DamagePotential { get; set; }
        public int HitPercentage { get; set; } = 100;
        public int Stamina { get; set; } = 0;
        private int _speed;
        public int Speed
        {
            get
            {
                Console.WriteLine($"Temp Speed: {TemporaryStatModifiers.TemporarySpeed}, Speed:{_speed }");
                return _speed + TemporaryStatModifiers.TemporarySpeed;
            }
            set
            {
                _speed = value;
            }
        }

        public TemporaryStatModifiers TemporaryStatModifiers{ get; set; } = new();

        public Enemy(int hitpoints, int damage, int speed)
        {
            this.HitPoints = hitpoints;
            this.DamagePotential = damage;
            _speed = speed;
        }

        public virtual int DoDamage()
        {
            return random.Next(this.DamagePotential + 1);
        }
        public virtual void Attack(Player player)
        {
            if (player.Blocking == true)
            {
                Console.WriteLine("Enemy Attack Blocked!!\n");
                player.Blocking = false;
            }
            else
            {
                if (random.Next(100) <= this.HitPercentage)
                {
                    int damage = random.Next(1, this.DamagePotential);
                    player.Hitpoints -= damage;
                    Console.WriteLine($"Enemy hit {player} for {damage} points of damage!");
                }
                else
                {
                    Console.WriteLine("Enemy Missed!");
                }
            }
        }
        public virtual void DropLoot(Player player)
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
        }
    }
}
