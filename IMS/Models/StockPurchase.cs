using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMS.Models
{
    public class StockPurchase
    {
        [Key]
        public int StockPurchaseId { get; set; }
        
        [Required(ErrorMessage = "Purchase Date Required")]
        [Display(Name = "Date")]
        public DateTime StockPurchaseDate { get; set; }
        
        [Required(ErrorMessage = "Bill No Required")]
        [Display(Name = "Bill Number")]
        public string StockPurchaseBillNo { get; set; }

        [Required(ErrorMessage = "Product Name Required")]
        [Display(Name = "Product Name")]
        public string StockPurchaseProductName { get; set; }

        [Required(ErrorMessage = "Product Quantity Required")]
        [Display(Name = "Quantity")]
        public int StockPurchaseQuantity { get; set; }

        [Required(ErrorMessage = "Product Cost Rate Requried")]
        [Display(Name = "Cost Rate")]
        public decimal StockPurchaseCostRate { get; set; }

        [Display(Name = "Cost Total(N)")]
        public decimal StockPurchaseBuyingTotal { get; set; }

        [Required(ErrorMessage = "Payment Requried")]
        [Display(Name = "Payment")]
        public decimal StockPurchasePayment { get; set; }

        [Required(ErrorMessage = "Purchase Description Required")]
        [Display(Name = "Purchase Description")]
        public string StockPurchaseDescription { get; set; }

        [Display(Name = "Purchase Balance")]
        public decimal StockPurcahseBalance { get; set; }

        [Required(ErrorMessage = "Purchase Mode Required")]
        [Display(Name = "Payment Mode")]
        public PaymentMode StockPurchaseMode { get; set; }

        [Required(ErrorMessage = "Purchase Due Date Required")]
        [Display(Name = "Due Date")]
        public DateTime StockPurchaseDueDate { get; set; }

        [Required(ErrorMessage = "Stock Puchase Supplier Required")]
        [Display(Name = "Supplier")]
        public string StockPurchaseSupplier { get; set; }
    }
}