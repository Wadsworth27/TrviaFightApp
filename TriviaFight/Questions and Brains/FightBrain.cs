namespace TriviaFight
{
    public class FightBrain : QuizBrain
    {
        public virtual void PlayGame(Player player, Enemy enemy)
        {
            Random random = new();
            bool gameon = true;
            while (gameon)
            {
                QuestionSet questionSet = this.GetQuestions();
                foreach (Question question in questionSet.Questions)
                {
                    while (player.Stamina < 100)
                    {
                        while (enemy.Stamina >= 100 & player.Hitpoints > 0)
                        {
                            enemy.Stamina -= 100;
                            enemy.TakeTurn(player);
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
                        Console.WriteLine($"Player and Enemy are charging stamina based on speed:\n\nPlayer Stamina: {player.Stamina}\nEnemy Stamina: {enemy.Stamina}\n\n 100 stamina require per attack.");
                        Thread.Sleep(2500);
                        Console.Clear();
                    }
                    if (gameon == false)
                    {
                        break;
                    }


                    player.Stamina -= 100;
                    string mode = SetMode(player, enemy);
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
                        if (enemy.Hitpoints <= 0)
                        {
                            Console.WriteLine("You have defeated the enemy!");
                            gameon = false;
                            enemy.DefeatDrops(player);
                            break;
                        }
                    }
                    player.TemporaryStatModifiers.DecrementTurnsRemaining();
                    enemy.TemporaryStatModifiers.DecrementTurnsRemaining();
                    Console.WriteLine($"Player Hitpoints : {player.Hitpoints}\nEnemy Hitpoints: {enemy.Hitpoints}\n\nHit any key to continue");
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
        public string SetMode(Player player, Enemy enemy)
        {
            while (true)
            {
                bool specialAvalible = false;
                if (player.Weapon.SpecialMeter == 100)
                {
                    specialAvalible = true;

                }
                Console.WriteLine($"Please set strategy for this round:\n1. Attack - Attempt to damage enemy.\n2. Defense - Block Enemy atatck and charge special meter. " +
                    $"Currently {player.Weapon.SpecialMeter}/100");
                if (specialAvalible)
                {
                    Console.WriteLine($"3. Special Attack - {player.Weapon.SpecialAttackDescription}\n\n");
                }
                Console.WriteLine("5. Use Item");
                Console.WriteLine("9. Quit");
                Console.Write("Please enter seletion: ");
                string? response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        Console.Clear();
                        return "Attack";
                    case "2":
                        Console.Clear();
                        return "Defense";
                    case "3":
                        if (specialAvalible)
                        {
                            Console.Clear();
                            return "Special";
                        }
                        break;
                    case "5":
                        player.ConsumableInventory.UseConsumable(player, enemy);
                        return SetMode(player, enemy);


                    case "9":
                        Console.Clear();
                        return "Quit";
                    default:
                        break;
                }
                Console.Clear();
                Console.WriteLine("Invalid Input");
            }

        }

    }
}


