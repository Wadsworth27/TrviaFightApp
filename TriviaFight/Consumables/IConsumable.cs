namespace TriviaFight.Consumables
{
    public interface IConsumable
    {
        public void Use(Player player, Enemy enemy, Question question);
        public int GetQuanity();
        public void SetQuanity(int newQuantity);
        public string GetTarget();
    }
}
