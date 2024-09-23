using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
	public class Address
	{
		public Guid Id { get; set; }
		public string RecipientName { get; set; }
		public string PhoneNumber { get; set; }
        public string AddressDetail { get; set; }
		public string City { get; set; }
        public string District { get; set; }
        public string Commune { get; set; }

		public Guid AccountId { get; set; }
		public virtual ApplicationUser User { get; set; }

		////12345645
    }
}
