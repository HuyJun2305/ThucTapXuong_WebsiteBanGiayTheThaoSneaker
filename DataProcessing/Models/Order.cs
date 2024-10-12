using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        public string? Status { get; set; } = "Chờ xác nhận";
        public Guid? AddressId { get; set; }


        public string? UserId { get; set; } = "Khách lẻ";
        public Guid? VoucherId { get; set; }

        [JsonIgnore]
        public virtual Voucher? Voucher { get; set; }
        public Guid? ShippingUnitID { get; set; }
        public virtual ShippingUnit? ShippingUnit { get; set; }
        [JsonIgnore]
        public ICollection<PaymentHistory>? paymentHistories { get; set; }
    }
}
