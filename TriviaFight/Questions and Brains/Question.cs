using APiHandler;
using System.Web;

namespace TriviaFight
{
    public class Question
    {
        public Random random = new Random();
        public string category;
        public string difficulty;
        public string questionText;
        public string correctAnswer;
        public List<string>? incorrectAnswers;
        public List<string> possibleAnswers;
        public int guessesRemaining;
        public Question(QuestionModel q)
        {
            category = @q.Category;
            difficulty = HttpUtility.HtmlDecode(q.Difficulty);
            questionText = HttpUtility.HtmlDecode(q.Question);
            correctAnswer = HttpUtility.HtmlDecode(q.Correct_Answer);
            incorrectAnswers = q.Incorrect_Answers;
            incorrectAnswers.ForEach((string x) => HttpUtility.HtmlDecode(x));
            possibleAnswers = new();
            guessesRemaining = 1;


        }
        public void AskQuestion()
        {
            possibleAnswers = GeneratePossibleAnswers();
            Console.WriteLine(questionText + "\n");
            int answerLocation = 1;
            foreach (string answer in possibleAnswers)
            {
                Console.WriteLine($"{answerLocation}: {answer}\n".Replace("&quot;", "\"").Replace("&#039;", "'").Replace("&amp;", "&"));
                answerLocation += 1;
            }
            Console.WriteLine($"{answerLocation}: Use Item");
        }
        public List<string> GeneratePossibleAnswers()
        {
            List<string> possibleAnswers = new List<string>(incorrectAnswers);
            int index = random.Next(0, this.incorrectAnswers.Count + 1);
            possibleAnswers.Insert(index, this.correctAnswer);
            return possibleAnswers;
        }
        private bool CorrectAnswer(string answer)
        {
            return answer == correctAnswer;
        }
        public bool CheckAnswer(List<string> answers, int answer)
        {
            int v = answers.FindIndex(CorrectAnswer);
            return v == answer - 1;
        }
        public int ProvideAnswer(Player player, Enemy enemy, Question question)
        {
            {
                Console.WriteLine("What is you answer?: ");
                string answer = Console.ReadLine();
                int result = 0;
                int.TryParse(answer, out result);
                if (result > 0 & result <= possibleAnswers.Count)
                {
                    return int.Parse(answer);
                }
                else if (result == possibleAnswers.Count + 1)
                {
                    player.ConsumableInventory.UseConsumable(question);
                    Console.Clear();
                    AskQuestion();
                    return ProvideAnswer(player, enemy, question);

                }
                else
                {
                    Console.WriteLine("Invalid Input, please try again");
                    return ProvideAnswer(player, enemy, question);
                }
            }
        }
        public bool AnswerQuestion(Player player, Enemy enemy, Question question)
        {
            possibleAnswers = GeneratePossibleAnswers();
            AskQuestion();
            while (guessesRemaining > 0)
            {
                int answer = ProvideAnswer(player, enemy, question);
                if (CheckAnswer(possibleAnswers, answer))
                {
                    guessesRemaining = 1;
                    Console.WriteLine($"You got it!");
                    return true;
                }
                else
                {
                    guessesRemaining--;
                    if (guessesRemaining == 0)
                    {
                        Console.WriteLine($"Not Quite, correct answer was {correctAnswer}\n");
                    }
                    else
                    {
                        Console.WriteLine($"Not Quite, try again");
                    }

                }

            }
            guessesRemaining = 1;
            return false;
        }
        public override string ToString()
        {
            return questionText;
        }
    }
}
