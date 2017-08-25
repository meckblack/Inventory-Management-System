using System.ComponentModel.DataAnnotations;

namespace IMS.Data.Objects.Entities
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required(ErrorMessage = "Username field required")]
        [Display(Name = "Admintrator")]
        public string AdminUsername { get; set; }

        [Required(ErrorMessage = "Password field required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string AdminPassword { get; set; }

        [Required(ErrorMessage = "Comfirm Password field required")]
        [DataType(DataType.Password)]
        [Compare("AdminPassword", ErrorMessage = "Passwords doesn't match")]
        [Display(Name = "Comfirm Password")]
        public string AdminComfirmPassword { get; set; }
    }
}