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
        public virtual QuestionSet GetQuestions()
        {
            APIClient.initializeClient();
            QuestionResultsModel QuestionModels = APIClient.GetQuestionsAsync("https://opentdb.com/api.php?amount=10&type=multiple").GetAwaiter().GetResult();
            QuestionSet questionSet = new QuestionSet(QuestionModels.Results);
            return questionSet;
        }
        public virtual void PlayGame(Player player)
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

                    this.QuestionsAsked += 1;
                    this.QuestionsCorrect += 1;
                    Console.WriteLine($"You got it!\nYou are {this.QuestionsCorrect}/{this.QuestionsAsked}\n");


                }
                else {
                    this.QuestionsAsked += 1;
                    Console.WriteLine($"Not Quite, correct answer was {question.correctAnswer}\nYou are {QuestionsCorrect}/{QuestionsAsked}\n"); 
                }

            }
        }
    }
}

