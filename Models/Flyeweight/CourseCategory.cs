using System;
using APS.Models;

namespace APS.Models.Flyweight
{
    // 1. Інтерфейс Пристосуванця (Flyweight)
    public interface ICourseCategory
    {
        void DisplayCategoryInfo(Course course);
    }

    // 2. Конкретний Пристосуванець (Concrete Flyweight)
    public class CourseCategory : ICourseCategory
    {
        private readonly string _name;
        private readonly string _description;

        public CourseCategory(string name)
        {
            _name = name;
            _description = $"[Завантажено опис для категорії: {_name}]";
            
            // Імітація завантаження "важкого" ресурсу (напр. іконки, опису з БД)
            Console.WriteLine($"--- СТВОРЕНО НОВИЙ ОБ'ЄКТ КАТЕГОРІЇ: {_name} ---");
        }

        public void DisplayCategoryInfo(Course course)
        {
            Console.WriteLine($"Курс '{course.ToString()}' (зовнішній стан) належить до категорії: '{_name}' (внутрішній стан: {_description})");
        }
    }
}