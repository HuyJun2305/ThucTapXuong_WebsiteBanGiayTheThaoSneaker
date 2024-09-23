using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
    public class Voucher
    {
        // Khóa chính duy nhất
        public Guid Id { get; set; }

        // Mã voucher bắt buộc
        [Required(ErrorMessage = "Voucher code is required")]
        public string VoucherCode { get; set; }

        // Tên voucher bắt buộc, không quá 100 ký tự
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        // Loại voucher (có thể là voucher tiền, phần trăm, hoặc khác)
        public string VoucherType { get; set; }

        // Giá trị giảm giá trực tiếp (phải lớn hơn hoặc bằng 0)
        [Range(0, double.MaxValue, ErrorMessage = "Discount amount must be a positive value.")]
        public decimal DiscountAmount { get; set; }

        // Phần trăm giảm giá (giới hạn từ 0% đến 100%)
        [Range(0, 100, ErrorMessage = "Discount percent must be between 0 and 100.")]
        public decimal DiscountPercent { get; set; }

        // Điều kiện áp dụng voucher (không bắt buộc nhưng có thể có độ dài giới hạn)
        [StringLength(500, ErrorMessage = "Condition cannot be longer than 500 characters")]
        public string Condittion { get; set; }

        // Số lượng tồn kho phải là số nguyên dương hoặc bằng 0
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative integer.")]
        public int Stock { get; set; }

        // Ngày bắt đầu (phải là hôm nay hoặc tương lai)
        [Required(ErrorMessage = "Start date is required")]
        [DataType(DataType.Date)]
        [CustomStartDateValidation(ErrorMessage = "Start date cannot be in the past.")]
        public DateTime StartDate { get; set; }

        // Ngày kết thúc (phải sau ngày bắt đầu)
        [Required(ErrorMessage = "End date is required")]
        [DataType(DataType.Date)]
        [CustomEndDateValidation("StartDate", ErrorMessage = "End date must be after the start date.")]
        public DateTime EndDate { get; set; }

        // Trạng thái của voucher (true/false)
        public bool Status { get; set; }

        // ID của tài khoản (không bắt buộc)
        public Guid? AccountId { get; set; }
    }
}
