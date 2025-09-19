using System;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace APS.Models
{
    // Lessons
    public abstract class Lesson
    {
        protected string Name;
        public Lesson(string name)
        {
            Name = name;
        }
        public abstract void StartLesson();
    }
    
    public class VideoLesson : Lesson 
    {
        public VideoLesson(string name): base(name) { }
        
        public override void StartLesson()
        {
            Console.WriteLine("Tung tung tung tung tung sahur");
        }
    }

    public class TextLesson : Lesson 
    {
        public TextLesson(string name): base(name) { }
        
        public override void StartLesson()
        {
            Console.WriteLine("This is a text lesson");
        }
    }
    
    // Factories
    public abstract class LessonFactory
    {
        public abstract Lesson createLesson(string name);
    }
    
    public class VideoFactory : LessonFactory
    {
        public override Lesson createLesson(string name)
        {
            return new VideoLesson(name);
        } 
    }

    public class TextFactory : LessonFactory
    {
        public override Lesson createLesson(string name)
        {
            return new TextLesson(name);
        } 
    }
    
    public class LessonService
    {
        private LessonFactory Factory;
        public LessonService(LessonFactory factory)
        {
            Factory = factory;
        }
        
        public Lesson createLesson(string name)
        {
            return Factory.createLesson(name);
        }
    }
}