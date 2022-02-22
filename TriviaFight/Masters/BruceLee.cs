using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight.Masters
{
    public class BruceLee:Enemy
    {
        Random random = new();

        public override string Name { get; set; } = "Bruce Lee";
        public override int Hitpoints { get; set; } = 100;
        public override int DamagePotential { get; set; } = 4;
        public virtual int HitPercentage { get; set; } = 50;
        public virtual int Stamina { get; set; } = 0;
        private int _speed = 75;
        public BruceLee()
        {

        }
    }
}
