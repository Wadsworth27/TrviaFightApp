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
        public virtual QuestionSet GetQuestions(string url = "https://opentdb.com/api.php?amount=10&type=multiple")
        {
            APIClient.initializeClient();
            QuestionResultsModel QuestionModels = APIClient.GetQuestionsAsync(url).GetAwaiter().GetResult();
            QuestionSet questionSet = new QuestionSet(QuestionModels.Results);
            return questionSet;
        }
        public virtual void PlayGame(Player player)
        {
            QuestionSet questionSet = this.GetQuestions();
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
        }
    }
}

