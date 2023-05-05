using System.ComponentModel.DataAnnotations;

namespace Taigate.Crispy.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Password")]
        public string Password { get; set; }
    }
}