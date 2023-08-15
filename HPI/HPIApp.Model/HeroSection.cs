using System.ComponentModel.DataAnnotations;

namespace HPIApp.Models
{
    public class HeroSection
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Header 1")]
        public string Header1 { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Header 2")]
        public string Header2 { get; set; }
        public string backgroundImgUrl { get; set; }
    }
}
