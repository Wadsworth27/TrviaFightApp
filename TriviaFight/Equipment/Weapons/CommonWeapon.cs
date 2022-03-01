namespace TriviaFight.Equipment
{
    public class CommonWeapon : Weapon, IWeapon
    {
        public override string Name { get; set; } = "Rusty Spoon";
        public override int DamagePotential { get; set; } = 5;
        private int specialMeter = 0;
        public override int SpecialChargeRate { get; set; } = 50;
        public override int SpecialMeter
        {
            get { return Math.Min(specialMeter, 100); }
        }
        public override int SpeedModifier { get; set; } = 10;
        public override string SpecialAttackDescription { get; set; } = "Vampire Strike";
        public int value = 100;

        public override void SpecialAttack(Player player, Enemy enemy)
        {
            player.Hitpoints = Math.Min(player.Hitpoints + DamagePotential, player.MaxHitpoints);
            Console.WriteLine($"{player} Healed to {player.Hitpoints}/{player.MaxHitpoints}");
            enemy.Hitpoints -= this.DamagePotential;
            Console.WriteLine($"You did {this.DamagePotential} points of damage with {this.Name}!");
        }
        public override void SpecialAttack(Enemy enemy, Player player)
        {
            enemy.Hitpoints = Math.Min(enemy.Hitpoints + DamagePotential, enemy.MaxHitpoints);
            Console.WriteLine($"{enemy} Healed to {enemy.Hitpoints}/{enemy.MaxHitpoints}");
            player.Hitpoints -= this.DamagePotential;
            Console.WriteLine($"{enemy.Name} did {this.DamagePotential} points of damage with {this.Name}!");
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
            Console.WriteLine("Enemy is charging their special");
        }
        public override string ToString()
        {
            return $"{this.Name} : \nDamage Potential:{DamagePotential}\nSpeed Modifier:{SpeedModifier}     " +
                $"Special attack:{SpecialAttackDescription}\n\n";
        }

        public override void UseSpecial()
        {
            this.specialMeter = 0;
        }


    }
}
