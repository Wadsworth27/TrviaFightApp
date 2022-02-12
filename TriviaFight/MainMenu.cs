using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight
{
    public static class MainMenu
    {
        public static void DisplayHomesceen()
        {
            Console.WriteLine(@"

▄▄▄█████▓ ██▀███   ██▓ ██▒   █▓ ██▓ ▄▄▄           █████▒ ██▓  ▄████  ██░ ██ ▄▄▄█████▓
▓  ██▒ ▓▒▓██ ▒ ██▒▓██▒▓██░   █▒▓██▒▒████▄       ▓██   ▒ ▓██▒ ██▒ ▀█▒▓██░ ██▒▓  ██▒ ▓▒
▒ ▓██░ ▒░▓██ ░▄█ ▒▒██▒ ▓██  █▒░▒██▒▒██  ▀█▄     ▒████ ░ ▒██▒▒██░▄▄▄░▒██▀▀██░▒ ▓██░ ▒░
░ ▓██▓ ░ ▒██▀▀█▄  ░██░  ▒██ █░░░██░░██▄▄▄▄██    ░▓█▒  ░ ░██░░▓█  ██▓░▓█ ░██ ░ ▓██▓ ░ 
  ▒██▒ ░ ░██▓ ▒██▒░██░   ▒▀█░  ░██░ ▓█   ▓██▒   ░▒█░    ░██░░▒▓███▀▒░▓█▒░██▓  ▒██▒ ░ 
  ▒ ░░   ░ ▒▓ ░▒▓░░▓     ░ ▐░  ░▓   ▒▒   ▓▒█░    ▒ ░    ░▓   ░▒   ▒  ▒ ░░▒░▒  ▒ ░░   
    ░      ░▒ ░ ▒░ ▒ ░   ░ ░░   ▒ ░  ▒   ▒▒ ░    ░       ▒ ░  ░   ░  ▒ ░▒░ ░    ░    
  ░        ░░   ░  ▒ ░     ░░   ▒ ░  ░   ▒       ░ ░     ▒ ░░ ░   ░  ░  ░░ ░  ░      
            ░      ░        ░   ░        ░  ░            ░        ░  ░  ░  ░         
                           ░                                                         
");
        }
        public static string NewOrLoadGame()
        {
            while (true)
            {
                Console.WriteLine("1. New Game\n\n");
                Console.WriteLine("2. Load Game\n");
                string newOrLoad = Console.ReadLine();
                if (newOrLoad =="1")
                {
                    Console.Clear();
                    return "new";
                } 
                
                if (newOrLoad =="2")
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
            while (name.Length<1 | name.Length>15 | name==null)
            {
                name = Console.ReadLine();
            }
            Player player = new Player(name);
            return player;

        }
        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine("Choose your game mode:\n\n" +
                "1. Challenge a category master. Defeat all masters to become the ultimate champion!\n"+
                "2. Trivia Challenge - 10 question general knowledge trivia. Earn weapons and items!\n" +
                "3. Random Battle - Battle a random opponent from history to gain experience and gold!\n" +
                "4. Shop - Find new items and power ups\n\n");
            while (true)
            {
                string? choice = Console.ReadLine();
                int result;
                Int32.TryParse(choice, out result);
                if (result > 0 & result <5)
                {
                    return result;
                }

            }
            
        }
        public static void GameHandler(int choice, Player player)
        {
            switch(choice)
            {
                case 1:
                    //some code for masters
                    break;
                case 2:
                    QuizBrain qb = new();
                    qb.PlayGame(player);
                    break;
                case 3:
                    FightBrain fb = new();
                    Enemy enemy = new Enemy(25,10);
                    player.Heal();
                    player.ChooseWeapon();
                    player.Weapon.Reset();
                    fb.PlayGame(player,enemy);
                    break;
                case 4:
                    //Some Shop Code
                    break;
                default:
                    Console.WriteLine("Oh man something went wrong");
                    break;
            }
        }
    }
}
