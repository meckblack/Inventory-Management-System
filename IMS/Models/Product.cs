using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMS.Models
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "Product name required")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        public int CategoryId { get; set; }
        public virtual Category CategoryVirtual { get; set; }
    }
}