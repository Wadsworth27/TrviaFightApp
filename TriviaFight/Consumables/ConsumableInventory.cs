namespace TriviaFight.Consumables
{
    public class ConsumableInventory
    {
        public List<Consumable> AllConsumables { get; set; } = new();
        public void AddConsumable(Consumable consumable)
        {
            RemoveEmptyConsumables();
            bool existing = false;
            foreach (Consumable c in AllConsumables)
            {
                if (c.ToString() == consumable.ToString())
                {
                    c.Quantity = consumable.Quantity + c.Quantity;
                    existing = true;
                }
            }
            if (!existing)
            {
                AllConsumables.Add(consumable);

            }
        }
        public virtual void DisplayConsumables()
        {
            RemoveEmptyConsumables();
            if (AllConsumables.Count == 0)
            {
                Console.WriteLine("No items to display. Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                int counter = 1;
                foreach (Consumable c in AllConsumables)
                {
                    Console.WriteLine($"{counter}: {c} Quantity {c.Quantity}\n");
                    counter++;
                }
            }

        }
        public List<Consumable> GetListOfConsumablesByTargetType(string target)
        {
            RemoveEmptyConsumables();
            List<Consumable> targetList = new();
            foreach (var consumable in AllConsumables)
            {
                if (consumable.Target == target)
                {
                    targetList.Add(consumable);
                }
            }
            return targetList;
        }
        public List<Consumable> GetListOfConsumablesByTargetType(string target1, string target2)
        {
            RemoveEmptyConsumables();
            List<Consumable> targetList = new();
            foreach (var consumable in AllConsumables)
            {
                if (consumable.Target == target1 | consumable.Target == target2)
                {
                    targetList.Add(consumable);
                }
            }
            return targetList;
        }
        public virtual void DisplayConsumables(List<Consumable> consumables)
        {
            RemoveEmptyConsumables();
            if (consumables.Count == 0)
            {
                Console.WriteLine("No items to display. Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                int counter = 1;
                foreach (Consumable c in consumables)
                {
                    Console.WriteLine($"{counter}: {c} Quantity {c.Quantity}\n");
                    counter++;
                }
            }

        }
        public void RemoveEmptyConsumables()
        {
            if (AllConsumables.Any())
            {
                for (int i = AllConsumables.Count - 1; i >= 0; i--)
                {
                    if (AllConsumables[i].Quantity == 0)
                    {
                        AllConsumables.RemoveAt(i);
                    }

                }
            }

        }
        public void UseConsumable(Player player, Enemy enemy)
        {
            var playerConsumables = GetListOfConsumablesByTargetType("Player", "Enemy");
            DisplayConsumables(playerConsumables);
            if (playerConsumables.Any())
            {
                Console.WriteLine($"{playerConsumables.Count + 1}: Exit\n");
                int choice = 0;
                while (choice <= 0 | choice > playerConsumables.Count + 1)
                {
                    int.TryParse(Console.ReadLine(), out choice);
                }
                if (choice <= playerConsumables.Count)
                {
                    if (playerConsumables[choice - 1].Target == "Player")
                    {
                        playerConsumables[choice - 1].Use(player);
                    }
                    else
                    {
                        playerConsumables[choice - 1].Use(enemy);
                    }

                }
            }
        }
        public void UseConsumable(Enemy enemy)
        {
            var playerConsumables = GetListOfConsumablesByTargetType("Enemy");
            DisplayConsumables(playerConsumables);
            if (playerConsumables.Any())
            {
                Console.WriteLine($"{playerConsumables.Count + 1}: Exit\n");
                int choice = 0;
                while (choice <= 0 | choice > playerConsumables.Count + 1)
                {
                    int.TryParse(Console.ReadLine(), out choice);
                }
                if (choice <= playerConsumables.Count)
                {
                    playerConsumables[choice - 1].Use(enemy);
                }
                else
                {
                    Console.Clear();
                }
            }
        }
        public void UseConsumable(Question question)
        {
            var playerConsumables = GetListOfConsumablesByTargetType("Question");
            DisplayConsumables(playerConsumables);
            if (playerConsumables.Any())
            {
                Console.WriteLine($"{playerConsumables.Count + 1}: Exit\n");
                int choice = 0;
                while (choice <= 0 | choice > playerConsumables.Count + 1)
                {
                    int.TryParse(Console.ReadLine(), out choice);
                }
                if (choice <= playerConsumables.Count)
                {
                    playerConsumables[choice - 1].Use(question);
                }
            }
        }
    }
}
