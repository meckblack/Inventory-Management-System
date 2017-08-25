using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMS.Data.Objects.Entities
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        [Display(Name = "Stock Name")]
        [Required(ErrorMessage = "Product name required")]
        public string StockName { get; set; }

        [Display(Name = "Buying Price")]
        [Required(ErrorMessage = "Buying price required")]
        public decimal StockBuyingPrice { get; set; }

        [Display(Name = "Selling Price")]
        [Required(ErrorMessage = "Selling price required")]
        public decimal StockSellingPrice { get; set; }

        public int CategoryId { get; set; }
        public virtual Category StockCategory { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier StockSupplier { get; set; }
    }
}