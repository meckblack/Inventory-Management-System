using IMS.Data.Objects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMS.Data.Objects.Entities
{
    public class Purchases
    {
        [Key]
        public int PurchaseId { get; set; }
        
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }

        [Required(ErrorMessage = "Bill No Required")]
        [Display(Name = "Bill Number")]
        public string PurchaseBillNo { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Purchase Date Required")]
        [Display(Name = "Date")]
        [DataType(DataType.Date, ErrorMessage = "Input A Valid Date")]
        public DateTime PurchaseDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Purchase Due Date Required")]
        [DataType(DataType.Date, ErrorMessage = "Input A Valid Date")]
        [Display(Name = "Due Date")]
        public DateTime PurchaseDueDate { get; set; }

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
    }
}