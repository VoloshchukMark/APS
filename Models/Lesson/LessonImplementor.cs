using System;


    /// Структурний шаблон "Міст".
    ///
    /// Protected Variations implementation (GRASP)
    /// Secure system from unstable changes in specific function. Program would not crash in case there was a
    /// bug in API for Video player
    /// 
    ///     Робимо Lesson "абстракцією", і для нього створюємо ILessonImplementor та похідні як реалізації.
    /// Lesson має в собі ILessonImplementor, який відповідає за відтворення вмісту на мобільні пристрої 
    /// або через CDN.
    /// 
    ///     Таким чином розділяємо логіку Lesson та її відтворення, щоб не робити кашу з різних класів.
    /// А шаблон абстрактної фабрики доповнює цю ідею, дозволяючи створювати різні типи уроків
    /// (відео, текст) з різними реалізаціями (мобільний, CDN) без змішування логіки.

namespace APS.Models.Lesson
{
    // Bridge Implementors
    public interface ILessonImplementor
    {
        void PlayVideo(string name);
        
        void ShowText(string name);
    }

    public class MobileLessonImplementor: ILessonImplementor
    {
        public void PlayVideo(string name)
        {
            Console.WriteLine($"[Mobile] Playing video: {name}");
        }

        public void ShowText(string name)
        {
            Console.WriteLine($"[Mobile] Showing text: {name}");
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
    
}