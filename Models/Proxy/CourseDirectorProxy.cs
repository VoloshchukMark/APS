using System;
using APS.Models; // Потрібно для User, ICourseDirector, ICourseBuilder

namespace APS.Models.Proxy
{
    /// <summary>
    /// Proxy
    /// 
    /// Indirection implementation (GRASP)
    /// Works as a space in between Actor and Real Director. Decide should Actor address to the Real Director
    /// </summary>
    public class CourseDirectorProxy : ICourseDirector
    {
        private CourseDirector _realDirector; // Посилання на реальний об'єкт
        private readonly User _actor; // Користувач, що виконує дію
        private readonly ICourseBuilder _courseBuilder;

        public CourseDirectorProxy(User actor, ICourseBuilder courseBuilder)
        {
            _actor = actor;
            _courseBuilder = courseBuilder;
            // Ми не створюємо _realDirector одразу (це елемент лінивої ініціалізації)
        }

        // Перевірка доступу
        private bool CheckAccess()
        {
            return _actor.IsAdmin;
        }

        // Лінива ініціалізація реального об'єкта
        private CourseDirector GetRealDirector()
        {
            if (_realDirector == null)
            {
                _realDirector = new CourseDirector(_courseBuilder);
            }
            return _realDirector;
        }

        public void constructCourse()
        {
            if (CheckAccess())
            {
                Console.WriteLine($"Proxy: Доступ для '{_actor.GetName()}' дозволено. Виклик CourseDirector.constructCourse()");
                GetRealDirector().constructCourse();
            }
            else
            {
                Console.WriteLine($"Proxy: ДОСТУП ЗАБОРОНЕНО для '{_actor.GetName()}'. Потрібні права Адміністратора.");
            }
        }

        public void constructPracticalCourse()
        {
            if (CheckAccess())
            {
                Console.WriteLine($"Proxy: Доступ для '{_actor.GetName()}' дозволено. Виклик CourseDirector.constructPracticalCourse()");
                GetRealDirector().constructPracticalCourse();
            }
            else
            {
                Console.WriteLine($"Proxy: ДОСТУП ЗАБОРОНЕНО для '{_actor.GetName()}'. Потрібні права Адміністратора.");
            }
        }
    }
}