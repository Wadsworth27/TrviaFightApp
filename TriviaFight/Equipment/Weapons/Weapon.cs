using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaFight.Equipment;

namespace TriviaFight
{
    public abstract class Weapon
    {
        public string Name { get; set; } = "Weapon";
        public int DamagePotential;
        public int SpecialMeter;
        public int SpecialChargeRate;
        public virtual void Reset()
        {

        }

    }
}
