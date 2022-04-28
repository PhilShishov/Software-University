namespace P03.After.Contracts
{
    public interface IPricingCalculator
    {
        decimal CalculatePrice(OrderItem item);
    }
}