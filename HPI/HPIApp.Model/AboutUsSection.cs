using System.ComponentModel.DataAnnotations;

namespace HPIApp.Models
{
    public class AboutUsSection
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string VideoUrl { get; set; }
        public string VideoBoxUrl { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Main Content Title")]
        public string mainContentTitle { get; set; }
        [Required]
        [Display(Name = "Main Content Description")]
        public string mainContentDescription { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Content Title 1")]
        public string contentTitle_1 { get; set; }
        [Required]
        [Display(Name = "Content Description 1")]
        public string contentDescription_1 { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Content Title 2")]
        public string contentTitle_2 { get; set; }
        [Required]
        [Display(Name = "Content Description 2")]
        public string contentDescription_2 { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Content Title 3")]
        public string contentTitle_3 { get; set; }
        [Required]
        [Display(Name = "Content Description 3")]
        public string contentDescription_3 { get; set; }
    }
}
