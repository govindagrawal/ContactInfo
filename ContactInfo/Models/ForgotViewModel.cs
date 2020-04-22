using System.ComponentModel.DataAnnotations;

namespace ContactInfo.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}