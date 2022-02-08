namespace TriviaFight
{
    public class Answer : IComparable<Answer>
    {
        public int Order { get; set; } = 0;
        public string Text = string.Empty;
        public bool Correct { get; set; }

        public int CompareTo(Answer other)
        {
            return Order.CompareTo(other.Order);
        }
    }
}
