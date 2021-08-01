
using System.ComponentModel.DataAnnotations;

namespace backend.Models.Dto
{
    public class ProductIn {
        [Required]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        public Image Image { get; set; }
        [Required]
        public string ImageId { get; set; }
    }
}