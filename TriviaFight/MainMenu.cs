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
    }
}
