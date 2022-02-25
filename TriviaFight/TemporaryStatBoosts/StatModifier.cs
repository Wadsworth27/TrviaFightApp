namespace TriviaFight
{
    public class StatModifier
    {
        public string Stat { get; set; }
        public int TurnsRemaining { get; set; }
        public int Modifier;

        public StatModifier(string stat, int turns, int modifier)
        {
            Stat = stat;
            TurnsRemaining = turns;
            Modifier = modifier;

        }
    }
}
