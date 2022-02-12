using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight.Equipment
{
    public interface IWeapon
    {
        public void Attack(Enemy enemy);
        public void Defend(Player player);
        public void ChargeSpecial(int charge);
        public void SpecialAttack(Player player, Enemy enemy);
        public int GetSpecialCharge();
        public int GetSpecialChargeRate();
        public void UseSpecial();
        public string GetSpecialAttackDescription();
        public void Reset();
    }
}
