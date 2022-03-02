using TriviaFight.Consumables;

namespace TriviaFight.Shop
{
    public static class Shop
    {
        public static ShopInventory ShopInventory { get; set; } = new();
        public static void LoadShop(Player player)
        {
            Console.WriteLine("Welcome to the shop. How can I help?\n" +
                "1. Purchase Consumables\n" +
                "2. Sell Weapons\n" +
                "3. Exit\n\n");
            string input = Console.ReadLine();
            if (input == "1")
            {
                CreateShopInventory();
                ShopInventory.PurchaseConsumable(player);
                Console.Clear();
                LoadShop(player);
            }
            else if (input == "2")
            {
                ShopInventory.SellWeapons(player);
                Console.Clear();
                LoadShop(player);

            }
            else if (input == "3")
            {
                Console.Clear();
                MainMenu.GameHandler(MainMenu.Menu(player), player);
            } else
            {
                Console.Clear();
                Console.WriteLine("Invlid Input.");
                LoadShop(player);
            }


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
