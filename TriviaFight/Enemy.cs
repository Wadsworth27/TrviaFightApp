﻿using TriviaFight.Equipment;
using TriviaFight.Equipment.Weapons;

namespace TriviaFight
{
    public class Enemy : ITargetable
    {
        Random random = new();
        public virtual string Name { get; set; } = "Enemy";
        public virtual int Hitpoints { get; set; }
        public virtual int MaxHitpoints { get; set; }
        public virtual int DamagePotential { get; set; }
        public virtual int HitPercentage { get; set; } = 100;
        public virtual int DefendPercentage { get; set; } = 60;
        public virtual int Stamina { get; set; } = 0;
        public virtual Weapon Weapon { get; set; }
        private int _speed;
        public virtual int Speed
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

        public TemporaryStatModifiers TemporaryStatModifiers{ get; set; } = new();

        public Enemy(int hitpoints, int damage, int speed,Weapon weapon)
        {
            this.Hitpoints = hitpoints;
            this.MaxHitpoints = hitpoints;
            this.DamagePotential = damage;
            _speed = speed;
            Weapon = weapon;
        }
        public Enemy()
        {
            Hitpoints = 25;
            MaxHitpoints = 25;
            Speed = 50;
        }
        public virtual void TakeTurn(Player player)
        {
            if (player.Blocking == true)
            {
                Console.WriteLine("Enemy Attack Blocked!!\n");
                player.Blocking = false;
            }
            else
            {
                int randomint = random.Next(100);
                if (randomint <= this.DefendPercentage)
                {
                    Weapon.Defend(this);
                }
                else if ( randomint<= this.HitPercentage)
                {
                    if (Weapon.SpecialMeter == 100)
                    {
                        Weapon.UseSpecial();
                        Weapon.SpecialAttack(this, player);
                    } else
                    Weapon.Attack(player);
                }
                else
                {
                    Console.WriteLine("Enemy Missed!");
                    if (Weapon.SpecialMeter == 100)
                    {
                        Weapon.UseSpecial();
                    }
                }
            }
        }
        public virtual void DropLoot(Player player)
        {
            Nunchaku nc = new();
            Console.WriteLine("Weapon found!");
            bool existing = false;
            foreach (Weapon weapon in player.WeaponList)
            {
                if (weapon.Name == nc.Name)
                {
                    existing = true;
                }
            }
            if (existing)
            {
                Console.WriteLine($"You already have {nc}");
            }
            else
            {
                player.AddWeapon(nc);
            }
        }
    }
}
