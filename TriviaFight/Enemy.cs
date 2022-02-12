﻿using System;
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
        public virtual void Attack(Player player)
        {
            if (player.Blocking == true)
            {
                Console.WriteLine("Enemy Attack Blocked!!\n");
                player.Blocking = false;
            }
            else
            {
                if (random.Next(100) <= this.HitPercentage)
                {
                    int damage = random.Next(1,this.DamagePotential);
                    player.Hitpoints-=damage;
                    Console.WriteLine($"Enemy hit {player} for {damage} points of damage!");
                }
                else
                {
                    Console.WriteLine("Enemy Missed!");
                }
            }
        }
    }
}