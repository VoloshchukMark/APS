using System.Collections.Generic;

namespace APS.Models.Flyweight
{
    // 3. Фабрика Пристосуванців (Flyweight Factory)
    public class CourseCategoryFactory
    {
        private Dictionary<string, ICourseCategory> _categories = new Dictionary<string, ICourseCategory>();

        public ICourseCategory GetCategory(string key)
        {
            // Якщо категорія з таким ключем (назвою) вже є,
            // повертаємо існуючий об'єкт
            if (_categories.TryGetValue(key, out ICourseCategory category))
            {
                Console.WriteLine($"Factory: Використовуємо існуючу категорію '{key}'");
                return category;
            }
            
            // Інакше створюємо нову, зберігаємо її в кеші та повертаємо
            Console.WriteLine($"Factory: Створюємо нову категорію '{key}'");
            var newCategory = new CourseCategory(key);
            _categories.Add(key, newCategory);
            return newCategory;
        }

        public int GetTotalCategories()
        {
            Console.WriteLine($"\nВсього унікальних категорій створено: {_categories.Count}");
            return _categories.Count;
        }
    }
}