using System.ComponentModel.DataAnnotations;

namespace ZfssUZ.Models.Home
{
    public class ContactModel
    {
        [Display(Name = "ContantForm")]
        [Required(ErrorMessage = "ValidateContantForm")]
        public int ContantForm { get; set; }

        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "ValidatePhoneNumber")]
        [Phone]
        public int PhoneNumber { get; set; }

        [Display(Name = "EmailAddress")]
        [Required(ErrorMessage = "ValidateEmailAddress")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Display(Name = "MessageContent")]
        [Required(ErrorMessage = "ValidateMessageContent")]
        [EmailAddress]
        public string MessageContent { get; set; }
    }
}
