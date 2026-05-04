namespace Web1.Models.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TimeLimit { get; set; } // u sekundama
        public string Difficulty { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Question> Questions { get; set; }
    }
}
