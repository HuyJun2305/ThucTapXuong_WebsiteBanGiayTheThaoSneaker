using DataProcessing.Models;

namespace API.DTO
{
	public class OrderHistoryDTO
	{
		public Guid Id { get; set; }
		public string StatusType { get; set; }
		public DateTime TimeStamp { get; set; }
		public string Note { get; set; }

		public Guid UpdatedByUserId { get; set; }
		public Guid OrderId { get; set; }
	}
}
