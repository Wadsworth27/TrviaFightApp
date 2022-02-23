using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaFight.Consumables;

namespace TriviaFight.Shop
{
    public static class Shop
    {
        public static ShopInventory ShopInventory { get; set; } = new();
        public static void LoadShop(Player player)
        {
            Console.WriteLine("Welcome to the shop");
            CreateShopInventory();
            ShopInventory.PurchaseConsumable(player);
            Console.Clear();
            MainMenu.GameHandler(MainMenu.Menu(), player);

        }
        public static void CreateShopInventory()
        {
            ShopInventory.AllConsumables.Clear();
            ShopInventory.AddConsumable(new BananaPeel(999));
            ShopInventory.AddConsumable(new CupOfCoffee(999));
            ShopInventory.AddConsumable(new ClarityPotion(999));

        }

            

    }
}
