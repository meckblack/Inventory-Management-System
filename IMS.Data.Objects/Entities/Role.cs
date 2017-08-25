using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMS.Data.Objects.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        [Display(Name ="Manage Staff")]
        public bool CanManageStaff { get; set; }

        [Display(Name = "Manage Inventory")]
        public bool CanManageInventory { get; set; }

        [Display(Name = "Manage Suppliers")]
        public bool CanManageSuppliers { get; set; }

        [Display(Name = "Manage Customers")]
        public bool CanManageCustomers { get; set; }
    }
}