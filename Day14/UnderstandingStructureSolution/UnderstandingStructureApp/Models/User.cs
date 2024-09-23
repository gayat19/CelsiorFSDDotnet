namespace UnderstandingStructureApp.Models
{
    public class User : IEquatable<User>
    {
        public string Username{ get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public bool Equals(User? other)
        {
            return this.Username == (other??new User()).Username;
        }
    }
}
