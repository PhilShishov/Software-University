namespace P04
{
    public static class PriceCalculator
    {
        public static decimal GetTotalPrice(decimal pricePerDay, int numberOfDays, DiscountType discountType, Season season)
        {
            decimal price = numberOfDays * pricePerDay * (decimal)season;
            price -= price * ((decimal)discountType / 100);
            return price;
        }
    }
}
