using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight.Equipment.Weapons
{
    public static class CommonWeaponFactory
    {
        public static List<string> CommonWeaponNames = new()
        {
            "The hardback edition of War & Peace",
            "Coat Hanger",
            "Toaster",
            "Frying Pan",
            "Safety Scissors",
            "Fishing rod"
        };
        public static Weapon ProduceWeapon()
        {
            CommonWeapon weapon = new();
            weapon.SpeedModifier = Random.Shared.Next(-25, 25);
            weapon.DamagePotential = Random.Shared.Next(3, 8);
            weapon.Name = CommonWeaponNames[Random.Shared.Next(CommonWeaponNames.Count)];
            return weapon;
        }
    }
}
