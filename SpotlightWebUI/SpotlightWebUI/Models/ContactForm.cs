using System.ComponentModel.DataAnnotations;

namespace SpotlightWebUI.Models {
    public class ContactForm {
        [Required(ErrorMessage = "Required")]
        [Display(Name = "First Name", Prompt = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Last Name", Prompt = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "An Email Address is required.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address", Prompt = "Email Address")]
        public string EmailAddress { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number", Prompt = "Phone Number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Message", Prompt = "Message")]
        public string Message { get; set; }
    }
}