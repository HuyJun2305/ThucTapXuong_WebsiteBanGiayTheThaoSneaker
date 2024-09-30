using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
    public class CurrentDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime createdDate)
            {
                DateTime today = DateTime.Today;
                if (createdDate.Date == today)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("The date must be today's date.");
                }
            }
            return new ValidationResult("Invalid date format.");
        }
    }
    public class Order
    {
        public Guid Id { get; set; }
        [CurrentDate(ErrorMessage = "The Created Date must be today's date.")]
        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        public string Status { get; set; }

        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public Guid VoucherId { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
