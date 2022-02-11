using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight.Equipment
{
    public interface IWeapon
    {
        public int DoDamage();
        public void ChargeSpecial(int charge);
        public int SpecialAttack(Player player);
        public int GetSpecialCharge();
        public int GetSpecialChargeRate();
        public void UseSpecial();
        public string GetSpecialAttackDescription();
    }
}
