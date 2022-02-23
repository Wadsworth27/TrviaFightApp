using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaFight.Consumables;

namespace TriviaFight.Shop
{
    public class ShopInventory:ConsumableInventory
    {
        public void PurchaseConsumable(Player player)
        {
            bool exit = false;
            while(!exit){
                if (AllConsumables.Any())
                {
                    Shop.ShopInventory.DisplayConsumables();
                    Console.WriteLine($"{AllConsumables.Count + 1}: Exit\n");
                    int choice = 0;
                    while (choice <= 0 | choice > AllConsumables.Count + 1)
                    {
                        int.TryParse(Console.ReadLine(), out choice);
                    }
                    if (choice <= AllConsumables.Count)
                    {
                        AllConsumables[choice - 1].Quantity = 1;
                        player.ConsumableInventory.AddConsumable(AllConsumables[choice - 1]);
                        Console.Clear();
                        Shop.CreateShopInventory();
                    }
                    else
                    {
                        exit = true;
                    }
                }
            }
        }
    }
}
