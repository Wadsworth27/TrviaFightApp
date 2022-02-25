namespace TriviaFight.Consumables
{
    public abstract class Consumable
    {
        public abstract string Name { get; set; }
        public abstract string Description { get; }
        public abstract string Target { get; set; }
        public abstract int Quantity { get; set; }
        public virtual void Use(Player player)
        {

        }
        public virtual void Use(Enemy enemy)
        {

        }
        public virtual void Use(Question question)
        {

        }
        public override abstract string ToString();
        public virtual int Price { get; set; } = 10;
        public Consumable(int quantity)
        {
            Quantity = quantity;
        }

    }
}
