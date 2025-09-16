namespace APS.Models
{
    public class User 
    {
        private string name;
        
        public User(string name) 
        {
            this.name = name;
        }
        
        public User(User user) {
            this.name = user.name;
        }
        
        public User Clone() {
            return new User(this);
        }
    }
}