using TriviaFight.Equipment;

namespace TriviaFight
{
    public abstract class Weapon:IWeapon
    {
        public virtual string Name { get; set; } = "Weapon";
        public virtual int DamagePotential { get; set; }
        public virtual int SpecialChargeRate { get; set; }
        public virtual int SpeedModifier { get; set; }
        public virtual string SpecialAttackDescription { get; set; } = "No Description Avalible";
        public virtual int SpecialMeter { get; set; } = 0;
        public virtual void Reset()
        {
            
        }

        public abstract void Attack(Enemy enemy);
        public abstract void Defend(Player player);

        public abstract void ChargeSpecial(int charge);

        public abstract void SpecialAttack(Player player, Enemy enemy);
        public abstract void UseSpecial();

    }
}
