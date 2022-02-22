namespace TriviaFight.Equipment.Weapons
{
    public class Nunchaku : Weapon, IWeapon
    {
        Random random = new();
        public override string Name { get; set; } = "Nunchakus";
        public override int DamagePotential { get; set; } = 1;
        public override int SpecialChargeRate { get; set; } = 100;
        public override int SpeedModifier { get; set; } = -10;
        private int specialMeter = 0;
        public override int SpecialMeter
        {
            get { return Math.Min(specialMeter,100); }
        }
        public override string SpecialAttackDescription { get; set; } =
            "Heal player by up to 5 points while doing 5 points of damage to enemy";
        public override void SpecialAttack(Player player, Enemy enemy)
        {
            DamagePotential += 1;
            Console.WriteLine("Your damage and healing potential has increased by 1 for the duration of this fight!");
            Attack(enemy);
            Attack(enemy);

        }
        public override void SpecialAttack(Enemy enemy,Player player)
        {
            this.DamagePotential += 1;
            Console.WriteLine("Enemy's damage and healing potential has increased by 1 for the duration of this fight!");
            Attack(player);
            Attack(player);

        }
        public override void ChargeSpecial(int charge)
        {

            this.specialMeter += charge;
        }
        public override void Attack(Enemy enemy)
        {
            int total = 0;
            int hitPercentage = 190;
            int damage;
            int hits = 0;
            while (true)
            {
                if (random.Next(100) < hitPercentage)
                {
                    damage = random.Next(1, this.DamagePotential + 1);
                    Console.WriteLine($"You did {damage} points of damage with hit {++hits}!");
                    total += damage;
                    hitPercentage /= 2;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"\nYou did {total} points of damage over {hits} hits with {this.Name}!");
            enemy.Hitpoints -= total;
        }
        public override void Attack(Player player)
        {
            int total = 0;
            int hitPercentage = 190;
            int damage;
            int hits = 0;
            while (true)
            {
                if (random.Next(100) < hitPercentage)
                {
                    damage = random.Next(1, this.DamagePotential + 1);
                    Console.WriteLine($"Enemy did {damage} points of damage with hit {++hits}!");
                    total += damage;
                    hitPercentage /= 2;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"\nEnemy did {total} points of damage over {hits} hits with {this.Name}!");
            player.Hitpoints -= total;
        }
        public override void Defend(Player player)
        {
            player.Weapon.ChargeSpecial(player.Weapon.SpecialChargeRate);
            int total = 0;
            int hitPercentage = 190;
            int heal;
            int hits = 0;
            while (true)
            {
                if (random.Next(100) < hitPercentage)
                {
                    heal = random.Next(1, this.DamagePotential + 1);
                    Console.WriteLine($"You healed for {heal} points of damage with form {++hits}!");
                    total += heal;
                    hitPercentage /= 2;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"\nYou healed for {total} points of damage over {hits} forms!");
            player.Hitpoints = Math.Min(player.MaxHitpoints, player.Hitpoints + total);
        }
        public override void Defend(Enemy enemy)
        {
            enemy.Weapon.ChargeSpecial(enemy.Weapon.SpecialChargeRate);
            int total = 0;
            int hitPercentage = 190;
            int heal;
            int hits = 0;
            while (true)
            {
                if (random.Next(100) < hitPercentage)
                {
                    heal = random.Next(1, this.DamagePotential + 1);
                    Console.WriteLine($"Enemy healed for {heal} points of damage with form {++hits}!");
                    total += heal;
                    hitPercentage /= 2;
                    Thread.Sleep(1000);
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"\nYou healed for {total} points of damage over {hits} forms!\n");
            enemy.Hitpoints = Math.Min(enemy.MaxHitpoints, enemy.Hitpoints + total);
        }
        public override string ToString()
        {
            return this.Name;
        }

        public override void UseSpecial()
        {
            this.specialMeter = 0;
        }

        public override void Reset()
        {
            DamagePotential = 1;
        }
    }
}

