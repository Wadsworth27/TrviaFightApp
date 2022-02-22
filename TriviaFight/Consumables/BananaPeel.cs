using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight.Consumables
{
    public class BananaPeel : Consumable, IConsumable
    {
        public override string Name { get; set; } = "Banana Peel";

        public override string Description { get; } = "Banana peel reduces enemy's speed to 0 until you answer your next quesiton ";

        public override string Target { get; set; } = "Enemy";
        public override int Quantity { get; set; } = 1;
        public override string ToString()
        {
            return Name;
        }
        public override void Use(Enemy enemy)
        {
            enemy.TemporaryStatModifiers.AddModifier(new StatModifier("Speed", 1, -1 * enemy.Speed));
            Quantity--;
            Console.WriteLine("The enemy slips on your well placed banana peeel and gains no speed until your next attack!" +
                "\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();

        }

    }
}
