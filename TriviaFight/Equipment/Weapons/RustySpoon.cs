using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight.Equipment
{
    public class RustySpoon:Weapon,IWeapon
    {
        public new string Name ="Rusty Spoon"; 
        private new int DamagePotential
        {
            get { return 5; }        
        }
        private int specialMeter =0;
        private new int SpecialChargeRate = 50;
        public new int SpecialMeter
        {
            get { return specialMeter; }
        } 
        public void SpecialAttack(Player player, Enemy enemy)
        {
            player.Hitpoints = Math.Min(player.Hitpoints+5, player.MaxHitpoints);
            Console.WriteLine($"{player} Healed to {player.Hitpoints}/{player.MaxHitpoints}");
            enemy.HitPoints-= this.DamagePotential;
            Console.WriteLine($"You did {this.DamagePotential} points of damage with {this.Name}!");
        }
        public void ChargeSpecial(int charge)
        {

            this.specialMeter += charge;
        }
        public void Attack(Enemy enemy)
        {
            Random random = new();
            int damage = random.Next(1, this.DamagePotential+1);
            Console.WriteLine($"You did {damage} points of damage with {this.Name}!");
            enemy.HitPoints -= damage;
        }
        public void Defend(Player player)
        {
            player.Blocking = true;
            player.Weapon.ChargeSpecial(player.Weapon.GetSpecialChargeRate());
        }
        public int GetSpecialChargeRate()
        {
            return this.SpecialChargeRate;
        }
        public int GetSpecialCharge()
        {
            return Math.Min(this.SpecialMeter,100);
        }
        public override string ToString()
        {
            return this.Name;
        }

        public void UseSpecial()
        {
            this.specialMeter = 0;
        }
        public string GetName()
        {
            return Name;
        }
        public string GetSpecialAttackDescription()
        {
            return "Heal player by up to 5 points while doing 5 points of damage to enemy";
        }
    }
}
