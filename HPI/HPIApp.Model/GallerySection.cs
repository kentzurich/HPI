using System.ComponentModel.DataAnnotations;

namespace HPIApp.Models
{
    public class GallerySection
    {
        [Key]
        public int Id { get; set; }
        public string ImgUrl { get; set; }
    }
}
