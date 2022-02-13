namespace TriviaFight.Consumables
{
    public class RemoveWrongAnswer : IConsumable
    {
        public string Name = "ClearSight Potion";
        private int quantity = 1;
        public string target = "Question";

        public int GetQuanity()
        {
            return quantity;
        }

        public void SetQuanity(int newQuantity)
        {
            quantity = newQuantity;
        }

        public void Use(Player player, Enemy enemy, Question question)
        {
            Random random = new Random();
            int choice = random.Next(question.incorrectAnswers.Count);
            question.incorrectAnswers.RemoveAt(choice);
            quantity--;
            if (quantity == 0)
            {
                player.Consumables.RemoveAt(player.Consumables.FindIndex(x => x.ToString() == Name));
            }
        }
        public override string ToString()
        {
            return Name;
        }

        public string GetTarget()
        {
            return target;
        }
    }
}
