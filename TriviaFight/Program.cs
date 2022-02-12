using APiHandler;
using TriviaFight.Equipment;
using TriviaFight.Equipment.Weapons;

namespace TriviaFight;
class Program
{
    static void Main(string[] args)
    {
        MainMenu.DisplayHomesceen();
        Player player;
        string NeworLoad = MainMenu.NewOrLoadGame();
        
        if (NeworLoad =="new")
        {
            player = MainMenu.StartNewGame();
        }
        else
        {
            player = MainMenu.StartNewGame();
            //some load code here
        }
        player.ChooseWeapon();
        /*Player steve = new();
        Nunchaku nun = new();
        RustySpoon rusty = new();
        steve.AddWeapon(nun);
        steve.AddWeapon(rusty);
        steve.ChooseWeapon();
        Enemy enemy = new(25,5);
        FightBrain fightBrain = new();
        fightBrain.PlayGame(steve, enemy);
        */
     }


}



