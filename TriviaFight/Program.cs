using APiHandler;
using TriviaFight.Equipment;

namespace TriviaFight;
class Program
{
    static void Main(string[] args)
    {
        Player steve = new();
        IWeapon spoon = new RustySpoon();
        steve.EquipWeapon(spoon);
        Enemy enemy = new(25,5);
        QuizBrain quizBrain = new QuizBrain();
        FightBrain fightBrain = new();
        fightBrain.PlayGame(steve, enemy);

        //quizBrain.PlayGame(steve);

     }


}



