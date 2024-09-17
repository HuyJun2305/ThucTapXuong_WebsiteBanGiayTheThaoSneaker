using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Category Category { get; set; }
        public virtual Sole Sole { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Material Material { get; set; }

    }
}
