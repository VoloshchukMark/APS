using System;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace APS.Models
{
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