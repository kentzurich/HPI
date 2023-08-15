using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HPIApp.Models
{
    public class EventsSection
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Event Description")]
        public string EventDescription { get; set; }
    }
}
