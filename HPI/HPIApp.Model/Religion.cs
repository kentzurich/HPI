using System.ComponentModel.DataAnnotations;

namespace HPIApp.Models
{
    public class Religion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
