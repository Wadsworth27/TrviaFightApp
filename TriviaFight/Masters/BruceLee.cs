using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaFight.Equipment.Weapons;

namespace TriviaFight.Masters
{
    public class BruceLee:Enemy
    {
        Random random = new();

        public override string Name { get; set; } = "Bruce Lee";
        public override int Hitpoints { get; set; } = 100;
        public override int MaxHitpoints { get; set; } = 100;
        public override int HitPercentage { get; set; } = 70;
        public override int Stamina { get; set; } = 0;
        public override int DefendPercentage { get; set; } = 35;
        public override Weapon Weapon { get; set; } = new Nunchaku();
        private int _speed = 75;
        public override int Speed
        {
            get
            {
                Console.WriteLine($"Temp Speed: {TemporaryStatModifiers.TemporarySpeed}, Speed:{_speed }");
                return _speed + TemporaryStatModifiers.TemporarySpeed;
            }
            set
            {
                _speed = value;
            }
        }
        public BruceLee()
        {

        }
    }
}
