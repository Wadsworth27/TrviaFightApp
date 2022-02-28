using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TriviaFight.Equipment
{
    public class InflateableSword : Weapon, IWeapon
    {
        public Random random = new Random();
        
        public override string Name { get; set; } = "Inflatable Sword";
        public override int DamagePotential { get; set; } = 0;
        private int specialMeter = 0;
        public override int SpecialChargeRate { get; set; } = 50;
        public override int SpecialMeter
        {
            get { return Math.Min(specialMeter, 100); }
        }
        public override int SpeedModifier { get; set; } = 10;
        public override string SpecialAttackDescription { get; set; } =
            "Pop the sword, dealing max damage and creating a new instance with new damage potential.";
        public InflateableSword()
        {
            DamagePotential = Random.Shared.Next(1, 15);
        }

        public override void SpecialAttack(Player player, Enemy enemy)
        {
            enemy.Hitpoints -= this.DamagePotential;
            Console.WriteLine($"You pop the sword in {enemy.Name}'s face, doing {this.DamagePotential} points of damage with {this.Name}!");
            DamagePotential= Random.Shared.Next(1, 15);
            Console.WriteLine($"You blow up another inflatable sword, with a damage potential of {DamagePotential}");
        }
        public override void SpecialAttack(Enemy enemy, Player player)
        {
            player.Hitpoints -= this.DamagePotential;
            Console.WriteLine($"{enemy.Name} pops the sword in your face, doing {this.DamagePotential} points of damage with {this.Name}!");
            DamagePotential = Random.Shared.Next(1, 15);
            Console.WriteLine($"They blow up another inflatable sword, with a damage potential of {DamagePotential}");
        }
        public override void ChargeSpecial(int charge)
        {

            this.specialMeter += charge;
        }
        public override void Attack(Enemy enemy)
        {
            Random random = new();
            int damage = random.Next(1, this.DamagePotential + 1);
            Console.WriteLine($"You did {damage} points of damage with {this.Name}!");
            enemy.Hitpoints -= damage;
        }
        public override void Attack(Player player)
        {
            Random random = new();
            int damage = random.Next(1, this.DamagePotential + 1);
            Console.WriteLine($"Enemy did {damage} points of damage with {this.Name}!");
            player.Hitpoints -= damage;
        }
        public override void Defend(Player player)
        {
            player.Blocking = true;
            player.Weapon.ChargeSpecial(player.Weapon.SpecialChargeRate);
        }
        public override void Defend(Enemy enemy)
        {
            enemy.Weapon.ChargeSpecial(enemy.Weapon.SpecialChargeRate);
            Console.WriteLine($"{enemy.Name} is charging their special");
        }
        public override string ToString()
        {
            return this.Name;
        }

        public override void UseSpecial()
        {
            this.specialMeter = 0;
        }


    }
}
