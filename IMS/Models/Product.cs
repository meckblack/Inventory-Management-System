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

        [Required(ErrorMessage = "Quantity required")]
        [Display(Name = "Quantity")]
        public int ProductQuantity { get; set; }

        [Required(ErrorMessage = "Product description is required")]
        [Display(Name ="Description")]
        [DataType(DataType.MultilineText)]
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }
        public virtual Category CategoryVirtual { get; set; }
    }
}