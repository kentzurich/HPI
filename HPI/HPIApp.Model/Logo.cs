using System.ComponentModel.DataAnnotations;

namespace HPIApp.Models
{
    public class Logo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Logo URL")]
        public string logoUrl { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Text Logo")]
        public string textLogo { get; set; }
    }
}
