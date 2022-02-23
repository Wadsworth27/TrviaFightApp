using APiHandler;

namespace TriviaFight
{
    public class QuestionSet
    {
        public List<Question> Questions { get; set; } = new List<Question>();
        public QuestionSet(List<QuestionModel> questionModels)
        {
            for (int i = 0; i < questionModels.Count; i++)
            {
                Question newQuestion = new Question(questionModels[i]);
                this.Questions.Add(newQuestion);
            }
        }
    }
}
