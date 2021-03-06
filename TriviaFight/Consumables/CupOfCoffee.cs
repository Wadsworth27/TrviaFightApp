namespace TriviaFight.Consumables
{
    public class CupOfCoffee : Consumable, IConsumable
    {
        public override string Name { get; set; } = "Cup of Coffee";

        public override string Description { get; } = "Big ol' cup of joe. Increases speed stat by 10 for 3 turns.";

        public override string Target { get; set; } = "Player";
        public override int Quantity { get; set; } = 1;
        public override int Price { get; set; } = 50;
        public override string ToString()
        {
            return Name;
        }
        public override void Use(Player player)
        {
            player.TemporaryStatModifiers.AddModifier(new StatModifier("Speed", 3, 10));
            Quantity--;
            Console.WriteLine("You chug a big cup of coffee and feel very alert!\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
        public CupOfCoffee(int quantity) : base(quantity)
        {

        }

    }
}
