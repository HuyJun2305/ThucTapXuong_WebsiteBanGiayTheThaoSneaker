using DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class FilterProductViewModel
    {
        public Guid? SelectedColorId { get; set; }
        public Guid? SelectedCategoryId { get; set; }
        public Guid? SelectedBrandId { get; set; }
        public Guid? SelectedSoleId { get; set; }
        public Guid? SelectedSizeId { get; set; }

        public List<Color> Colors { get; set; }
        public List<Category> Categories { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Sole> Soles { get; set; }
        public List<Size> Sizes { get; set; }

        public IEnumerable<ProductDetail> ProductDetails { get; set; }
    }
}
