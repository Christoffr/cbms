namespace cbms.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(string name, string role, string password)
        {
            Name = name;
            Role = role;
            Password = password;
        }
    }
}
