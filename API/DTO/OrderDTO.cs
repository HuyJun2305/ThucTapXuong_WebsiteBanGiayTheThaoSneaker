using DataProcessing.Models;
using System.ComponentModel.DataAnnotations;

namespace API.DTO
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
	public class OrderDTO
	{
		public Guid Id { get; set; }
		[CurrentDate(ErrorMessage = "The Created Date must be today's date.")]
		public DateTime CreatedDate { get; set; }
		public decimal TotalPrice { get; set; }
		[Required]
		public string PaymentMethod { get; set; }
		public string Status { get; set; }

		public Guid UserId { get; set; }
		public Guid? VoucherId { get; set; }
		public Guid? AddressId { get; set; }
		public Guid? ShippingUnitID { get; set; }
	}
}
