using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight
{
    public class FightBrain : QuizBrain
    {
        public virtual void PlayGame(Player player, Enemy enemy)
        {
            bool gameon = true;
            while (gameon)
            {
                QuestionSet questionSet = this.GetQuestions();
                foreach (Question question in questionSet.Questions)
                {
                    string mode = player.SetMode();
                    if (mode == "Special")
                    {
                        player.Weapon.UseSpecial();
                    }
                    Console.WriteLine($"Mode: {mode}\n\n");

                    if (question.AnswerQuestion())
                    {
                        AnswerSuccess(mode, player, enemy);
                        if (enemy.HitPoints <= 0)
                        {
                            Console.WriteLine("You have defeated the enemy!");
                            gameon = false;
                            enemy.DropLoot(player);
                            break;
                        }
                    }
                    enemy.Attack(player);

                    if (player.Hitpoints <= 0)
                    {
                        Console.WriteLine("You were defeated!");
                        gameon = false;
                        break;
                    }
                    Console.WriteLine($"Player Hitpoints : {player.Hitpoints}\nEnemy Hitpoints: {enemy.HitPoints}\n\nHit any key to continue");
                    string? _ = Console.ReadLine();
                    Console.Clear();
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void AnswerSuccess(string mode,Player player,Enemy enemy)
        {
            switch (mode)
            {
                case "Attack":
                    player.Weapon.Attack(enemy);
                    break;
                case "Defense":
                    player.Weapon.Defend(player);
                    break;
                case "Special":
                    player.Weapon.SpecialAttack(player, enemy);
                    break;
                default:
                    break;
            }
        }
    }
}


