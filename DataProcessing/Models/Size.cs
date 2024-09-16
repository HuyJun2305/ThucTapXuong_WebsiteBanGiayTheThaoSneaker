using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
    public class Size
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public bool Status { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
    }
}
