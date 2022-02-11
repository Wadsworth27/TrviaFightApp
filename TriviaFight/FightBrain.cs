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
                        switch (mode)
                        {
                            case "Attack":
                                AttackSuccess(player,enemy);
                                break;
                            case "Defense":
                                DefenseSuccess(player);
                                break;
                            case "Special":
                                SpecialSuccess(player,enemy);
                                break;
                            default:
                                break;
                        }
                        if (enemy.HitPoints <= 0)
                        {
                            Console.WriteLine("You have defeated the enemy!");
                            gameon = false;
                            break;
                        }
                    }
                    else
                    {
                        this.QuestionsAsked += 1;
                        Console.WriteLine($"Not Quite, correct answer was {question.correctAnswer}");
                    }
                    EnemyTurn(player, enemy);

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
            Console.WriteLine("Thanks for Playing!");
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
        public static void AttackSuccess(Player player, Enemy enemy)
            {
                int damage = player.Weapon.DoDamage();
                enemy.HitPoints -= damage;
                Console.WriteLine($"You did {damage} points of damage with {player.Weapon}!");
            }
        public static void DefenseSuccess(Player player)
        {
            player.Blocking = true;
            player.Weapon.ChargeSpecial(player.Weapon.GetSpecialChargeRate());
        }
        public static void SpecialSuccess(Player player, Enemy enemy)
        {
            int damage= player.Weapon.SpecialAttack(player);
            enemy.HitPoints-= damage;
            Console.WriteLine($"You did {damage} points of damage with {player.Weapon}!\n");
        }
        public static void EnemyTurn (Player player, Enemy enemy)
        {
            if (player.Blocking == true)
            {
                Console.WriteLine("Enemy Attack Blocked!!\n");
                player.Blocking = false;
            }
            else
            {
                int attack = enemy.Attack();
                if (attack == 0)
                {
                    Console.WriteLine("Enemy Missed!");
                }
                else
                {
                    Console.WriteLine($"Enemy hit for {attack}");
                    player.Hitpoints -= attack;
                }
            }

        }
        
            
        }
    }

