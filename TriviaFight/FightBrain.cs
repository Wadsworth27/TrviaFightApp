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
                    while (player.Stamina < 100)
                    {
                        while (enemy.Stamina >= 100 & player.Hitpoints>0)
                        {
                            enemy.Stamina-=100;
                            enemy.Attack(player);
                            Thread.Sleep(2000);
                        }
                        if (player.Hitpoints <= 0)
                        {
                            Console.WriteLine("You were defeated!");
                            gameon = false;
                            break;
                        }
                        player.Stamina += player.Speed;
                        enemy.Stamina += enemy.Speed;
                        Console.WriteLine($"Charging stamina based on speed:\n\nPlayer Stamina: {player.Stamina}\nEnemy Stamina: {enemy.Stamina}");
                        Thread.Sleep(1500);
                        Console.Clear();
                    }
                    if (gameon == false)
                    {
                        break;
                    }
                    
                    
                    player.Stamina -= 100;
                    string mode = player.SetMode();
                    //Check if player chose to exit in mode selection
                    if (mode == "Quit")
                    {
                        gameon = false;
                        break;
                    }
                    //Depletes special meter
                    if (mode == "Special")
                    {
                        player.Weapon.UseSpecial();
                    }
                    Console.WriteLine($"Mode: {mode}\n\n");

                    if (question.AnswerQuestion(player, enemy, question))
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
                    player.TemporaryStatModifiers.DecrementTurnsRemaining();
                    
                    Console.WriteLine($"Player Hitpoints : {player.Hitpoints}\nEnemy Hitpoints: {enemy.HitPoints}\n\nHit any key to continue");
                    string? _ = Console.ReadLine();
                    Console.Clear();
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void AnswerSuccess(string mode, Player player, Enemy enemy)
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


