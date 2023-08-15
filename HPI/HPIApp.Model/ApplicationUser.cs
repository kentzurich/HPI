using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPIApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Column(TypeName = "Date")]
        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        [MaxLength(30)]
        public string MobileNo { get; set; }

        [Required]
        [MaxLength(50)]
        public string PresentAddress { get; set; }

        [Required]
        [MaxLength(12)]
        public string City { get; set; }

        [Required]
        [MaxLength(12)]
        public string Country { get; set; }
        public string MemberPhotoUrl { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime RegistrationDate { get; set; }

        [ForeignKey(nameof(GenderId))]
        public int GenderId { get; set; }
        [ValidateNever]
        public Gender Gender { get; set; }

        [ForeignKey(nameof(ReligionId))]
        public int ReligionId { get; set; }
        [ValidateNever]
        public Religion Religion { get; set; }

        [ForeignKey(nameof(ClassId))]
        public int ClassId { get; set; }
        [ValidateNever]
        public Class Class { get; set; }
        [ValidateNever]
        public List<Transaction> Transaction { get; set; }
        [ValidateNever]
        public List<TestimonialSection> TestimonialSection { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
