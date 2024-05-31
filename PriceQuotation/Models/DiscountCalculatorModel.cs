// import data annotations for validation
using System.ComponentModel.DataAnnotations;

namespace PriceQuotation.Models
{
    public class DiscountCalculatorModel
    {
        [Required(ErrorMessage = "Please enter a subtotal.")]
        // add a range attribute to ensure the subtotal is greater than 0
        [Range(1, double.MaxValue, ErrorMessage = "Subtotal must be greater than 0.")]
        public decimal Subtotal { get; set; }

        [Required(ErrorMessage = "Please enter a discount percent.")]
        // add a range attribute to ensure the discount percent is between 0 and 100
        [Range(0, 100, ErrorMessage = "Discount percent must be between 0 and 100.")]
        public decimal DiscountPercent { get; set; }

        // add a method to calculate the discount amount
        public decimal CalculateDiscountAmount()
        {
            return Subtotal * (DiscountPercent / 100);
        }

        // add a method to calculate the total amount
        public decimal CalculateTotal()
        {
            decimal discountAmount = CalculateDiscountAmount();
            return Subtotal - discountAmount;
        }
    }
}
