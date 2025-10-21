using System;
using System.Collections.Generic;

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

    public class Course
    {
        private List<string> modules = new List<string>();
        public void addModule(string module)
        {
            modules.Add(module);
        }
        public void showModules()
        {
            Console.WriteLine("Course Modules:");
            foreach (var module in modules)
            {
                Console.WriteLine("- " + module);
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