using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TsmBank.Models;

namespace TsmBank.CustomValidationAttributes
{
    public class OneOrMorePhoneNumbersRequired : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            return customer.PhoneNumbers.Any()
                ? ValidationResult.Success
                : new ValidationResult("At least one phone number is required.");
        }
    }
}