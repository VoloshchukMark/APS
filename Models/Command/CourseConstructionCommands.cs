using System;
using APS.Models; // Required for ICourseDirector

namespace APS.Models.Command
{
    public class ConstructFullCourseCommand : ICommand
    {
        // A reference to the receiver
        private readonly ICourseDirector _director;

        public ConstructFullCourseCommand(ICourseDirector director)
        {
            _director = director;
        }

        public void Execute()
        {
            _director.constructCourse();
        }
    }

    public class ConstructPracticalCourseCommand : ICommand
    {
        private readonly ICourseDirector _director;

        public ConstructPracticalCourseCommand(ICourseDirector director)
        {
            _director = director;
        }

        public void Execute()
        {
            _director.constructPracticalCourse();
        }
    }
}