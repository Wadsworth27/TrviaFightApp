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
                    Console.WriteLine(question + "\n");
                    List<string> possibleAnswers = question.GeneratePossibleAnswers();
                    int answerLocation = 1;
                    foreach (string answer in possibleAnswers)
                    {
                        Console.WriteLine($"{answerLocation}: {answer}\n".Replace("&quot;", "\"").Replace("&#039;", "'").Replace("&amp;", "&"));
                        answerLocation += 1;
                    }

                    if (question.CheckAnswer(possibleAnswers, player.AnswerQuestion()))
                    {
                        int damage = player.DoDamage();
                        enemy.HitPoints -= damage;
                        Console.WriteLine($"You did {damage} points of damage!");
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
                        Console.WriteLine($"Not Quite, correct answer was {question.correctAnswer}\nYou are {QuestionsCorrect}/{QuestionsAsked}\n");
                    }
                    int attack = enemy.Attack();
                    if (attack == 0)
                    {
                        Console.WriteLine("Enemy Missed!");
                    }
                    else
                    {
                        Console.WriteLine($"Enemy hit for {attack}");
                        player.Hitpoints -= attack;
                        if (player.Hitpoints <= 0)
                        {
                            Console.WriteLine("You were defeated!");
                            gameon = false;
                            break;
                        }
                    }
                    Console.WriteLine($"Player Hitpoints : {player.Hitpoints}\nEnemy Hitpoints: {enemy.HitPoints}\n\nHit any key to continue");
                    string? _ = Console.ReadLine();
                    Console.Clear();
                }
            }
            Console.WriteLine("Thanks for Playing!");
        }
    }
}

