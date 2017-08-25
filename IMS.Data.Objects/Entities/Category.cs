using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMS.Data.Objects.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category name required")]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> ProductVirtual { get; set; }
        public virtual ICollection<Stock> StockVirtual { get; set; }
    }
}