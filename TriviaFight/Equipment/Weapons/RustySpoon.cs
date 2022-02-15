namespace TriviaFight.Equipment
{
    public class RustySpoon : Weapon, IWeapon
    {
        public override string Name { get; set; } = "Rusty Spoon";
        public override int DamagePotential { get; set; } = 5;
        private int specialMeter = 0;
        public override int SpecialChargeRate { get; set; } = 50;
        public override int SpecialMeter
        {
            get { return Math.Min(specialMeter,100); }
        }
        public override int SpeedModifier { get; set; } = 10;
        public override string SpecialAttackDescription { get; set; } =
            "Heal player by up to 5 points while doing 5 points of damage to enemy";

        public override void SpecialAttack(Player player, Enemy enemy)
        {
            player.Hitpoints = Math.Min(player.Hitpoints + 5, player.MaxHitpoints);
            Console.WriteLine($"{player} Healed to {player.Hitpoints}/{player.MaxHitpoints}");
            enemy.HitPoints -= this.DamagePotential;
            Console.WriteLine($"You did {this.DamagePotential} points of damage with {this.Name}!");
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
            enemy.HitPoints -= damage;
        }
        public override void Defend(Player player)
        {
            player.Blocking = true;
            player.Weapon.ChargeSpecial(player.Weapon.SpecialChargeRate);
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
