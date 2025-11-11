using System;
using APS.Models;
using APS.Models.Mediator;

namespace APS.Demo
{
    public class MediatorPatternDemo
    {
        public static void Run()
        {
            Console.WriteLine("======= Mediator Pattern Demo =======");

            // 1. Create the Mediator
            var mediator = new CourseEnrollmentMediator();

            // 2. Create the Colleagues (Components)
            var user = new User("Student Sam", false);
            var course = new Course("Advanced Design Patterns");

            // 3. Register colleagues with the mediator
            // (In this setup, we just inject the mediator into them)
            user.SetMediator(mediator);
            course.SetMediator(mediator);

            // 4. The Client triggers an action on one component.
            // Notice: The user *only* knows about itself and the course *object*.
            // It does NOT know about the EnrollmentManager or the inner logic.
            user.EnrollInCourse(course);
            
            Console.WriteLine("====================================");
        }
    }
}