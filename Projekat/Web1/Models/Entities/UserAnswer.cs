namespace Web1.Models.Entities
{
    public class UserAnswer
    {
        public int Id { get; set; }

        public int ResultId { get; set; }
        public Result Result { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public string AnswerText { get; set; } // za text pitanja
        public int? SelectedAnswerId { get; set; } // za MC pitanja
    }
}
