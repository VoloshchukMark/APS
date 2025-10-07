using System;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace APS.Models
{
    // Bridge Implementors
    public interface ILessonImplementor
    {
        void PlayVideo(string name);
        
        void ShowText(string name);
    }

    public class ConsoleLessonImplementor : ILessonImplementor
    {
        public void PlayVideo(string name)
        {
            Console.WriteLine($"[Console] Playing video: {name}");
        }

        public void ShowText(string name)
        {
            Console.WriteLine($"[Console] Showing text: {name}");
        }
    }

    public class CdnLessonImplementor : ILessonImplementor
    {
        public void PlayVideo(string name)
        {
            Console.WriteLine($"[CDN] Streaming video: {name}");
        }

        public void ShowText(string name)
        {
            Console.WriteLine($"[CDN] Rendering text lesson: {name}");
        }
    }
    
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