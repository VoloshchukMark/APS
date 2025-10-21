using System;

namespace APS.Models.Flyweight
{
    // 1. Інтерфейс Пристосуванця (Flyweight)
    public interface ICourseCategory
    {
        // 'courseName' - це зовнішній стан (extrinsic state),
        // він передається клієнтом і є унікальним для кожного контексту.
        void DisplayCategoryInfo(string courseName);
    }

    // 2. Конкретний Пристосуванець (Concrete Flyweight)
    public class CourseCategory : ICourseCategory
    {
        // Внутрішній стан (Intrinsic State) - спільний та незмінний.
        private readonly string _name;
        private readonly string _description;

        public CourseCategory(string name)
        {
            _name = name;
            _description = $"[Завантажено опис для категорії: {_name}]";
            
            // Імітація завантаження "важкого" ресурсу (напр. іконки, опису з БД)
            Console.WriteLine($"--- СТВОРЕНО НОВИЙ ОБ'ЄКТ КАТЕГОРІЇ: {_name} ---");
        }

        public void DisplayCategoryInfo(string courseName)
        {
            Console.WriteLine($"Курс '{courseName}' (зовнішній стан) належить до категорії: '{_name}' (внутрішній стан: {_description})");
        }
    }
}