using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight.Consumables
{
    public class PocketSand : Consumable, IConsumable
    {
        public override string Name { get; set; } = "PocketSand";

        public override string Description { get; } = "Using your pocket sand to blind your enemy, their odds of hitting you decrease for sveral turns.";

        public override string Target { get; set; } = "Enemy";
        public override int Quantity { get; set; } = 1;
        public override int Price { get; set; } = 100;
        public override string ToString()
        {
            return Name;
        }
        public override void Use(Enemy enemy)
        {
            enemy.TemporaryStatModifiers.AddModifier(new StatModifier("HitPercentage", 4, -100));
            Quantity--;
            Console.WriteLine("You land a direct hit with your pocket sand. The enemy stuggles to see you.");
            Console.ReadKey();
            Console.Clear();

        }
        public PocketSand(int quantity) : base(quantity)
        {

        }

    }
}