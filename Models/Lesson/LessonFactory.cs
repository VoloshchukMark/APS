using System;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace APS.Models.Lesson
{
    // Factories
    public abstract class LessonFactory
    {
        protected readonly ILessonImplementor Implementor;
        public LessonFactory(ILessonImplementor implementor)
        {
            Implementor = implementor;
        }

        public abstract Lesson createLesson(string name);
    }
    
    public class VideoFactory : LessonFactory
    {
        public VideoFactory(ILessonImplementor implementor): base(implementor) { }
        public override Lesson createLesson(string name)
        {
            return new VideoLesson(name);
        } 
    }

    public class TextFactory : LessonFactory
    {
        public VideoFactory(ILessonImplementor implementor): base(implementor) { }
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