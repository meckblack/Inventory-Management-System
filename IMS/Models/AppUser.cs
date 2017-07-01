using System.ComponentModel.DataAnnotations;

namespace IMS.Models
{
    public class AppUser
    {
        [Key]
        public int AppUserId { get; set; }

        [Required(ErrorMessage = "Username field required")]
        [Display(Name = "UserName")]
        public string AppUserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string AppUserEmail { get; set; }

        [Required(ErrorMessage = "Comfirm Password field required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string AppUserPassword { get; set; }

        [Required(ErrorMessage = "Comfirm Password field required")]
        [Compare("AppUserPassword", ErrorMessage = "Passwords doesn't match")]
        public string AppUserComfirmPassword { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}