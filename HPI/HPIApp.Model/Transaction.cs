using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPIApp.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Payment Reference No.")]
        public string PaymentRefNo { get; set; }
        [Required]
        [Display(Name = "Proof of Payment")]
        public string PaymentProofUrl { get; set; }
        [Required]
        public string TransactionType { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }
        [Required]
        [Range(270, 270, ErrorMessage = "Registration fee is ₱270.")]
        public double Amount { get; set; }
        [Required]
        public string Status { get; set; }
        [ForeignKey(nameof(PaymentMethodId))]
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
