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
    
}