using System.ComponentModel.DataAnnotations;

namespace HPIApp.Models
{
    public class CompanyDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone No.")]
        [MaxLength(30)]
        public string PhoneNo { get; set; }
        [Display(Name = "Twitter URL")]
        public string twitterUrl { get; set; }
        [Display(Name = "Facebook URL")]
        public string facebookUrl { get; set; }
        [Display(Name = "Instagram URL")]
        public string instagramUrl { get; set; }
        [Display(Name = "LinkedIn URL")]
        public string linkedinUrl { get; set; }
    }
}
