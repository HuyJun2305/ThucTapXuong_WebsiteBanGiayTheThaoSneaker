namespace API.DTO
{
    public class VoucherDTO
    {
        public string VoucherCode { get; set; }
        public string Name { get; set; }
        public string DiscountType { get; set; } // "Percent" hoặc "Amount"
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal MaxDiscountValue { get; set; }
        public int Stock { get; set; }
        public string Condition { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public Guid? AccountId { get; set; }
        public List<string> CustomerEmails { get; set; } // Danh sách email khách hàng
    }
}
