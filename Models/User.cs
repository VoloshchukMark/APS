namespace APS.Models
{
    public abstract class UserPrototype
    {
        public abstract UserPrototype Clone();
    }

    public class User : UserPrototype
    {
        private string Name { get; set; }
        public bool IsAdmin { get; private set; }

        public string GetName() { return Name; } 

        public User(string name, bool isAdmin = false) 
        {
            Name = name;
            IsAdmin = isAdmin;
        }
        
        public User(User user) {
            Name = user.Name;
            IsAdmin = user.IsAdmin; 
        }
        
        public override User Clone() {
            return new User(this);
        }
    }
}