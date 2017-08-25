using IMS.Data.Objects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMS.Data.Objects.Entities
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Sale Date Required")]
        [Display(Name = "Date")]
        [DataType(DataType.Date, ErrorMessage = "Input A Valid Date")]
        public DateTime SaleDate { get; set; }

        [Required(ErrorMessage = "Bill No Required")]
        [Display(Name = "Bill Number")]
        public string SaleBillNo { get; set; }

        [Required(ErrorMessage = "Product Name Required")]
        [Display(Name = "Product Name")]
        public string SaleProductName { get; set; }

        [Required(ErrorMessage = "Product Quantity Required")]
        [Display(Name = "Quantity")]
        public int SaleQuantity { get; set; }

        [Required(ErrorMessage = "Product Cost Rate Requried")]
        [Display(Name = "Cost Rate (N)")]
        public decimal SaleCostRate { get; set; }

        [Display(Name = "Cost Total(N)")]
        public decimal SaleCostTotal { get; set; }

        [Required(ErrorMessage = "Payment Requried")]
        [Display(Name = "Payment (N)")]
        public decimal SalePayment { get; set; }

        [Required(ErrorMessage = "Sale Description Required")]
        [Display(Name = "Sale Description")]
        public string SaleDescription { get; set; }

        [Display(Name = "Sale Balance (N)")]
        public decimal SaleBalance { get; set; }

        [Required(ErrorMessage = "Sale Mode Required")]
        [Display(Name = "Payment Mode")]
        public PaymentMode SaleMode { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Purchase Due Date Required")]
        [DataType(DataType.Date, ErrorMessage = "Input A Valid Date")]
        [Display(Name = "Due Date")]
        public DateTime SaleDueDate { get; set; }

        [Required(ErrorMessage = "Sale Customer Required")]
        [Display(Name = "Customer")]
        public string SaleCustomer { get; set; }
  
    }
}