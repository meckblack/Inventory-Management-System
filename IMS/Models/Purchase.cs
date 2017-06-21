using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMS.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Purchase Date Required")]
        [Display(Name = "Date")]
        [DataType(DataType.Date, ErrorMessage = "Input A Valid Date")]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "Bill No Required")]
        [Display(Name = "Bill Number")]
        public string PurchaseBillNo { get; set; }

        [Required(ErrorMessage = "Product Name Required")]
        [Display(Name = "Product Name")]
        public string PurchaseProductName { get; set; }

        [Required(ErrorMessage = "Product Quantity Required")]
        [Display(Name = "Quantity")]
        public int PurchaseQuantity { get; set; }

        [Required(ErrorMessage = "Product Cost Rate Requried")]
        [Display(Name = "Cost Rate (N)")]
        public decimal PurchaseCostRate { get; set; }

        [Display(Name = "Cost Total(N)")]
        public decimal PurchaseCostTotal { get; set; }

        [Required(ErrorMessage = "Payment Requried")]
        [Display(Name = "Payment (N)")]
        public decimal PurchasePayment { get; set; }

        [Required(ErrorMessage = "Purchase Description Required")]
        [Display(Name = "Purchase Description")]
        public string PurchaseDescription { get; set; }

        [Display(Name = "Purchase Balance (N)")]
        public decimal PurcahseBalance { get; set; }

        [Required(ErrorMessage = "Purchase Mode Required")]
        [Display(Name = "Payment Mode")]
        public PaymentMode PurchaseMode { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Purchase Due Date Required")]
        [DataType(DataType.Date, ErrorMessage = "Input A Valid Date")]
        [Display(Name = "Due Date")]
        public DateTime PurchaseDueDate { get; set; }

        [Required(ErrorMessage = "Puchase Supplier Required")]
        [Display(Name = "Supplier")]
        public string PurchaseSupplier { get; set; }
    }
}