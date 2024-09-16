using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
    public class Color
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HEX { get; set; }
        public bool Status { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }

    }
}
