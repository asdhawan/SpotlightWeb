using System.Collections.Generic;
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

        [DataType(DataType.Text)]
        [Display(Name = "Address", Prompt = "Address")]
        public string Address { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "City", Prompt = "City")]
        public string City { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "State", Prompt = "State")]
        public USState State { get; set; }

        [DataType(DataType.PostalCode)]
        [Display(Name = "ZipCode", Prompt = "ZipCode")]
        public string ZipCode { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Message", Prompt = "Message")]
        public string Message { get; set; }

        [Display(Name = "Photo Booths")]
        public bool PhotoBoothsYN { get; set; }

        [Display(Name = "Video Booths")]
        public bool VideoBoothsYN { get; set; }

        [Display(Name = "DJ Services")]
        public bool DJServicesYN { get; set; }

        [Display(Name = "Casino Nights")]
        public bool CasinoNightsYN { get; set; }

        [Display(Name = "Videography")]
        public bool VideographyYN { get; set; }

        [Display(Name = "Outdoor Movies")]
        public bool OutdoorMoviesYN { get; set; }

        public bool SuccessYN { get; set; }

        public string GetInterestedInString() {
            List<string> interestedIn = new List<string>();
            if (PhotoBoothsYN)
                interestedIn.Add("Photo Booths");
            if (VideoBoothsYN)
                interestedIn.Add("Video Booths");
            if (VideographyYN)
                interestedIn.Add("Videography");
            if (DJServicesYN)
                interestedIn.Add("DJ Services");
            if (CasinoNightsYN)
                interestedIn.Add("Casino Nights");
            if (OutdoorMoviesYN)
                interestedIn.Add("Outdoor Movies");
            return string.Join(", ", interestedIn);
        }
    }
}