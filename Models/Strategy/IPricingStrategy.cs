namespace APS.Models.Strategy
{
    public interface IPricingStrategy
    {
        double CalculatePrice(double basePrice);
    }
}