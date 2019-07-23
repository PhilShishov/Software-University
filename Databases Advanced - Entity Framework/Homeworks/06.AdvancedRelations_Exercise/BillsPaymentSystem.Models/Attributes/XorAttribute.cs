
namespace BillsPaymentSystem.Models.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property)]
    public class XorAttribute : ValidationAttribute
    {
        private string targetProperty;
        public XorAttribute(string targetProperty)
        {
            this.targetProperty = targetProperty;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var targetPropertyValue = validationContext.ObjectType
                .GetProperty(targetProperty)
                .GetValue(validationContext.ObjectInstance);

            if ((value == null) ^ (targetPropertyValue == null))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The two properties must have opposite values!");
        }
    }
}
