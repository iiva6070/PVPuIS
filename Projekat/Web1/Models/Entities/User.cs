namespace Web1.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ImageUrl { get; set; }

        public List<Result> Results { get; set; }
    }
}
