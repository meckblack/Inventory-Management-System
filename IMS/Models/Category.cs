using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMS.Models
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