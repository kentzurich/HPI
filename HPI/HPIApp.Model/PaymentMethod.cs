using System.ComponentModel.DataAnnotations;

namespace HPIApp.Models
{
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(12)]
        [Display(Name = "Payment Method")]
        public string Name { get; set; }
        public List<Transaction> Transaction { get; set; }
    }
}
