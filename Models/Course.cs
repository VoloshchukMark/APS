using System;
using System.Collections.Generic;
using APS.Models.Mediator;

namespace APS.Models
{
    public interface ICourseBuilder
    {
        public void buildPracticalModule();
        public void buildTestModule();
        public void buildExamModule();
    }

    public class ConcreteCourseBuilder : ICourseBuilder
    {
        public void buildPracticalModule()
        {
            Console.WriteLine("Practical Module created");
        }

        public void buildTestModule()
        {
            Console.WriteLine("Test Module created");
        }

        public void buildExamModule()
        {
            Console.WriteLine("Exam Module created");
        }
    }

    // Make Course inherit from BaseComponent
     public class Course : IMediatorComponent
    {
        // --- Mediator-related fields/methods ---
        private IMediator _mediator;
        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
        // --- End Mediator fields ---

        // --- Properties and methods for enrollment ---
        public string Name { get; private set; }
        private List<string> modules = new List<string>();
        private List<User> _enrolledUsers = new List<User>();

        public Course(string name)
        {
            Name = name;
            _mediator = null;
        }

        public Course() : this("Untitled") { }
        
        public void HandleEnrollmentRequest(User user)
        {
            Console.WriteLine($"[Course: {Name}] Adding '{user.GetName()}' to roster.");
            _enrolledUsers.Add(user);
            _mediator?.Notify(this, "Course.Enrolled", user);
        }
        
        public void addModule(string module)
        {
            modules.Add(module);
            Notify("New module: " + module);
        }
        public void showModules()
        {
            Console.WriteLine($"Course Modules for: {Name}");
            foreach (var module in modules)
            {
                Console.WriteLine("- " + module);
            }
        }
        
        public void Notify(string message)
        {
            Console.WriteLine($"[Course: {Name}] Сповіщення {_enrolledUsers.Count} спостерігачів...");
            foreach (var user in _enrolledUsers)
            {
                // Поліморфно викликаємо Update() для кожного, хто реалізує IObserver
                user.Update(this.Name, message);
            }
        }
    }

    public interface ICourseDirector
    {
        void constructCourse();
        void constructPracticalCourse();
    }

    public class CourseDirector : ICourseDirector
    {
        private ICourseBuilder _courseBuilder;

        public CourseDirector(ICourseBuilder courseBuilder)
        {
            _courseBuilder = courseBuilder;
        }

        public void constructCourse()
        {
            _courseBuilder.buildPracticalModule();
            _courseBuilder.buildTestModule();
            _courseBuilder.buildExamModule();
        }
        public void constructPracticalCourse()
        {
            _courseBuilder.buildPracticalModule();
        }
    }
}