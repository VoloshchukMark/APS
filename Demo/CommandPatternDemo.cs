using System;
using APS.Models;
using APS.Models.Command;      // Import Command pattern classes
using APS.Models.Proxy;      // Import Proxy
using APS.Models.Flyweight;  // Not used here, but part of your project
using APS.Models.Lesson;     // Not used here, but part of your project

namespace APS.Demo
{
    public class CommandPatternDemo
    {
        public static void Run()
        {
            Console.WriteLine("======= Command Pattern Demo =======");
            
            // --- Setup ---
            
            // 1. Create Users (Actors)
            var adminUser = new User("Admin Amy", true);
            var regularUser = new User("Regular Rick", false);

            // 2. Create the Builder
            var courseBuilder = new ConcreteCourseBuilder();

            // 3. Create Receivers (using the Proxy for access control)
            // The receiver for the admin
            ICourseDirector adminDirector = new CourseDirectorProxy(adminUser, courseBuilder);
            
            // The receiver for the regular user
            ICourseDirector userDirector = new CourseDirectorProxy(regularUser, courseBuilder);

            // 4. Create the Invoker
            var commandProcessor = new CommandProcessor();

            // --- Create and Queue Commands ---
            
            // 5. Create Concrete Commands and pass them the appropriate receiver.
            
            // Admin tries to create a full course
            ICommand cmd1 = new ConstructFullCourseCommand(adminDirector);
            
            // Regular user tries to create a practical course
            ICommand cmd2 = new ConstructPracticalCourseCommand(userDirector);
            
            // Regular user tries to create a full course (this should be blocked by the proxy)
            ICommand cmd3 = new ConstructFullCourseCommand(userDirector);

            // 6. Add commands to the Invoker's queue
            commandProcessor.AddCommandToQueue(cmd1);
            commandProcessor.AddCommandToQueue(cmd2);
            commandProcessor.AddCommandToQueue(cmd3);
            
            // --- Execution ---
            
            // 7. Tell the Invoker to process all queued commands.
            // The Invoker doesn't know *what* the commands do, only that it can .Execute() them.
            // The access control logic is handled by the Proxy (Receiver).
            commandProcessor.ProcessCommands();
            
            // 8. Show history
            commandProcessor.ShowHistory();
            
            Console.WriteLine("====================================");
        }
    }
}