﻿namespace TriviaFight;
class Program
{
    static void Main(string[] args)
    {
        Player player;

        MainMenu.DisplayHomesceen();
        string NeworLoad = MainMenu.NewOrLoadGame();
        Console.WriteLine("&#039;");

        if (NeworLoad == "new")
        {
            player = MainMenu.StartNewGame();
        }
        else
        {
            player = MainMenu.StartNewGame();
            //some load code here Eventually
        }
        bool gameon = true;
        while (gameon)
        {
            player.DisplayInfo();
            MainMenu.GameHandler(MainMenu.Menu(), player);
        }
    }

}




