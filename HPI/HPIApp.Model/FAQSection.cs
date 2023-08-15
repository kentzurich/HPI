using System.ComponentModel.DataAnnotations;

namespace HPIApp.Models
{
    public class FAQSection
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
    }
}
