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
        public int SpecialAttack(Player player)
        {
            player.Hitpoints = Math.Min(player.Hitpoints+5, player.MaxHitpoints);
            Console.WriteLine($"{player} Healed to {player.Hitpoints}/{player.MaxHitpoints}");
            return this.DamagePotential;
        }
        public void ChargeSpecial(int charge)
        {

            this.specialMeter += charge;
        }
        public int DoDamage()
        {
            Random random = new();
            return random.Next(this.DamagePotential);
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

        public string GetSpecialAttackDescription()
        {
            return "Heal player by up to 5 points while doing 5 points of damage to enemy";
        }
    }
}
