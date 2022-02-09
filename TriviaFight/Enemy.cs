using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight
{
    public class Enemy
    {
        Random random = new();
        public string Name { get; set; } = "Enemy";
        public int HitPoints { get; set; }
        public int DamagePotential { get; set; }
        public int HitPercentage { get; set; } = 25;

        public Enemy(int hitpoints,int damage)
        {
            this.HitPoints = hitpoints;
            this.DamagePotential = damage;
        }

        public virtual int DoDamage()
        {
            return random.Next(this.DamagePotential+1);
        }
        public int Attack()
        {
            
            if (random.Next(100)<this.HitPercentage)
            {
                return DoDamage();

            } else
            {
                return 0;
            }
        }
    }
}
