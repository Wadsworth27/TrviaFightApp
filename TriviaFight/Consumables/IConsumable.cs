namespace TriviaFight.Consumables
{
    public interface IConsumable
    {
        public void Use(Player player, Enemy enemy, Question question);
    }
}
