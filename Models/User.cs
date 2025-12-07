using APS.Models.Mediator;
using APS.Models.Observer;

namespace APS.Models
{
    public abstract class UserPrototype
    {
        public abstract UserPrototype Clone();
    }


    /// <summary>
    /// Information Expert implementation (GRASP)
    /// Contains all the data required to perform specific task
    /// </summary>
    public class User : UserPrototype, IMediatorComponent, IObserver 
    {
        private string Name { get; set; }
        public bool IsAdmin { get; private set; }
        
        // --- Mediator-related fields/methods ---
        // The field and method from the old BaseComponent are now implemented directly.
        private IMediator _mediator;
        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
        // --- End Mediator fields ---

        public string GetName() { return Name; } 

        public User(string name, bool isAdmin = false) 
        {
            Name = name;
            IsAdmin = isAdmin;
            _mediator = null; 
        }
        
        public User(User user) {
            Name = user.Name;
            IsAdmin = user.IsAdmin; 
            _mediator = user._mediator;
        }
        
        public override User Clone() {
            return new User(this);
        }

        // --- Methods for Mediator communication (no changes here) ---
        public void EnrollInCourse(Course course)
        {
            Console.WriteLine($"[User: {Name}] Attempting to enroll in '{course.Name}'...");
            _mediator?.Notify(this, "User.Enroll", course);
        }

        public void ReceiveEnrollmentConfirmation(string courseName)
        {
            Console.WriteLine($"[User: {Name}] Successfully enrolled in '{courseName}'! My profile is updated.");
        }
        
        public void Update(string subjectName, string message)
        {
            Console.WriteLine($"[User: {Name}] Отримав сповіщення від '{subjectName}': {message}");
        }
    }
}