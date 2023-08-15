using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPIApp.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(12)]
        public string Name { get; set; }
        public int Slot { get; set; }

        [ForeignKey(nameof(BranchId))]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
