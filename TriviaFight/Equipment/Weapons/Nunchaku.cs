namespace TriviaFight.Equipment.Weapons
{
    public class Nunchaku : Weapon, IWeapon
    {
        Random random = new();
        public new string Name = "Nunchakus";
        private int damagePotential = 1;
        public new int DamagePotential
        {
            get { return damagePotential; }
        }
        private int specialMeter = 0;
        private new int SpecialChargeRate = 100;
        private int speedModifier = -10;
        public new int SpecialMeter
        {
            get { return specialMeter; }
        }
        public void SpecialAttack(Player player, Enemy enemy)
        {
            damagePotential += 1;
            Console.WriteLine("Your damage and healing potential has increased by 1 for the duration of this fight!");
            Attack(enemy);
            Attack(enemy);

        }
        public void ChargeSpecial(int charge)
        {

            this.specialMeter += charge;
        }
        public void Attack(Enemy enemy)
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
            enemy.HitPoints -= total;
        }
        public void Defend(Player player)
        {
            player.Weapon.ChargeSpecial(player.Weapon.GetSpecialChargeRate());
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
        public int GetSpecialChargeRate()
        {
            return this.SpecialChargeRate;
        }
        public int GetSpecialCharge()
        {
            return Math.Min(this.SpecialMeter, 100);
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
            return "Power up your nunchucks while delivering a devistating double attack!";
        }
        public override void Reset()
        {
            damagePotential = 1;
        }
        public string GetName()
        {
            return Name;
        }

        public int GetSpeedModifier()
        {
            return speedModifier;
        }
    }
}

