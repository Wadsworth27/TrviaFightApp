using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight
{
    public class TemporaryStatModifiers
    {
        public int TemporarySpeed { get; set; }
        private List<StatModifier> statModifiers = new List<StatModifier>();
        public void AddModifier(StatModifier statmod)
        {
            statModifiers.Add(statmod);
            Console.WriteLine(statModifiers.Count);
        }
        public void RemoveInactiveModifiers()
        {
            var activeModifiers = new List<StatModifier>();
            foreach (StatModifier modifier in statModifiers)
            {
                if (modifier.TurnsRemaining > 0)
                {
                    activeModifiers.Add(modifier);
                }
            }
            statModifiers = activeModifiers;
        }
        public void CalculateStats()
        {
            RemoveInactiveModifiers();
            TemporarySpeed = 0;
            int _tempSpeed = 0;
            foreach (StatModifier modifier in statModifiers)
            {
                switch (modifier.Stat)
                {
                    case "Speed":
                        _tempSpeed += modifier.Modifier;
                        break;
                    default:
                        break;
                }
            }
            TemporarySpeed += _tempSpeed;
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
