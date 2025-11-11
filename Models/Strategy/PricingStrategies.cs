namespace APS.Models.Strategy
{
    /// <summary>
    /// 2. Конкретні Стратегії
    /// </summary>

    // Стандартна ціна (без змін)
    public class StandardPricingStrategy : IPricingStrategy
    {
        public double CalculatePrice(double basePrice)
        {
            return basePrice;
        }
    }

    // Знижка 20% для "ранніх пташок"
    public class EarlyBirdPricingStrategy : IPricingStrategy
    {
        public double CalculatePrice(double basePrice)
        {
            return basePrice * 0.80; // 20% знижка
        }
    }

    // Знижка 30% для груп
    public class GroupPricingStrategy : IPricingStrategy
    {
        public double CalculatePrice(double basePrice)
        {
            return basePrice * 0.70; // 30% знижка
        }
    }
}