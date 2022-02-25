using TriviaFight.Consumables;

namespace TriviaFight.Shop
{
    public class ShopInventory : ConsumableInventory
    {
        public void PurchaseConsumable(Player player)
        {
            bool exit = false;
            while (!exit)
            {
                if (AllConsumables.Any())
                {
                    Console.WriteLine($"\nGold Avalible: {player.Gold}\n\n\n");
                    Shop.ShopInventory.DisplayConsumables();
                    Console.WriteLine($"{AllConsumables.Count + 1}: Exit\n");
                    int choice = 0;
                    while (choice <= 0 | choice > AllConsumables.Count + 1)
                    {
                        int.TryParse(Console.ReadLine(), out choice);
                    }
                    if (choice <= AllConsumables.Count)
                    {
                        var chosenConsumable = AllConsumables[choice - 1];
                        if (chosenConsumable.Price <= player.Gold)
                        {
                            chosenConsumable.Quantity = 1;
                            player.ConsumableInventory.AddConsumable(chosenConsumable);
                            player.Gold -= chosenConsumable.Price;
                            Console.WriteLine($"\n\nYou have purchased {chosenConsumable} for {chosenConsumable.Price} gold\n" +
                                $"Press any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                            Shop.CreateShopInventory();
                        }
                        else
                        {
                            Console.WriteLine("Sorry, you don't have enough gold for that.\n\n" +
                                "Press any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                        }

                    }
                    else
                    {
                        exit = true;
                    }
                }
            }
        }
        public override void DisplayConsumables()
        {
            RemoveEmptyConsumables();
            if (AllConsumables.Count == 0)
            {
                Console.WriteLine("We are sold out of everything... Supply chain issues.\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                int counter = 1;
                foreach (Consumable c in AllConsumables)
                {
                    Console.WriteLine($"{counter}: {c}\nPrice: {c.Price} gp\nDescription:{c.Description}\n");
                    counter++;
                }
            }

        }
    }
}
