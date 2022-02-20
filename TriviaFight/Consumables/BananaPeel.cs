﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight.Consumables
{
    public class BananaPeel : Consumable, IConsumable
    {
        public override string Name { get; set; } = "Banana Peel";

        public override string Description { get; } = "Banana peels make it hard for the enemy to get to you, speed = 0 for 1 turn ";

        public override string Target { get; set; } = "Enemy";
        public override int Quantity { get; set; } = 1;
        public override string ToString()
        {
            return Name;
        }
        public override void Use(Enemy enemy)
        {
            enemy.TemporaryStatModifiers.AddModifier(new StatModifier("Speed", 2, -1 * enemy.Speed));
        }

    }
}
