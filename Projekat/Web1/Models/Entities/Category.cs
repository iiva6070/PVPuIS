namespace Web1.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Quiz> Quizzes { get; set; }
    }
}
