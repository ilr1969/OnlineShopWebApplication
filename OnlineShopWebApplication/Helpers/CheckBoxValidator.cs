using OnlineShopWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApplication.Helpers
{
    public class CheckBoxValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var order = (OrderDeliveryInfoViewModel)validationContext.ObjectInstance;
            if (order.Agree == false)
            {
                return new ValidationResult(ErrorMessage == null ? "Подтвердите согласие" : ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
