using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPIApp.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(12)]
        public string Name { get; set; }

    }
}
