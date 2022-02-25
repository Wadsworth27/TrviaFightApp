namespace TriviaFight.Consumables
{
    public class ClarityPotion : Consumable, IConsumable
    {
        public override string Name { get; set; } = "Clarity Potion";
        public override int Quantity { get; set; } = 1;
        public override string Target { get; set; } = "Question";
        public override string Description { get; } = "Remove one wrong answer";
        public override int Price { get; set; } = 50;

        public ClarityPotion(int quantity) : base(quantity)
        {

        }

        public override void Use(Question question)
        {

            if (question.incorrectAnswers.Any())
            {
                Random random = new Random();
                int choice = random.Next(question.incorrectAnswers.Count);
                question.incorrectAnswers.RemoveAt(choice);
                Quantity--;
            }
            else
            {
                Console.WriteLine("No incorrect answers left to remove!");
            }


        }
        public override string ToString()
        {
            return Name;
        }
    }
}
