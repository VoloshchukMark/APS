using System;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace APS.Models.Lesson
{
    // Lessons
    public abstract class Lesson
    {
        protected string Name;
        protected ILessonImplementor Implementor;
        public Lesson(string name, ILessonImplementor implementor)
        {
            Name = name;
            Implementor = implementor;
        }
        public abstract void StartLesson();
    }
    
    public class VideoLesson : Lesson 
    {
        public VideoLesson(string name, ILessonImplementor implementor): base(name, implementor) { }
        
        public override void StartLesson()
        {
            Implementor.PlayVideo(Name);
        }
    }

    public class TextLesson : Lesson 
    {
        public TextLesson(string name, ILessonImplementor implementor): base(name, implementor) { }
        
        public override void StartLesson()
        {
            Implementor.ShowText(Name);
        }
    }
    
}