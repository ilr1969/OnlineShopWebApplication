using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Helpers
{
    public class CheckBoxValidation : ValidationAttribute
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
