namespace PriceQuotation.Models
{
    public class DiscountCalculator
    {
        // subtotal and discount percent for calculations 
        public decimal Subtotal { get; set; }
        public decimal DiscountPercent { get; set; }

        // calculate discount amount 
        public decimal CalculateDiscountAmount()
        {
            return Subtotal * (DiscountPercent / 100);
        }

        // calculate amount after discount is applied
        public decimal CalculateTotal()
        {
            decimal discountAmount = CalculateDiscountAmount();
            return Subtotal - discountAmount;
        }
    }
}
