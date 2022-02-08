using APiHandler;
namespace TriviaFight;
class Program
{
    static void Main(string[] args)
    {
        APIClient.initializeClient();
        QuestionResultsModel qrm =APIClient.GetQuestionsAsync("https://opentdb.com/api.php?amount=10&type=multiple").GetAwaiter().GetResult();
        qrm.Results[0].Incorrect_Answers.ForEach(Console.WriteLine);
        Console.WriteLine("break");
        List<string> answers = qrm.Results[0].GeneratePossibleAnswers();
        answers.ForEach(Console.WriteLine);
        Console.WriteLine("break");
        qrm.Results[0].Incorrect_Answers.ForEach(Console.WriteLine);
        /*
        Player steve = new();
        Question question = new Question() { Text = "What is your favorite color" };
        /*   Just some Tester code
        Answer answer1 = new Answer() { Order = 3, Text = "Red" };
        Answer answer2 = new Answer() { Order = 1, Text = "Orange" };
        Answer answer3 = new Answer() { Order = 2, Text = "Blue" };

        List<Answer> answerList = new List<Answer>() { answer1, answer2, answer3 };
        answerList.Sort();
        answerList.ForEach(answer => Console.WriteLine(answer.Text));
        Console.WriteLine(steve.AnswerQuestion());
        MultipleChoiceQuestion q = new MultipleChoiceQuestion() { Text = "Hi there" };
        Console.WriteLine(q.Text);
        */
    }


}
