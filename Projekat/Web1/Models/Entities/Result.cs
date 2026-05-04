namespace Web1.Models.Entities
{
    public class Result
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }

        public int Score { get; set; }
        public double Percentage { get; set; }

        public DateTime CompletedAt { get; set; }
        public int Duration { get; set; } // vreme rešavanja
    }
}
