using System;

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