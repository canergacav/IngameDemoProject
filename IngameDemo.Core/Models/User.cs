namespace IngameDemo.Core.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
