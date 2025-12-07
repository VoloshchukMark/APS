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
        public VideoFactory(ILessonImplementor implementor) : base(implementor) { }
        public override Lesson createLesson(string name)
        {
            return new VideoLesson(name, Implementor);
        }
    }

    public class TextFactory : LessonFactory
    {
        public TextFactory(ILessonImplementor implementor) : base(implementor) { }
        public override Lesson createLesson(string name)
        {
            return new TextLesson(name, Implementor);
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