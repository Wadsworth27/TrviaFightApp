using APiHandler;

namespace TriviaFight
{
    public class QuizBrain
    {
        public int QuestionsAsked { get; set; } = 0;
        public int QuestionsCorrect { get; set; } = 0;
        public List<Question> QuestionSet { get; set; }

        public QuizBrain()
        {
        }
        public virtual QuestionSet GetQuestions(out int difficulty, string url = "https://opentdb.com/api.php?amount=10&type=multiple")
        {

            APIClient.initializeClient();
            difficulty = SetDifficulty();
            switch (difficulty)
            {
                case 1:
                    Console.WriteLine("Now Playing in Easy mode\n");
                    QuestionResultsModel QuestionModelsEasy = APIClient.GetQuestionsAsync("https://opentdb.com/api.php?amount=10&difficulty=easy&type=multiple").GetAwaiter().GetResult();
                    QuestionSet questionSetEasy = new QuestionSet(QuestionModelsEasy.Results);
                    return questionSetEasy;
                case 2:
                    Console.WriteLine("Now Playing in Medium mode\n");
                    QuestionResultsModel QuestionModels = APIClient.GetQuestionsAsync("https://opentdb.com/api.php?amount=10&difficulty=medium&type=multiple").GetAwaiter().GetResult();
                    QuestionSet questionSet = new QuestionSet(QuestionModels.Results);
                    return questionSet;
                case 3:
                    Console.WriteLine("Now Playing in Hard mode\n");
                    QuestionResultsModel QuestionModelsHard = APIClient.GetQuestionsAsync("https://opentdb.com/api.php?amount=10&difficulty=hard&type=multiple").GetAwaiter().GetResult();
                    QuestionSet questionSetHard = new QuestionSet(QuestionModelsHard.Results);
                    return questionSetHard;
                default:
                    throw new Exception();
            }

        }
        public virtual void PlayGame(Player player)
        {
            int difficulty;
            QuestionSet questionSet = this.GetQuestions(out difficulty);
            foreach (Question question in questionSet.Questions)
            {
                if (question.AnswerQuestion(player, new Enemy(), question))
                {

                    this.QuestionsAsked += 1;
                    this.QuestionsCorrect += 1;
                    Console.WriteLine($"You are {this.QuestionsCorrect}/{this.QuestionsAsked}\n");
                    string? _ = Console.ReadLine();
                    Console.Clear();

                }
                else
                {
                    this.QuestionsAsked += 1;
                    Console.WriteLine($"You are {QuestionsCorrect}/{QuestionsAsked}\n");
                    string? _ = Console.ReadLine();
                    Console.Clear();
                }

            }
            if (QuestionsCorrect >= 4)
            {
                Console.WriteLine("Congratulations, you did well enough to recieve a gold reward.\n");
                int goldRecieved;
                switch (difficulty)
                {
                    case 1:
                        goldRecieved = 100 + (20 * (QuestionsCorrect - 4));
                        break;
                    case 2:
                        goldRecieved = 200 + (40 * (QuestionsCorrect - 4));
                        break;
                    case 3:
                        goldRecieved = 500 + (100 * (QuestionsCorrect - 4));
                        break;
                    default:
                        throw new Exception();
                }

                player.Gold += goldRecieved;
                Console.WriteLine($"You answered {QuestionsCorrect} questions right and recieved a reward of {goldRecieved}\n" +
                    $"Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Unfortunately, you didn't do well enough to get a reward.\nPress any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public virtual QuestionSet GetQuestions(string url = "https://opentdb.com/api.php?amount=10&type=multiple")
        {
            APIClient.initializeClient();
            QuestionResultsModel QuestionModels = APIClient.GetQuestionsAsync(url).GetAwaiter().GetResult();
            QuestionSet questionSet = new QuestionSet(QuestionModels.Results);
            return questionSet;
        }
        public virtual int SetDifficulty()
        {
            Console.WriteLine("What Level of dificulty would you like to play on?\n\n" +
                "1. Easy - 100 GP for the first 4 questions right, 20 GP for each additional\n" +
                "2. Medium - 200 GP for the first 4 questions right, 40 GP for each additional\n" +
                "3. Hard - 500 GP for the first 4 questions right, 100 GP for each additional\n");
            int selection;
            int.TryParse(Console.ReadLine(), out selection);
            if (selection < 4 & selection > 0)
            {
                Console.Clear();
                return selection;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please try again\n");
                return SetDifficulty();
            }
        }
    }
}

