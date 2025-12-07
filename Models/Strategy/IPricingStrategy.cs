namespace APS.Models.Strategy
{
    /// <summary>
    /// High Cohesion implementation (GRASP)
    /// Class should do one clear thing
    /// 
    /// Polymorphism implementation (GRASP)
    /// Perform different task without using "if/else" but creating separate Strategy
    /// </summary>
    public interface IPricingStrategy
    {
        double CalculatePrice(double basePrice);
    }
}