namespace TriviaFight.Equipment
{
    public interface IWeapon
    {
        public void Attack(Enemy enemy);
        public void Defend(Player player);
        public void ChargeSpecial(int charge);
        public void SpecialAttack(Player player, Enemy enemy);
        public void UseSpecial();
        public void Reset();
    }
}
