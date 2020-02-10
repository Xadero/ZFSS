using System.ComponentModel.DataAnnotations;

namespace ZfssUZ.Models.Home
{
    public class ContactModel
    {
        [Display(Name = "ContactForm")]
        [Required(ErrorMessage = "ValidateContantForm")]
        public int ContactForm { get; set; }

        [Display(Name = "PhoneNumber")]
        [Phone]
        public int PhoneNumber { get; set; }

        [Display(Name = "EmailAddress")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Display(Name = "MessageContent")]
        [Required(ErrorMessage = "ValidateMessageContent")]
        [EmailAddress]
        public string MessageContent { get; set; }
    }
}
