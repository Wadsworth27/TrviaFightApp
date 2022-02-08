namespace APiHandler
{
    public class QuestionModel
    {
        public string Category { get; set; } = string.Empty;
        public string Difficulty { get; set; } = string.Empty;
        public string Question { get; set; } = string.Empty;
        public string Correct_Answer { get; set; } = string.Empty;
        public List<string>? Incorrect_Answers { get; set; }
    }

}
