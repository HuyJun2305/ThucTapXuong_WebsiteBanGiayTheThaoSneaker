using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual ApplicationUser Account {  get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}   
