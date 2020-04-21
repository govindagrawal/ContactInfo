using ContactInfo.Models;
using System.ComponentModel.DataAnnotations;

namespace ContactInfo.ViewModels
{
    public class ContactFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First Name cannot be more than 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot be more than 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid Email address")]
        [StringLength(100, ErrorMessage = "Email address cannot be more than 100 characters")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        [Display(Name = "Phone Number")]
        public int? PhoneNumber { get; set; }

        [StringLength(500, ErrorMessage = "Address cannot be more than 500 characters")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "City name cannot be more than 50 characters")]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = "State name cannot be more than 50 characters")]
        public string State { get; set; }

        [StringLength(50, ErrorMessage = "Country name cannot be more than 50 characters")]
        public string Country { get; set; }

        [StringLength(10, ErrorMessage = "Post code cannot be more than 10 characters")]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        public string Status { get; set; }

        public string Title => Id != 0 ? "Edit Contact" : "New Contact";
    }
}