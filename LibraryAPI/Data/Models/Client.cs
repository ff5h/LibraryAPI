namespace LibraryAPI.Data.Models
{
    public class Client
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string MiddleName { get; init; }
        public int Password { get; init; }
    }
}
