using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMS.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product name required")]
        public string StockName { get; set; }

        [Display(Name = "Product Category")]
        [Required(ErrorMessage = "Product category required")]
        public string StockCategory { get; set; }

        [Display(Name = "Buying Price")]
        [Required(ErrorMessage = "Buying price required")]
        public decimal StockBuyingPrice { get; set; }

        [Display(Name = "Selling Price")]
        [Required(ErrorMessage = "Selling price required")]
        public decimal StockSellingPrice { get; set; }

        [Display(Name = "Supplier Name")]
        [Required(ErrorMessage = "Supplier name required")]
        public string StockSupplier { get; set; }

    }
}