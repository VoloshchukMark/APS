namespace APS.Models
{
    public abstract class UserPrototype
    {
        public abstract UserPrototype Clone();
    }

    public class User : UserPrototype
    {
        private string Name { get; set; }

        public User(string name) 
        {
            Name = name;
        }
        
        public User(User user) {
            Name = user.Name;
        }
        
        public override User Clone() {
            return new User(this);
        }
    }
}