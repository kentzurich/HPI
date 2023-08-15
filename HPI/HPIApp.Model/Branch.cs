using System.ComponentModel.DataAnnotations;

namespace HPIApp.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(12)]
        public string Name { get; set; }
        public List<Class> Class { get; set; }
    }
}
