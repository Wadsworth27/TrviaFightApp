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
                    List<string> possibleAnswers = new List<string>();
                    AskQuestion(question, out possibleAnswers);
                    
                    if (question.CheckAnswer(possibleAnswers, player.AnswerQuestion()))
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
                    else
                    {
                        Console.WriteLine($"Not Quite, correct answer was {question.correctAnswer}\n");
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
        public static void AskQuestion(Question question, out List<string> possibleAnswers)
        {
            Console.WriteLine(question + "\n");
            possibleAnswers = question.GeneratePossibleAnswers();
            int answerLocation = 1;
            foreach (string answer in possibleAnswers)
            {
                Console.WriteLine($"{answerLocation}: {answer}\n".Replace("&quot;", "\"").Replace("&#039;", "'").Replace("&amp;", "&"));
                answerLocation += 1;
            }
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


