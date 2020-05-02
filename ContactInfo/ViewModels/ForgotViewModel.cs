using System.ComponentModel.DataAnnotations;

namespace ContactInfo.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}