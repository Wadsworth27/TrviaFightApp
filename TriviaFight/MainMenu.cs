using TriviaFight.Equipment;
using TriviaFight.Equipment.Weapons;
using TriviaFight.Masters;

namespace TriviaFight
{
    public static class MainMenu
    {
        public static Enemy? CurrentBoss { get; set; }
        public static void DisplayHomesceen()
        {
            Console.WriteLine(@"
████████╗██████╗ ██╗██╗   ██╗██╗ █████╗     ███████╗██╗ ██████╗ ██╗  ██╗████████╗
╚══██╔══╝██╔══██╗██║██║   ██║██║██╔══██╗    ██╔════╝██║██╔════╝ ██║  ██║╚══██╔══╝
   ██║   ██████╔╝██║██║   ██║██║███████║    █████╗  ██║██║  ███╗███████║   ██║   
   ██║   ██╔══██╗██║╚██╗ ██╔╝██║██╔══██║    ██╔══╝  ██║██║   ██║██╔══██║   ██║   
   ██║   ██║  ██║██║ ╚████╔╝ ██║██║  ██║    ██║     ██║╚██████╔╝██║  ██║   ██║   
   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═══╝  ╚═╝╚═╝  ╚═╝    ╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝   
                                                                                 ");
        }
        public static string NewOrLoadGame()
        {
            while (true)
            {
                Console.WriteLine("1. New Game\n\n");
                Console.WriteLine("2. Load Game -- Coming soon!\n");
                string? newOrLoad = Console.ReadLine();
                if (newOrLoad == "1")
                {
                    Console.Clear();
                    return "new";
                }

                if (newOrLoad == "2")
                {
                    Console.Clear();
                    return "load";
                }
            }
        }
        public static Player StartNewGame()
        {
            Console.WriteLine("Please enter your player name:");
            string name = string.Empty;
            while (name.Length < 1 | name.Length > 15 | name == null)
            {
                name = Console.ReadLine();
            }
            Player player = new Player(name);
            Console.Clear();
            return player;

        }
        public static int Menu(Player player)
        {
            CurrentBoss = GetCurrentBoss(player);
            if (CurrentBoss != null)
            {
                Console.WriteLine("Choose your game mode:\n\n" +
                $"1. Challenge a category master. Defeat all masters to become the ultimate champion!\n   Next Master: {CurrentBoss.Name}    Recomended level: {CurrentBoss.SuggestedLevel}\n\n" +
                "2. Trivia Challenge - 10 question general knowledge trivia. Earn gold!\n" +
                "3. Random Battle - Battle a random opponent from history to gain experience and find items!\n" +
                "4. Shop - Find new items and power ups\n" +
                "5. Change Weapons\n\n");
            }
            else
            {
                CurrentBoss = GetRandomBoss();
                Console.WriteLine("Choose your game mode:\n\n" +
                $"1. You are already the ultimate chamnpion! This champion wants to play again though\n   Next Master: {CurrentBoss.Name}    Recomended level: {CurrentBoss.SuggestedLevel}\n\n" +
                "2. Trivia Challenge - 10 question general knowledge trivia. Earn gold!\n" +
                "3. Random Battle - Battle a random opponent from history to gain experience and find items!\n" +
                "4. Shop - Find new items and power ups\n" +
                "5. Change Weapons\n\n");
            }

            
            while (true)
            {
                string? choice = Console.ReadLine();
                int result;
                Int32.TryParse(choice, out result);
                if (result > 0 & result < 6)
                {
                    return result;
                }

            }

        }
        public static void GameHandler(int choice, Player player)
        {
            Console.Clear();
            switch (choice)
            {
                case 1:
                    FightBrain fb1 = new();
                    BruceLee enemy1 = new BruceLee();
                    player.Reset();
                    player.Weapon.Reset();
                    fb1.PlayGame(player, enemy1);
                    break;
                case 2:
                    QuizBrain qb = new();
                    qb.PlayGame(player);
                    break;
                case 3:
                    FightBrain fb = new();
                    Enemy enemy = EnemyFactory();
                    player.Reset();
                    player.Weapon.Reset();
                    Console.WriteLine($"A new challenger,{enemy.Name}, aproaches...\n");
                    fb.PlayGame(player, enemy);
                    break;
                case 4:

                    Shop.Shop.LoadShop(player);
                    break;
                case 5:
                    player.ChooseWeapon();
                    break;
                default:
                    Console.WriteLine("Oh man something went wrong");
                    break;
            }
        }
        public static Enemy EnemyFactory()
        {
            List<Weapon> EnemyWeapons = new()
            {
                new CommonWeapon(),
                new Nunchaku()

            };
            List<string> Names = new()
            {
                "Cleopatra",
                "Queen Victoria",
                "Alexander the Great",
                "Julius Caesar",
                "Napoleon Bonaparte",
                "Genghis Khan",
                "Catherine the Great",
                "Mary Queen of Scots",
                "Augustus",
                "Ashoka",
                "Charlemagne",
                "Anne Boleyn"
            };
            Enemy enemy = new();
            Random random = new();
            Console.WriteLine("What kind of enemy would you like to face?\n\n1. Easy\n2. Medium\n3. Hard\n\n");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":

                    enemy.Name = Names[random.Next(Names.Count)];
                    enemy.MaxHitpoints = 25;
                    enemy.Hitpoints = 25;
                    enemy.Speed = 50;
                    enemy.Weapon = EnemyWeapons[random.Next(EnemyWeapons.Count)];
                    Console.Clear();
                    return enemy;
                    break;

                case "2":

                    enemy.Name = Names[random.Next(Names.Count)];
                    enemy.MaxHitpoints = 50;
                    enemy.Hitpoints = 50;
                    enemy.Speed = 75;
                    enemy.Weapon = EnemyWeapons[random.Next(EnemyWeapons.Count)];
                    Console.Clear();
                    return enemy;
                    break;

                case "3":

                    enemy.Name = Names[random.Next(Names.Count)];
                    enemy.MaxHitpoints = 100;
                    enemy.Hitpoints = 100;
                    enemy.Speed = 90;
                    enemy.Weapon = EnemyWeapons[random.Next(EnemyWeapons.Count)];
                    Console.Clear();
                    return enemy;
                    break;
                default:
                    Console.Clear();
                    return EnemyFactory();

            }
            return enemy;
        }
        public static Enemy? GetCurrentBoss(Player player)
        {
            List<Enemy> AllBosses = new()
            {
                new BruceLee(),
                new BrettFavre(),
                new AlbertEinstein()
            };
            foreach (Enemy boss in AllBosses)
            {
                bool enemyDefeated = false;
                foreach (string name in player.BossesDefeated)
                {
                    if (boss.Name == name)
                    {
                        enemyDefeated = true;
                    }
                }
                if (!enemyDefeated)
                {
                    return boss;
                }
            }
            return null;
        }
        public static Enemy GetRandomBoss()
        {
            List<Enemy> AllBosses = new()
            {
                new BruceLee(),
                new BrettFavre()
            };
            return AllBosses[Random.Shared.Next(AllBosses.Count)];
        }
    }
}
