namespace TriviaFight
{
    public class TemporaryStatModifiers
    {
        public int TemporarySpeed { get; set; }
        public int TemporaryHitPercentage { get; set; }
        private List<StatModifier> statModifiers = new List<StatModifier>();
        public void AddModifier(StatModifier statmod)
        {
            statModifiers.Add(statmod);
            CalculateStats();
            Console.WriteLine(statModifiers.Count);
        }
        public void RemoveInactiveModifiers()
        {
            var activeModifiers = new List<StatModifier>();
            foreach (StatModifier modifier in statModifiers)
            {
                if (modifier.TurnsRemaining >= 0)
                {
                    activeModifiers.Add(modifier);
                }
            }
            this.statModifiers = activeModifiers;
        }
        public void CalculateStats()
        {
            RemoveInactiveModifiers();
            TemporarySpeed = 0;
            TemporaryHitPercentage = 0;
            int _tempSpeed = 0;
            int _tempHitPercentage = 0;
            foreach (StatModifier modifier in statModifiers)
            {
                switch (modifier.Stat)
                {
                    case "Speed":
                        _tempSpeed += modifier.Modifier;
                        break;
                    case "HitPercentage":
                        _tempHitPercentage += modifier.Modifier;
                        break;
                    default:
                        break;
                }
            }
            this.TemporarySpeed += _tempSpeed;
            this.TemporaryHitPercentage += _tempHitPercentage;
        }
        public void DecrementTurnsRemaining()
        {
            foreach (StatModifier modifier in statModifiers)
            {
                modifier.TurnsRemaining--;
                CalculateStats();

            }
        }

    }
}