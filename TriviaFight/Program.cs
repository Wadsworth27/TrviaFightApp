using APiHandler;
namespace TriviaFight;
class Program
{
    static void Main(string[] args)
    {
        APIClient.initializeClient();
        QuestionResultsModel QuestionModels = APIClient.GetQuestionsAsync("https://opentdb.com/api.php?amount=10&type=multiple").GetAwaiter().GetResult();
        QuestionSet questionSet = new QuestionSet(QuestionModels.Results);
        Player steve = new();
        QuizBrain quizBrain = new QuizBrain();
        quizBrain.PlayGame(questionSet,steve);

     }


}



