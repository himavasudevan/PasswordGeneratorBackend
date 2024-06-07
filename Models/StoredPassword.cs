namespace PasswordGeneratorApi.Models
{
    public class StoredPassword
    {

        public int Id { get; init; }
        public string Password { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
