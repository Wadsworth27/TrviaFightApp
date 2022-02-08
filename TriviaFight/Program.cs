using APiHandler;
namespace TriviaFight;
class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
        {
            APIClient.initializeClient();
            QuestionResultsModel Questions = APIClient.GetQuestionsAsync("https://opentdb.com/api.php?amount=10&type=multiple").GetAwaiter().GetResult();
            Question q = new Question(Questions.Results[0]);
            Console.WriteLine(q);
            List<string> possibleAnswers = q.GeneratePossibleAnswers();
            possibleAnswers.ForEach(Console.WriteLine);

            Player steve = new();
            if (q.CheckAnswer(possibleAnswers, steve.AnswerQuestion()))
            {
                Console.WriteLine("You got it!");
            }
        }
    
    }


}
