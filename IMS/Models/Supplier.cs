using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMS.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Name field required")]
        [Display(Name = "Name")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Address field required")]
        [Display(Name = "Address")]
        public string SupplierAddress { get; set; }

        [Required(ErrorMessage = "Phone number field required")]
        [Display(Name = "Phone Number")]
        public string SupplierContact { get; set; }

        public virtual ICollection<Stock> StockVirtual { get; set; }
    }
}